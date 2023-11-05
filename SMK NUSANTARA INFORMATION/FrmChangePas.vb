Imports System.Data.SqlClient
Public Class FrmChangePas
    Private Sub jalankansql(ByVal sql As String)
        Dim sqlcmd As New SqlCommand
        Try
            konekdb()
            sqlcmd.Connection = konek
            sqlcmd.CommandType = CommandType.Text
            sqlcmd.CommandText = sql
            sqlcmd.ExecuteNonQuery()
            sqlcmd.Dispose()
            konek.Close()
        Catch ex As Exception
            MsgBox("error" & ex.Message)
        End Try
    End Sub
    Sub bersihkandata()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
    End Sub

    Private Sub FrmChangePas_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        konekdb()
        Dim ubah As String
        Dim uname, pass As String
        uname = login_form.TextBox1.Text
        pass = login_form.TextBox2.Text
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("data belum lengkap!", vbExclamation)
            Exit Sub
            TextBox1.Focus()
        ElseIf (TextBox1.Text <> pass) Then
            MsgBox("Invalid Old Password!", vbExclamation)
            bersihkandata()
            Exit Sub
            TextBox1.Focus()
        ElseIf (TextBox2.Text <> TextBox3.Text) Then
            MsgBox("New Password And Confirm Password didn't matched!", vbExclamation)
            TextBox2.Text = ""
            TextBox3.Text = ""
            Exit Sub
            TextBox2.Focus()
        Else
            ubah = "UPDATE account SET password = '" + TextBox3.Text + "' WHERE username = '" + uname + "'"
            jalankansql(ubah)
            MsgBox("Password berhasil diubah!", vbInformation)
            login_form.TextBox2.Text = TextBox3.Text
            bersihkandata()
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If FrmAdminNav.Label3.Text = "Administrator" Then
            FrmAdminNav.Show()
            Me.Hide()
        ElseIf FrmChefNav.label3.Text = "Chef" Then
            FrmChefNav.Show()
            Me.Hide()
        ElseIf FrmCashierNav.label3.Text = "Cashier" Then
            FrmCashierNav.Show()
            Me.Hide()
        ElseIf FrmCustomerNav.label3.Text = "Customer" Then
            FrmCustomerNav.show()
            Me.Hide()
        End If

    End Sub
End Class