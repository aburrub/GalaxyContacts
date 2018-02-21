Public Class ImportVcf
    Private FilePath As String
    Private ImportPhotos As Boolean
    Private _CountryCodeStyle As CountryCodeStyle
    Private _CountryCode As String

    Private _VCFs As New Dictionary(Of String, Vcf)
    Public Sub New(ByVal FilePath As String, Optional ImportPhotos As Boolean = False, Optional CountryCodeStyle As CountryCodeStyle = GalaxyContacts.CountryCodeStyle.DontChange)
        Me.FilePath = FilePath
        Me.ImportPhotos = ImportPhotos
        Me._CountryCodeStyle = CountryCodeStyle
    End Sub

    Public Property CountryCodeStyle As CountryCodeStyle
        Get
            Return Me._CountryCodeStyle
        End Get
        Set(value As CountryCodeStyle)
            Me._CountryCodeStyle = value
        End Set
    End Property


    Public Property CountryCode As String
        Get
            Return Me._CountryCode
        End Get
        Set(value As String)
            Me._CountryCode = value
        End Set
    End Property


    Public Sub importData()
        Me._VCFs.Clear()
        Dim r As New IO.StreamReader(Me.FilePath)
        Dim vcf As Vcf = Nothing
        Dim PhotoFlag As Boolean = False
        While Not r.EndOfStream
            Dim l As String = r.ReadLine()

            If l.StartsWith("BEGIN:VCARD") Then
                vcf = New Vcf()
                PhotoFlag = False
            End If

            If l.StartsWith("N:") Then
                SetFullName(vcf, l)
                If Me._VCFs.ContainsKey(String.Format("{0} {1}", vcf.FirstName, vcf.LastName)) Then
                    vcf = Me._VCFs(String.Format("{0} {1}", vcf.FirstName, vcf.LastName))
                End If

            End If

            SetPhones(vcf, l)
            SetEmails(vcf, l)
            SetVcdAttribute(vcf, "ORG", l)
            SetVcdAttribute(vcf, "TITLE", l)
            SetVcdAttribute(vcf, "BDAY", l)
            SetVcdAttribute(vcf, "URL", l)


            '**** Photo Block ****
            If ImportPhotos Then
                If l.StartsWith("PHOTO;") Then
                    PhotoFlag = True
                End If
                If PhotoFlag And Not l.StartsWith("END:VCARD") Then
                    vcf.PhotoLines.Add(l)
                End If
            End If

            If l.StartsWith("END:VCARD") Then
                If vcf IsNot Nothing AndAlso (vcf.FirstName IsNot Nothing And vcf.LastName IsNot Nothing) AndAlso Not Me._VCFs.ContainsKey(String.Format("{0} {1}", vcf.FirstName, vcf.LastName)) Then
                    Me._VCFs.Add(String.Format("{0} {1}", vcf.FirstName, vcf.LastName), vcf)
                End If

                If vcf.FirstName Is Nothing Then
                    Dim G As Guid = Guid.NewGuid
                    Me._VCFs.Add(G.ToString, vcf)
                End If
            End If

            If vcf IsNot Nothing Then
                vcf.OriginalVcfCard += l + Environment.NewLine
            End If
        End While


        removeAllDuplications()
    End Sub

    Private Sub SetFullName(ByRef vcf As Vcf, ByVal line As String)
            Dim names() As String = line.Split(";")
            For i As Integer = 0 To names.Length - 1
                If i = 0 Then
                    vcf.LastName = names(i).Substring(2)
                End If
                If i = 1 Then
                    vcf.FirstName = names(i)
                End If

                If i = 2 Then
                    vcf.MiddleName = names(i)
                End If
            Next
    End Sub

    Private Sub SetPhones(ByRef vcf As Vcf, ByVal line As String)
        If line.StartsWith("TEL;") Then
            Dim phone As String = line.Split(":")(1)
            If Not IsVcfPhoneExists(vcf, phone) Then
                vcf.Cells.Add(GetNumberWithCountryCode(phone))
            End If

        End If
    End Sub

    Private Function GetNumberWithCountryCode(ByVal PhoneNumber As String) As String
        Try
            Dim defLen As Integer = 9
            Select Case PhoneNumber.Length
                Case 9
                    defLen = 8 ' landline

                Case 10
                    defLen = 9 ' cellular
            End Select

            Select Case Me._CountryCodeStyle
                Case CountryCodeStyle.DontChange
                    Return PhoneNumber

                Case CountryCodeStyle.AppendCode
                    If Me._CountryCode = "970" Or Me._CountryCode = "972" Then
                        Dim n As String = Right(PhoneNumber, defLen)
                        If Left(n, 2) = "56" Or Left(n, 2) = "59" Then
                            Me._CountryCode = "970"
                        Else
                            Me._CountryCode = "972"
                        End If
                    End If

                    Return String.Format("+{0}{1}", Me._CountryCode, Right(PhoneNumber, defLen))

                Case CountryCodeStyle.RemoveCode
                    Return String.Format("0{1}", Me._CountryCode, Right(PhoneNumber, defLen))
            End Select


        Catch ex As Exception
            Return PhoneNumber
        End Try
       

    End Function


    Private Function IsVcfPhoneExists(ByRef vcf As Vcf, ByVal phone As String) As Boolean
        For Each cell As String In vcf.Cells
            If Right(cell, 9) = Right(phone, 9) Then
                Return True
            End If
        Next
        Return False
    End Function

    Private Function IsVcfEmailExists(ByRef vcf As Vcf, ByVal email As String) As Boolean
        For Each emailStr As String In vcf.Emails
            If Right(emailStr, 9) = Right(email, 9) Then
                Return True
            End If
        Next
        Return False
    End Function



    Private Sub SetEmails(ByRef vcf As Vcf, ByVal line As String)
        If line.StartsWith("EMAIL;") Or line.StartsWith("EMAIL:") Then
            Dim email As String = line.Split(":")(1)
            If Not IsVcfEmailExists(vcf, email) Then
                vcf.Emails.Add(email)
            End If

        End If
    End Sub

    Private Sub SetVcdAttribute(ByRef vcf As Vcf, ByVal attrName As String, ByVal line As String)
        If line.StartsWith(String.Format("{0}:", attrName.ToUpper)) Then
            If line.Split(";").Count > 1 Then
                Return
            End If
            Select Case attrName
                Case "ORG"
                    vcf.Organization = line.Split(":")(1)

                Case "TITLE"
                    vcf.TITLE = line.Split(":")(1)

                Case "BDAY"
                    vcf.BDAY = line.Split(":")(1)


                Case "URL"
                    vcf.URL = line.Substring(4)
            End Select

        End If
    End Sub

    Public ReadOnly Property VCFs As Dictionary(Of String, Vcf)
        Get
            Return Me._VCFs
        End Get
    End Property

    Public Sub BuildFile(ByVal OutputFile As String)

        Dim wr As New IO.StreamWriter(OutputFile, False)
        For Each vcfObj As Vcf In Me._VCFs.Values
            If vcfObj.FirstName Is Nothing Then
                wr.WriteLine(vcfObj.OriginalVcfCard)
            Else
                wr.WriteLine("BEGIN:VCARD")
                wr.WriteLine(String.Format("N:{0};{1};{2};;", vcfObj.LastName, vcfObj.FirstName, vcfObj.MiddleName))
                If String.IsNullOrEmpty(vcfObj.MiddleName) Then
                    wr.WriteLine(String.Format("FN:{0} {1}", vcfObj.FirstName, vcfObj.LastName))
                Else
                    wr.WriteLine(String.Format("FN:{0} {1} {2}", vcfObj.FirstName, vcfObj.MiddleName, vcfObj.LastName))
                End If

                For i As Integer = 0 To vcfObj.Cells.Count - 1
                    Dim type As String = If(i = vcfObj.Cells.Count - 1, "HOME", "CELL")
                    wr.WriteLine(String.Format("TEL;{0}:{1}", type, vcfObj.Cells(i)))
                Next
                For Each Email As String In vcfObj.Emails
                    wr.WriteLine(String.Format("EMAIL;HOME:{0}", Email))
                Next

                If vcfObj.Organization IsNot Nothing Then
                    wr.WriteLine(String.Format("ORG:{0}", vcfObj.Organization))
                End If

                If vcfObj.TITLE IsNot Nothing Then
                    wr.WriteLine(String.Format("TITLE:{0}", vcfObj.TITLE))
                End If


                If vcfObj.BDAY IsNot Nothing Then
                    wr.WriteLine(String.Format("BDAY:{0}", vcfObj.BDAY))
                End If


                If vcfObj.URL IsNot Nothing Then
                    wr.WriteLine(String.Format("URL:{0}", vcfObj.URL))
                End If



                If Me.ImportPhotos Then
                    For Each pl As String In vcfObj.PhotoLines
                        wr.WriteLine(pl)
                    Next
                End If

                wr.WriteLine("END:VCARD")
            End If

        Next

        wr.Close()
        wr.Dispose()
    End Sub


    Private Sub removeAllDuplications()
        For Each o As Vcf In Me._VCFs.Values
            o.Emails = RemoveListDuplications(o.Emails)
        Next
    End Sub

    Private Function RemoveListDuplications(ByRef list As List(Of String)) As List(Of String)
        Dim res As New List(Of String)
        For Each i As String In list
            If Not res.Contains(LTrim(RTrim(i))) Then
                res.Add(i)
            End If
        Next

        Return res
    End Function
End Class

Public Enum CountryCodeStyle
    DontChange
    RemoveCode
    AppendCode
End Enum
