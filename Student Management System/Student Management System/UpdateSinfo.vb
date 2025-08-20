Imports System.Data.SqlClient
Public Class UpdateSinfo
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim sql As String
    Dim nm, add, mob, gen, dob, email, cls As String

    Public Sub connect()
        con = New SqlConnection("Data Source=CSE_31\SQLEXPRESS;Initial Catalog=sms;Integrated Security=True")
        con.Open()
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
            add = ds.Tables(0).Rows(0)(2).ToString()
            mob = ds.Tables(0).Rows(0)(3).ToString()
            gen = ds.Tables(0).Rows(0)(4).ToString()
            dob = ds.Tables(0).Rows(0)(5).ToString()
            email = ds.Tables(0).Rows(0)(6).ToString()
            cls = ds.Tables(0).Rows(0)(7).ToString()
            Label11.Text = nm
            TextBox2.Text = nm
            TextBox4.Text = add
            TextBox3.Text = mob
            TextBox7.Text = dob
            TextBox6.Text = email
            TextBox5.Text = cls
            If gen = "Male" Then
                RadioButton1.Checked = True
            ElseIf gen = "Female" Then
                RadioButton2.Checked = True
            Else
                RadioButton3.Checked = True
            End If
            MessageBox.Show("Record Found!")
            Button2.Enabled = True
            Button4.Enabled = True
            Button1.Enabled = False
        Else
            MessageBox.Show("Record Not Found!")
        End If
        con.Close()
    End Sub

    Private Sub UpdateSinfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Button2.Enabled = False
        Button4.Enabled = False
        Label11.Text = ""
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
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
        If sname = "" Or sadd = "" Or smob = "" Or sgen = "" Or sdob = "" Or semail = "" Or sclass = "" Then
            MessageBox.Show("Enter values in all the fields!")
        Else
            connect()
            sql = "update sinfo set sname='" + sname + "',saddress='" + sadd + "',smob='" + smob + "',sgen='" + sgen + "',sdob='" + sdob + "',semail='" + semail + "',sclass='" + sclass + "' where sid='" + sid + "'"
            com = New SqlCommand(sql, con)
            If com.ExecuteNonQuery <> 0 Then
                MessageBox.Show("Record Updated Successfully!")
                aftupd()
            Else
                MessageBox.Show("Record Not Updated Successfully!")
            End If
            con.Close()
        End If

    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        aftupd()
    End Sub
    Public Sub aftupd()
        TextBox1.Text = ""
        TextBox1.Select()
        TextBox2.Text = ""
        TextBox4.Text = ""
        TextBox3.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        TextBox7.Text = ""
        Label11.Text = ""
        RadioButton1.Checked = False
        RadioButton2.Checked = False
        RadioButton3.Checked = False
        Button1.Enabled = True
        Button2.Enabled = False
        Button4.Enabled = False
    End Sub
End Class