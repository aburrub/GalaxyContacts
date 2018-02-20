<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.BrowseButton = New System.Windows.Forms.Button()
        Me.PathTextBox = New System.Windows.Forms.TextBox()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.RemoveDuplicatesButton = New System.Windows.Forms.Button()
        Me.KeepPhotosCheckBox = New System.Windows.Forms.CheckBox()
        Me.ConsoleTextBox = New System.Windows.Forms.TextBox()
        Me.StyleComboBox = New System.Windows.Forms.ComboBox()
        Me.CountryComboBox = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'BrowseButton
        '
        Me.BrowseButton.Location = New System.Drawing.Point(12, 12)
        Me.BrowseButton.Name = "BrowseButton"
        Me.BrowseButton.Size = New System.Drawing.Size(75, 23)
        Me.BrowseButton.TabIndex = 0
        Me.BrowseButton.Text = "Browse"
        Me.BrowseButton.UseVisualStyleBackColor = True
        '
        'PathTextBox
        '
        Me.PathTextBox.Enabled = False
        Me.PathTextBox.Location = New System.Drawing.Point(12, 41)
        Me.PathTextBox.Name = "PathTextBox"
        Me.PathTextBox.Size = New System.Drawing.Size(441, 20)
        Me.PathTextBox.TabIndex = 1
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'RemoveDuplicatesButton
        '
        Me.RemoveDuplicatesButton.Location = New System.Drawing.Point(340, 67)
        Me.RemoveDuplicatesButton.Name = "RemoveDuplicatesButton"
        Me.RemoveDuplicatesButton.Size = New System.Drawing.Size(113, 23)
        Me.RemoveDuplicatesButton.TabIndex = 0
        Me.RemoveDuplicatesButton.Text = "Remove Duplicates"
        Me.RemoveDuplicatesButton.UseVisualStyleBackColor = True
        '
        'KeepPhotosCheckBox
        '
        Me.KeepPhotosCheckBox.AutoSize = True
        Me.KeepPhotosCheckBox.Location = New System.Drawing.Point(12, 73)
        Me.KeepPhotosCheckBox.Name = "KeepPhotosCheckBox"
        Me.KeepPhotosCheckBox.Size = New System.Drawing.Size(87, 17)
        Me.KeepPhotosCheckBox.TabIndex = 2
        Me.KeepPhotosCheckBox.Text = "Keep Photos"
        Me.KeepPhotosCheckBox.UseVisualStyleBackColor = True
        '
        'ConsoleTextBox
        '
        Me.ConsoleTextBox.Location = New System.Drawing.Point(12, 129)
        Me.ConsoleTextBox.Multiline = True
        Me.ConsoleTextBox.Name = "ConsoleTextBox"
        Me.ConsoleTextBox.ReadOnly = True
        Me.ConsoleTextBox.Size = New System.Drawing.Size(290, 76)
        Me.ConsoleTextBox.TabIndex = 3
        '
        'StyleComboBox
        '
        Me.StyleComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.StyleComboBox.DropDownWidth = 200
        Me.StyleComboBox.FormattingEnabled = True
        Me.StyleComboBox.Items.AddRange(New Object() {"Don't Change", "Remove Country Code", "Append Country Code"})
        Me.StyleComboBox.Location = New System.Drawing.Point(12, 96)
        Me.StyleComboBox.Name = "StyleComboBox"
        Me.StyleComboBox.Size = New System.Drawing.Size(118, 21)
        Me.StyleComboBox.TabIndex = 4
        '
        'CountryComboBox
        '
        Me.CountryComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.CountryComboBox.DropDownWidth = 200
        Me.CountryComboBox.FormattingEnabled = True
        Me.CountryComboBox.Items.AddRange(New Object() {"Don't Change", "Remove Country Code", "Append Country Code"})
        Me.CountryComboBox.Location = New System.Drawing.Point(136, 96)
        Me.CountryComboBox.Name = "CountryComboBox"
        Me.CountryComboBox.Size = New System.Drawing.Size(166, 21)
        Me.CountryComboBox.TabIndex = 4
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(465, 233)
        Me.Controls.Add(Me.CountryComboBox)
        Me.Controls.Add(Me.StyleComboBox)
        Me.Controls.Add(Me.ConsoleTextBox)
        Me.Controls.Add(Me.KeepPhotosCheckBox)
        Me.Controls.Add(Me.PathTextBox)
        Me.Controls.Add(Me.RemoveDuplicatesButton)
        Me.Controls.Add(Me.BrowseButton)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BrowseButton As System.Windows.Forms.Button
    Friend WithEvents PathTextBox As System.Windows.Forms.TextBox
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents RemoveDuplicatesButton As System.Windows.Forms.Button
    Friend WithEvents KeepPhotosCheckBox As System.Windows.Forms.CheckBox
    Friend WithEvents ConsoleTextBox As System.Windows.Forms.TextBox
    Friend WithEvents StyleComboBox As System.Windows.Forms.ComboBox
    Friend WithEvents CountryComboBox As System.Windows.Forms.ComboBox

End Class
