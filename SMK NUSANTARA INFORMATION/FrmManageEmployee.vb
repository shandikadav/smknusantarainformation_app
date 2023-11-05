Imports System.Data.SqlClient
Public Class FrmManageEmployee
    Dim databaru As Boolean
    Sub tampilkandata()
        konekdb()
        Dim da As SqlDataAdapter
        Dim ds As DataSet
        da = New SqlDataAdapter("SELECT * FROM msemployee", konek)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "msemployee")
        DataGridView1.DataSource = (ds.Tables("msemployee"))
    End Sub

    Sub bersihkandata()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        ComboBox1.Text = ""
    End Sub
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
    Private Sub FrmManageEmployee_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_SMKNusantaraDataSet.msemployee' table. You can move, or remove it, as needed.
        Me.MsemployeeTableAdapter.Fill(Me.DB_SMKNusantaraDataSet.msemployee)
        TextBox1.MaxLength = 6
        TextBox2.MaxLength = 100
        TextBox3.MaxLength = 50
        TextBox4.MaxLength = 13
        ComboBox1.MaxLength = 50
        databaru = True
        tampilkandata()

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim pesan, simpan As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data belum lengkap!", vbInformation)
            TextBox1.Focus()
        Else
            If databaru Then
                pesan = MsgBox("Apakah anda ingin melanjutkan menyimpan data ini?", vbYesNo + vbInformation)
                If pesan = vbNo Then
                    Exit Sub
                End If
                simpan = "INSERT INTO msemployee(Employeeid,name,email,handphone,position)  VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & TextBox4.Text & "','" & ComboBox1.Text & "')"
                jalankansql(simpan)
                MsgBox("Data berhasil disimpan!", vbInformation)
                tampilkandata()
                bersihkandata()
            End If
        End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pesan, ubah As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data belum lengkap!", vbInformation)
            TextBox1.Focus()
        Else
            If databaru Then
                pesan = MsgBox("Apakah anda ingin melanjutkan mengubah data ini?", vbYesNo + vbInformation)
                If pesan = vbNo Then
                    Exit Sub
                End If
                ubah = "UPDATE msemployee SET Name = '" + TextBox2.Text + "', Email = '" + TextBox3.Text + "', Handphone = '" + TextBox4.Text + "', Position = '" + ComboBox1.Text + "' WHERE employeeid = '" + TextBox1.Text + "'"
                jalankansql(ubah)
                MsgBox("Data berhasil diubah!", vbInformation)
                tampilkandata()
                bersihkandata()
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim sql As String
        konekdb()
        sql = "SELECT * FROM msemployee WHERE employeeid = '" + TextBox1.Text + "'"
        cmd = New SqlCommand(sql, konek)
        rd = cmd.ExecuteReader
        rd.Read()

        If rd.HasRows = True Then
            TextBox1.Text = rd.Item(0)
            TextBox2.Text = rd.Item(1)
            TextBox3.Text = rd.Item(2)
            TextBox4.Text = rd.Item(4)
            ComboBox1.Text = rd.Item(5)
        Else
            MsgBox("Data tidak ditemukan!", vbExclamation)
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pesan, hapus As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Silahkan cari Datanya terlebih dahulu!", vbExclamation)
            TextBox1.Focus()
        Else
            If databaru Then
                pesan = MsgBox("Apakah anda ingin melanjutkan menghapus data ini?", vbYesNo + vbInformation)
                If pesan = vbNo Then
                    Exit Sub
                End If
                hapus = "DELETE FROM msemployee WHERE employeeid LIKE '" + TextBox1.Text + "'"
                jalankansql(hapus)
                MsgBox("Data berhasil dihapus!", vbInformation)
                tampilkandata()
                bersihkandata()
            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        FrmAdminNav.Show()
        Me.Hide()
    End Sub
End Class