﻿Public Class FrmCustomerNav
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Label3.Text = "[Customer Name]"
        login_form.TextBox1.Text = ""
        login_form.TextBox2.Text = ""
        login_form.Show()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmOrder.Show()
        Me.Hide()
    End Sub
End Class