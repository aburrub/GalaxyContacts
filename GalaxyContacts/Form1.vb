Public Class Form1
    Private obj As ImportVcf = Nothing

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.StyleComboBox.SelectedIndex = 0
        Dim countries As New Dictionary(Of String, String)
        FillInCountries(countries)

        Me.CountryComboBox.DataSource = New BindingSource(countries, Nothing)
        Me.CountryComboBox.ValueMember = "Value"
        Me.CountryComboBox.DisplayMember = "Key"
    End Sub

    Private Sub BrowseButton_Click(sender As Object, e As EventArgs) Handles BrowseButton.Click
        Me.OpenFileDialog1.Filter = "VCF Contact Files|*.vcf"
        Me.OpenFileDialog1.FileName = ""
        Me.OpenFileDialog1.ShowDialog()
        Me.PathTextBox.Text = Me.OpenFileDialog1.FileName
    End Sub

    Private Sub RemoveDuplicatesButton_Click(sender As Object, e As EventArgs) Handles RemoveDuplicatesButton.Click
        Try
            If Not String.IsNullOrEmpty(PathTextBox.Text) Then
                Dim outputFile As String = Me.OpenFileDialog1.FileName + ".RemoveDuplicates.vcf"
                obj = New ImportVcf(Me.PathTextBox.Text, Me.KeepPhotosCheckBox.Checked, GetInputStyle)
                obj.CountryCodeStyle = GetInputStyle()
                obj.CountryCode = Me.CountryComboBox.SelectedValue
                obj.importData()
                obj.BuildFile(outputFile)
                SetConsoleText("Successfully Generated" + Environment.NewLine + outputFile)
            Else
                SetConsoleText("InValid File")
            End If
        Catch ex As Exception
            SetConsoleText(ex.Message)
        End Try


    End Sub

    Private Function GetInputStyle() As CountryCodeStyle
        If StyleComboBox.Text = "Remove Country Code" Then
            Return CountryCodeStyle.RemoveCode
        End If

        If StyleComboBox.Text = "Append Country Code" Then
            Return CountryCodeStyle.AppendCode
        End If


        Return CountryCodeStyle.DontChange
    End Function

    Private Sub SetConsoleText(ByVal txt As String)
        Me.ConsoleTextBox.Clear()
        Me.ConsoleTextBox.Text = txt
    End Sub


    Private Sub FillInCountries(ByRef countries As Dictionary(Of String, String))
        countries.Add("Palestine", "970")
        countries.Add("Afghanistan", "93")
        countries.Add("Albania", "355")
        countries.Add("Algeria", "213")
        countries.Add("American Samoa", "1684")
        countries.Add("Andorra", "376")
        countries.Add("Angola", "244")
        countries.Add("Anguilla", "1264")
        countries.Add("Antarctica", "0")
        countries.Add("Argentina", "54")
        countries.Add("Armenia", "374")
        countries.Add("Aruba", "297")
        countries.Add("Australia", "61")
        countries.Add("Austria", "43")
        countries.Add("Azerbaijan", "994")
        countries.Add("Bahrain", "973")
        countries.Add("Bangladesh", "880")
        countries.Add("Barbados", "1246")
        countries.Add("Belarus", "375")
        countries.Add("Belgium", "32")
        countries.Add("Belize", "501")
        countries.Add("Benin", "229")
        countries.Add("Bermuda", "1441")
        countries.Add("Bhutan", "975")
        countries.Add("Bolivia", "591")
        countries.Add("Bosnia and Herzegovina", "387")
        countries.Add("Botswana", "267")
        countries.Add("Bouvet Island", "0")
        countries.Add("Brazil", "55")
        countries.Add("Brunei Darussalam", "673")
        countries.Add("Bulgaria", "359")
        countries.Add("Burkina Faso", "226")
        countries.Add("Burundi", "257")
        countries.Add("Cambodia", "855")
        countries.Add("Cameroon", "237")
        countries.Add("Canada", "1")
        countries.Add("Cape Verde", "238")
        countries.Add("Cayman Islands", "1345")
        countries.Add("Central African Republic", "236")
        countries.Add("Chad", "235")
        countries.Add("Chile", "56")
        countries.Add("China", "86")
        countries.Add("Christmas Island", "61")
        countries.Add("Cocos (Keeling) Islands", "672")
        countries.Add("Colombia", "57")
        countries.Add("Comoros", "269")
        countries.Add("Congo", "242")
        countries.Add("Cook Islands", "682")
        countries.Add("Costa Rica", "506")
        countries.Add("Cote D'Ivoire", "225")
        countries.Add("Croatia", "385")
        countries.Add("Cuba", "53")
        countries.Add("Cyprus", "357")
        countries.Add("Czech Republic", "420")
        countries.Add("Denmark", "45")
        countries.Add("Djibouti", "253")
        countries.Add("Dominica", "1767")
        countries.Add("Dominican Republic", "1809")
        countries.Add("Ecuador", "593")
        countries.Add("Egypt", "20")
        countries.Add("El Salvador", "503")
        countries.Add("Equatorial Guinea", "240")
        countries.Add("Eritrea", "291")
        countries.Add("Estonia", "372")
        countries.Add("Ethiopia", "251")
        countries.Add("Falkland Islands (Malvinas)", "500")
        countries.Add("Faroe Islands", "298")
        countries.Add("Fiji", "679")
        countries.Add("Finland", "358")
        countries.Add("France", "33")
        countries.Add("French Guiana", "594")
        countries.Add("French Polynesia", "689")
        countries.Add("Gabon", "241")
        countries.Add("Georgia", "995")
        countries.Add("Germany", "49")
        countries.Add("Ghana", "233")
        countries.Add("Gibraltar", "350")
        countries.Add("Greece", "30")
        countries.Add("Greenland", "299")
        countries.Add("Grenada", "1473")
        countries.Add("Guadeloupe", "590")
        countries.Add("Guam", "1671")
        countries.Add("Guatemala", "502")
        countries.Add("Guinea", "224")
        countries.Add("Guinea-Bissau", "245")
        countries.Add("Guyana", "592")
        countries.Add("Haiti", "509")
        countries.Add("Honduras", "504")
        countries.Add("Hungary", "36")
        countries.Add("Iceland", "354")
        countries.Add("India", "91")
        countries.Add("Indonesia", "62")
        countries.Add("Iran, Islamic Republic of", "98")
        countries.Add("Iraq", "964")
        countries.Add("Ireland", "353")
        countries.Add("Italy", "39")
        countries.Add("Jamaica", "1876")
        countries.Add("Japan", "81")
        countries.Add("Jordan", "962")
        countries.Add("Kazakhstan", "7")
        countries.Add("Kenya", "254")
        countries.Add("Kiribati", "686")
        countries.Add("Kuwait", "965")
        countries.Add("Kyrgyzstan", "996")
        countries.Add("Latvia", "371")
        countries.Add("Lebanon", "961")
        countries.Add("Lesotho", "266")
        countries.Add("Liberia", "231")
        countries.Add("Libyan Arab Jamahiriya", "218")
        countries.Add("Liechtenstein", "423")
        countries.Add("Lithuania", "370")
        countries.Add("Luxembourg", "352")
        countries.Add("Madagascar", "261")
        countries.Add("Malawi", "265")
        countries.Add("Malaysia", "60")
        countries.Add("Maldives", "960")
        countries.Add("Mali", "223")
        countries.Add("Malta", "356")
        countries.Add("Marshall Islands", "692")
        countries.Add("Mauritania", "222")
        countries.Add("Mauritius", "230")
        countries.Add("Mexico", "52")
        countries.Add("Moldova, Republic of", "373")
        countries.Add("Monaco", "377")
        countries.Add("Mongolia", "976")
        countries.Add("Montserrat", "1664")
        countries.Add("Morocco", "212")
        countries.Add("Mozambique", "258")
        countries.Add("Namibia", "264")
        countries.Add("Nauru", "674")
        countries.Add("Nepal", "977")
        countries.Add("Netherlands Antilles", "599")
        countries.Add("Netherlands", "31")
        countries.Add("New Caledonia", "687")
        countries.Add("New Zealand", "64")
        countries.Add("Nicaragua", "505")
        countries.Add("Niger", "227")
        countries.Add("Nigeria", "234")
        countries.Add("Niue", "683")
        countries.Add("Norfolk Island", "672")
        countries.Add("Northern Mariana Islands", "1670")
        countries.Add("Norway", "47")
        countries.Add("Oman", "968")
        countries.Add("Pakistan", "92")
        countries.Add("Palau", "680")
        countries.Add("Panama", "507")
        countries.Add("Papua New Guinea", "675")
        countries.Add("Paraguay", "595")
        countries.Add("Peru", "51")
        countries.Add("Philippines", "63")
        countries.Add("Poland", "48")
        countries.Add("Portugal", "351")
        countries.Add("Puerto Rico", "1787")
        countries.Add("Qatar", "974")
        countries.Add("Romania", "40")
        countries.Add("Rwanda", "250")
        countries.Add("Saint Kitts and Nevis", "1869")
        countries.Add("Saint Lucia", "1758")
        countries.Add("Samoa", "684")
        countries.Add("San Marino", "378")
        countries.Add("Sao Tome and Principe", "239")
        countries.Add("Saudi Arabia", "966")
        countries.Add("Senegal", "221")
        countries.Add("Seychelles", "248")
        countries.Add("Sierra Leone", "232")
        countries.Add("Singapore", "65")
        countries.Add("Slovakia", "421")
        countries.Add("Slovenia", "386")
        countries.Add("Solomon Islands", "677")
        countries.Add("Somalia", "252")
        countries.Add("South Africa", "27")
        countries.Add("Spain", "34")
        countries.Add("Sudan", "249")
        countries.Add("Suriname", "597")
        countries.Add("Swaziland", "268")
        countries.Add("Sweden", "46")
        countries.Add("Switzerland", "41")
        countries.Add("Syrian Arab Republic", "963")
        countries.Add("Tajikistan", "992")
        countries.Add("Thailand", "66")
        countries.Add("Togo", "228")
        countries.Add("Tokelau", "690")
        countries.Add("Tonga", "676")
        countries.Add("Tunisia", "216")
        countries.Add("Turkey", "90")
        countries.Add("Turkmenistan", "7370")
        countries.Add("Tuvalu", "688")
        countries.Add("Uganda", "256")
        countries.Add("Ukraine", "380")
        countries.Add("United Arab Emirates", "971")
        countries.Add("United Kingdom", "44")
        countries.Add("United States", "1")
        countries.Add("Uruguay", "598")
        countries.Add("Uzbekistan", "998")
        countries.Add("Vanuatu", "678")
        countries.Add("Venezuela", "58")
        countries.Add("Viet Nam", "84")
        countries.Add("Virgin Islands, British", "1284")
        countries.Add("Virgin Islands, U.S.", "1340")
        countries.Add("Wallis and Futuna", "681")
        countries.Add("Western Sahara", "212")
        countries.Add("Yemen", "967")
        countries.Add("Zambia", "260")
        countries.Add("Zimbabwe", "263")
    End Sub

    Private Sub StyleComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles StyleComboBox.SelectedIndexChanged
        Me.CountryComboBox.Enabled = If(Me.StyleComboBox.Text = "Append Country Code", True, False)

    End Sub


End Class
