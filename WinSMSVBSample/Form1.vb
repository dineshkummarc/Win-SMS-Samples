Imports System.Net
Imports System.IO
Public Class Form1
    Inherits System.Windows.Forms.Form


    Function readHtmlPage(ByVal url As String) As String
        Dim objResponse As WebResponse
        Dim objRequest As WebRequest
        Dim result As String
        Try
            objRequest = System.Net.HttpWebRequest.Create(url)
            objResponse = objRequest.GetResponse()
            Dim sr As New StreamReader(objResponse.GetResponseStream())
            result = sr.ReadToEnd()
            'clean up StreamReader
            sr.Close()
            Return result
        Catch ex As Exception
            Dim s As String = ex.ToString
            If InStr(s, "(404)") Then
                Return "URL: " & url & " not found."
            Else
                Return s
            End If
        End Try
    End Function
#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents TBUserName As System.Windows.Forms.TextBox
    Friend WithEvents TBPassword As System.Windows.Forms.TextBox
    Friend WithEvents TBNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TBMessage As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.TBUserName = New System.Windows.Forms.TextBox()
        Me.TBPassword = New System.Windows.Forms.TextBox()
        Me.TBNumber = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.TBMessage = New System.Windows.Forms.TextBox()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(296, 264)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(96, 24)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Send"
        '
        'TBUserName
        '
        Me.TBUserName.Location = New System.Drawing.Point(120, 40)
        Me.TBUserName.Name = "TBUserName"
        Me.TBUserName.TabIndex = 1
        Me.TBUserName.Text = ""
        '
        'TBPassword
        '
        Me.TBPassword.Location = New System.Drawing.Point(120, 72)
        Me.TBPassword.Name = "TBPassword"
        Me.TBPassword.TabIndex = 2
        Me.TBPassword.Text = ""
        '
        'TBNumber
        '
        Me.TBNumber.Location = New System.Drawing.Point(120, 104)
        Me.TBNumber.Name = "TBNumber"
        Me.TBNumber.TabIndex = 3
        Me.TBNumber.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "User Name:"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Password:"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(8, 104)
        Me.Label3.Name = "Label3"
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Number: (2782...)"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(80, 24)
        Me.Label4.TabIndex = 8
        Me.Label4.Text = "Message"
        '
        'TBMessage
        '
        Me.TBMessage.Location = New System.Drawing.Point(120, 136)
        Me.TBMessage.Name = "TBMessage"
        Me.TBMessage.Size = New System.Drawing.Size(424, 20)
        Me.TBMessage.TabIndex = 9
        Me.TBMessage.Text = ""
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(568, 382)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.TBMessage, Me.Label4, Me.Label3, Me.Label2, Me.Label1, Me.TBNumber, Me.TBPassword, Me.TBUserName, Me.Button1})
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim MyString As String
        Dim TxUserName As String
        Dim TxPassword As String
        Dim TxMessage As String
        Dim TxNumber As String
        TxUserName = TBUserName.Text
        TxPassword = TBPassword.Text
        TxMessage = TBMessage.Text
        TxNumber = TBNumber.Text

        MyString = "http://www.winsms.net/api/batchmessage.asp?User="
        MyString = MyString & TxUserName & "&Password=" & TxPassword & "&Delivery=No"
        MyString = MyString & "&Message=" & TxMessage & "&Numbers=" & TxNumber & ";"
        MsgBox(readHtmlPage(MyString))
    End Sub
End Class
