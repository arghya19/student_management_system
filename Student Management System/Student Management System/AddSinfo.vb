Imports System.Data.SqlClient
Public Class AddSinfo
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim sql As String
    Public Sub connect()
        con = New SqlConnection("Data Source=CSE_31\SQLEXPRESS;Initial Catalog=sms;Integrated Security=True")
        con.Open()
    End Sub
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim sid, sname, sadd, smob, sgen, sdob, semail, sclass As String
        sid = TextBox1.Text
        sname = TextBox2.Text
        sadd = TextBox4.Text
        smob = TextBox3.Text
        sgen = ""
        If sname.Length <> 1 Then
            If RadioButton1.Checked = True Then
                sgen = "Male"
            ElseIf RadioButton2.Checked = True Then
                sgen = "Female"
            Else
                sgen = "Others"
            End If
        End If
        sdob = TextBox7.Text
        semail = TextBox6.Text
        sclass = TextBox5.Text
        If sid = "" Or sname = "" Or sadd = "" Or smob = "" Or sgen = "" Or sdob = "" Or semail = "" Or sclass = "" Then
            MessageBox.Show("Enter values in all the fields!")
        Else
            connect()
            sql = "select * from sinfo where sid='" & TextBox1.Text & "'"
            da = New SqlDataAdapter(sql, con)
            ds = New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                MessageBox.Show("Record Existed!")
                afterRec()
                con.Close()
            Else
                connect()
                sql = "insert into sinfo values('" & sid & "','" & sname & "','" & sadd & "','" & smob & "','" & sgen & "','" & sdob & "','" & semail & "','" & sclass & "')"
                com = New SqlCommand(sql, con)
                If com.ExecuteNonQuery <> 0 Then
                    MessageBox.Show("Record Inserted Successfully!")
                    afterRec()
                Else
                    MessageBox.Show("Record Not Inserted!")
                    afterRec()
                End If
                con.Close()
            End If
        End If
    End Sub
    Public Sub afterRec()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        afterRec()
    End Sub


End Class