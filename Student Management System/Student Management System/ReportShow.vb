Imports System.Data.SqlClient
Public Class ReportShow
    Dim con As SqlConnection
    Dim com As SqlCommand
    Dim da As SqlDataAdapter
    Dim ds As DataSet
    Dim sql As String
    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.Hide()
        MenuPage.Show()
    End Sub
    Public Sub connect()
        con = New SqlConnection("Data Source=CSE_31\SQLEXPRESS;Initial Catalog=sms;Integrated Security=True")
        con.Open()
    End Sub
    Private Sub ReportShow_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        connect()
        sql = "select * from smarks"
        da = New SqlDataAdapter(sql, con)
        ds = New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            DataGridView1.DataSource = ds.Tables(0)
        Else
            DataGridView1.DataSource = Nothing
            MessageBox.Show("Records Not Found!")
        End If
        con.Close()
    End Sub
End Class