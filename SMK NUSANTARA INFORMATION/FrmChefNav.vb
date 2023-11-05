Public Class FrmChefNav
    Private Sub FrmChefNav_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label3.Text = "[Chef Name]"
        login_form.TextBox1.Text = ""
        login_form.TextBox2.Text = ""
        login_form.Show()
        Me.Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmViewOrder.Show()
        Me.Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FrmChangePas.Show()
        Me.Hide()
    End Sub
End Class