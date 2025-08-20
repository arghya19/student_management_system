Imports System.Data.SqlClient
Public Class UpdateStuMks
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim sql As String
    Dim nm As String
    Public Sub connect()
        con = New SqlConnection("Data Source=CSE_31\SQLEXPRESS;Initial Catalog=sms;Integrated Security=True")
        con.Open()
    End Sub
    Private Sub UpdateStuMks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label4.Text = ""
        Button2.Enabled = False
        Button4.Enabled = False
    End Sub
    Public Sub aftupd()
        TextBox1.Text = ""
        TextBox1.Select()
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        Button2.Enabled = False
        Button4.Enabled = False
        Button1.Enabled = True
        Label4.Text = ""
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        aftupd()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sid As String
        sid = TextBox1.Text
        connect()
        sql = "select * from sinfo where sid='" & sid & "'"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            nm = ds.Tables(0).Rows(0)(1).ToString()
            Label4.Text = nm
            MessageBox.Show("Record Found!")
            Button2.Enabled = True
            Button4.Enabled = True
            Button1.Enabled = False
        Else
            MessageBox.Show("Record Not Found!")
        End If
        con.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim sid, sub1, sub2, sub3, grade, avgStr, totalStr As String
        Dim avg, total As Integer
        sid = TextBox1.Text
        sub1 = TextBox2.Text
        sub2 = TextBox3.Text
        sub3 = TextBox4.Text
        grade = ""
        If sub1 = "" Or sub2 = "" Or sub3 = "" Then
            MessageBox.Show("Enter values in all the fields!")
        Else
            avg = (Val(sub1) + Val(sub2) + Val(sub3)) / 3
            total = Val(sub1) + Val(sub2) + Val(sub3)
            avgStr = avg.ToString()
            totalStr = total.ToString()
            If avg < 40 Then
                grade = "Fail"
            ElseIf avg >= 40 And avg < 50 Then
                grade = "D"
            ElseIf avg >= 50 And avg < 60 Then
                grade = "C"
            ElseIf avg >= 60 And avg < 70 Then
                grade = "B"
            ElseIf avg >= 70 And avg < 80 Then
                grade = "A"
            ElseIf avg >= 80 And avg < 90 Then
                grade = "A+"
            Else
                grade = "E"
            End If
            connect()
            sql = "update smarks set sub1=@sub1, sub2=@sub2, sub3=@sub3,average=@avgStr,grade=@grade,total =@totalStr where sid=@sid"
            com = New SqlCommand(sql, con)
            com.Parameters.AddWithValue("@sid", sid)
            com.Parameters.AddWithValue("@sub1", sub1)
            com.Parameters.AddWithValue("@sub2", sub2)
            com.Parameters.AddWithValue("@sub3", sub3)
            com.Parameters.AddWithValue("@avgStr", avgStr)
            com.Parameters.AddWithValue("@grade", grade)
            com.Parameters.AddWithValue("@totalStr", totalStr)
            If com.ExecuteNonQuery <> 0 Then
                MessageBox.Show("Record Updated Successfully!")
                aftupd()
            Else
                MessageBox.Show("Record Not Updated Successfully!")
            End If
            con.Close()
        End If
    End Sub
End Class