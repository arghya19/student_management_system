Imports System.Data.SqlClient
Public Class DeleteStuMks
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim sql As String
    Dim nm, sub1, sub2, sub3, avg, grade, total As String

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sid As String = TextBox1.Text
        connect()
        sql = "delete from smarks where sid=@sid"
        com = New SqlCommand(sql, con)
        com.Parameters.AddWithValue("@sid", sid)
        If com.ExecuteNonQuery <> 0 Then
            MessageBox.Show("Record Deleted Successfully!")
            aftdel()
        Else
            MessageBox.Show("Try Again!")
        End If
        con.Close()

    End Sub

    Public Sub connect()
        con = New SqlConnection("Data Source=CSE_31\SQLEXPRESS;Initial Catalog=sms;Integrated Security=True")
        con.Open()
    End Sub
    Private Sub UpdateStuMks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = ""
        Label6.Text = ""
        Label7.Text = ""
        Label9.Text = ""
        Label11.Text = ""
        Label13.Text = ""
        Label15.Text = ""
        Button2.Enabled = False
        Button4.Enabled = False
    End Sub
    Public Sub aftdel()
        TextBox1.Text = ""
        TextBox1.Select()
        Button2.Enabled = False
        Button4.Enabled = False
        Button1.Enabled = True
        Label4.Text = ""
        Label6.Text = ""
        Label7.Text = ""
        Label9.Text = ""
        Label11.Text = ""
        Label13.Text = ""
        Label15.Text = ""
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sid As String
        sid = TextBox1.Text
        connect()
        sql = "select * from smarks where sid='" & sid & "'"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            nm = ds.Tables(0).Rows(0)(1).ToString()
            sub1 = ds.Tables(0).Rows(0)(2).ToString()
            sub2 = ds.Tables(0).Rows(0)(3).ToString()
            sub3 = ds.Tables(0).Rows(0)(4).ToString()
            avg = ds.Tables(0).Rows(0)(5).ToString()
            grade = ds.Tables(0).Rows(0)(6).ToString()
            total = ds.Tables(0).Rows(0)(7).ToString()
            Label4.Text = nm
            Label6.Text = sub1
            Label7.Text = sub2
            Label9.Text = sub3
            Label11.Text = avg
            Label13.Text = grade
            Label15.Text = total
            MessageBox.Show("Record Found!")
            Button2.Enabled = True
            Button4.Enabled = True
            Button1.Enabled = False
        Else
            MessageBox.Show("Record Not Found!")
        End If
        con.Close()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        aftdel()
    End Sub
End Class