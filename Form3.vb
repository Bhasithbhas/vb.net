Imports System.Data.sqlclient
Public Class Form3
    Dim cn As New SqlConnection
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim bm As BindingManagerBase



    Private Sub Form3_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection("Data Source=.;Initial Catalog=election;Persist Security Info=True;User ID=sa ")
        cn.Open()
        MsgBox(" connected")
        Try
            da = New SqlDataAdapter(" select * from candidates", cn)
            ds = New DataSet(" candidates")
            da.Fill(ds, "candidates")
            dt = ds.Tables("candidates")
            bm = Me.BindingContext(ds, "candidates")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
    Sub disp()
        dr = dt.Rows.Item(bm.Position)
        TextBox1.Text = dr(0)
        TextBox2.Text = dr(1)
        ComboBox2.Text = dr(2)
        TextBox4.Text = dr(3)

        If RadioButton1.Checked = True Then
            RadioButton1.Text = dr(4)
        ElseIf RadioButton2.Checked = True Then
            RadioButton2.Text = dr(5)

        Else
            RadioButton3.Text = dr(6)
        End If

        TextBox5.Text = dr(7)
        ComboBox1.Text = dr(8)



    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim s As New SqlCommand
        'Try
        s = New SqlCommand(" insert into candidates values ( ' " & TextBox1.Text & " ' , ' " & TextBox2.Text & " ' , ' " & ComboBox2.Text & " ' ,  " & TextBox4.Text & "  , ' " & RadioButton1.Text & " ' , ' " & TextBox5.Text & " ' , ' " & ComboBox1.Text & " ' ) ", cn)
        s.ExecuteNonQuery()
        MsgBox(" inserted")

        'Catch ex As Exception
        'MsgBox(ex.ToString)

        'End Try

    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        ComboBox2.Text = ""
        TextBox4.Clear()
        RadioButton1.Text = "MALE"
        RadioButton2.Text = "FEMALE"
        RadioButton3.Text = "OTHERS"
        TextBox5.Clear()
        ComboBox1.Text = " "





    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        End
    End Sub
End Class
