Imports SYSTEM.Data.SqlClient

Public Class DELETION
    Dim cn As New SqlConnection
    Dim da As New SqlDataAdapter
    Dim ds As New DataSet
    Dim dt As New DataTable
    Dim dr As DataRow
    Dim bm As BindingManagerBase

    Private Sub DELETION_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        cn = New SqlConnection ("Data Source=.;Initial Catalog=election;Persist Security Info=True;User ID=sa ")
        cn.Open()
        MsgBox("connected")
        Try
            da = New SqlDataAdapter(" select * from application ", cn)
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
        ComboBox1.Text = dr(2)
        TextBox3.Text = dr(3)
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim d As New SqlCommand
        Dim dr As SqlDataReader

        Try

            d = New SqlCommand(" delete from application where enroll= " & TextBox2.Text, cn)
            dr.Read()
            MsgBox("deleted")
            If dr!enroll = TextBox2.Text Then
                MsgBox("........")
            End If
        Catch ex As Exception
            MsgBox(ex.ToString)

        End Try
       
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        End
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Me.Close()
        Form1.Show()

    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        
    End Sub
End Class