Public Class FrmEmployeeNav
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        login_form.TextBox1.Text = ""
        login_form.TextBox2.Text = ""
        login_form.Show()
        Me.Hide()
    End Sub
End Class