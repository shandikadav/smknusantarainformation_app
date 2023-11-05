Imports System.Data.SqlClient
Public Class login_form
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        konekdb()
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim sql, user, pass As String
        If TextBox1.Text = "" Then
            MsgBox("Username belum terisi!", vbExclamation)
            TextBox1.Focus()
            Exit Sub
        ElseIf TextBox2.Text = "" Then
            MsgBox("Password belum diisi!", vbExclamation)
            TextBox1.Focus()
            Exit Sub
        End If
        user = TextBox1.Text
        pass = TextBox2.Text
        sql = "SELECT * FROM account WHERE username = '" + user + "' AND Password = '" + pass + "'"
        cmd = New SqlCommand(sql, konek)
        rd = cmd.ExecuteReader
        rd.Read()
        If rd.HasRows = True Then
            If rd.Item(0).ToString = "admin" Then
                MsgBox("Login Admin berhasil!", vbInformation)
                FrmAdminNav.Label3.Text = rd.Item(2)
                FrmAdminNav.Show()
                Me.Hide()
            ElseIf rd.Item(0).ToString = "chef" Then
                MsgBox("Login Chef berhasil!", vbInformation)
                FrmChefNav.Label3.Text = rd.Item(2)
                FrmChefNav.Show()
                Me.Hide()
            ElseIf rd.Item(0).ToString = "cashier" Then
                MsgBox("Login Cashier berhasil!", vbInformation)
                FrmCashierNav.Label3.Text = rd.Item(2)
                FrmCashierNav.Show()
                Me.Hide()
            ElseIf rd.Item(0).ToString = "customer" Then
                MsgBox("Login Customer berhasil!", vbInformation)
                FrmCustomerNav.Label3.Text = rd.Item(2)
                FrmCustomerNav.Show()
                Me.Hide()
            End If
        Else
            MessageBox.Show("Login Gagal, silahkan coba lagi!", "Informasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            TextBox1.Text = ""
            TextBox2.Text = ""
        End If
    End Sub

    Private Sub login_form_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.Checked Then
            TextBox2.Text = ""
        Else
            TextBox2.Text = "*"
        End If
    End Sub
End Class
