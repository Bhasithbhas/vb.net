Imports System.Data.SqlClient


Public Class Form2
    Dim cn As New SqlConnection
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim bm As BindingManagerBase


    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection(" Data Source=.;Initial Catalog=election;Persist Security Info=True;User ID=sa")
        cn.Open()
        MsgBox(" connected")
        Try
            da = New SqlDataAdapter(" select * from application", cn)
            ds = New DataSet(" application")
            da.Fill(ds, "application")
            dt = ds.Tables("application")
            bm = Me.BindingContext(ds, "application")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub disp()
        dr = dt.Rows.Item(bm.Position)
        TextBox1.Text = dr(0)
        TextBox2.Text = dr(1)
        TextBox3.Text = dr(2)
        MonthCalendar1.SelectionRange = dr(3)

        TextBox4.Text = dr(4)
        TextBox5.Text = dr(5)
        If RadioButton1.Checked = True Then
            RadioButton1.Text = dr(6)
        ElseIf RadioButton2.Checked = True Then
            RadioButton2.Text = dr(7)

        Else
            RadioButton3.Text = dr(8)

        End If

        TextBox6.Text = dr(9)
        ComboBox1.Text = dr(10)
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        MonthCalendar1.Refresh()

        TextBox4.Clear()
        TextBox5.Clear()
        RadioButton1.Text = "MALE"
        RadioButton2.Text = "FEMALE"
        RadioButton3.Text = "OTHERS"
        TextBox6.Clear()
        ComboBox1.Text = "  "



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim s As New SqlCommand
        Try
            s = New SqlCommand(" insert into application values ('" & TextBox1.Text & " ','" & TextBox2.Text & " ',' " & TextBox3.Text & " ' ," & MonthCalendar1.MinDate & " , " & TextBox4.Text & " , ' " & TextBox5.Text & " ' , ' " & RadioButton1.Text & " ', " & TextBox6.Text & " , '" & ComboBox1.Text & " ' )", cn)
            s.ExecuteNonQuery()
            MsgBox(" inserted ")
        Catch ex As Exception
            MsgBox(ex.ToString)




        
        End Try
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
        Form1.Show()

    End Sub
End Class