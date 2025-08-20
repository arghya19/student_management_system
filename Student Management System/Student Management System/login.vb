Public Class login
    Dim uname, upass As String
    Private Sub login_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.BackColor = System.Drawing.Color.Transparent
        Label2.BackColor = System.Drawing.Color.Transparent
        Label3.BackColor = System.Drawing.Color.Transparent

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        TextBox1.Text = ""
        TextBox1.Select()
        TextBox2.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        uname = TextBox1.Text
        upass = TextBox2.Text
        If uname = "admin" And upass = "admin" Then
            MessageBox.Show("Login Successfull!")
            TextBox1.Text = ""
            TextBox1.Select()
            TextBox2.Text = ""
            MenuPage.Show()
            Me.Hide()
        Else
            MessageBox.Show("Please enter again!")
        End If
    End Sub
End Class
