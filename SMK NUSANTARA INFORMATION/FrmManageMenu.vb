Imports System.IO
Imports System.Data.SqlClient
Imports System.Drawing.Imaging
Public Class FrmManageMenu
    Dim databaru As Boolean
    Sub bersihkandata()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
    End Sub
    Sub tampilkandata()
        Dim da As SqlDataAdapter
        Dim ds As DataSet
        da = New SqlDataAdapter("SELECT * FROM menu", konek)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "menu")
        DataGridView1.DataSource = (ds.Tables("menu"))
    End Sub
    Sub jalankansql(ByVal sql As String)
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
    Private Sub FrmManageMenu_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_SMKNusantaraDataSet7.menu' table. You can move, or remove it, as needed.
        Me.MenuTableAdapter1.Fill(Me.DB_SMKNusantaraDataSet7.menu)
        'TODO: This line of code loads data into the 'DB_SMKNusantaraDataSet6.menu' table. You can move, or remove it, as needed.
        Me.MenuTableAdapter.Fill(Me.DB_SMKNusantaraDataSet6.menu)
        databaru = True

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim opf As New OpenFileDialog
        opf.Filter = "Choose Image(*.JPG;*.PNG;*.GIF)|*.jpg;*.png;*.gif"

        If opf.ShowDialog = DialogResult.OK Then
            TextBox4.Text = (opf.FileName)
            PictureBox1.Image = Image.FromFile(opf.FileName)
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim pesan As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Data belum lengkap!", vbExclamation)
            Exit Sub
        Else
            pesan = MsgBox("Apakah anda ingin melanjutkan menyimpan data ini?", vbYesNo + vbInformation)
            If pesan = vbNo Then
                Exit Sub
                TextBox1.Focus()
            End If
            Dim cmd As New SqlCommand("INSERT INTO menu (menuid,name,price,photo) VALUES (@menuid,@name,@price,@photo)", konek)
                Dim ms As New MemoryStream
                PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
                cmd.Parameters.Add("@menuid", SqlDbType.Int).Value = TextBox1.Text
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = TextBox2.Text
                cmd.Parameters.Add("@price", SqlDbType.Int).Value = TextBox3.Text
            cmd.Parameters.Add("@photo", SqlDbType.Image).Value = ms.ToArray
            If cmd.ExecuteNonQuery = 1 Then
                    MsgBox("Data berhasil disimpan!", vbInformation)
                bersihkandata()
                tampilkandata()
            Else
                    MsgBox("Gagal menyimpan!", vbExclamation)
                End If
                konek.Close()
                cmd.Dispose()
            End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pesan As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Silahkan cari data terlebih dahulu!", vbExclamation)
            Exit Sub
        Else
            pesan = MsgBox("Apakah anda ingin melanjutkan mengubah data ini?", vbYesNo + vbInformation)
            If pesan = vbNo Then
                Exit Sub
                TextBox1.Focus()
            End If
            Dim update As String = "UPDATE menu SET name = '" + TextBox2.Text + "', price = '" + TextBox3.Text + "', photo=@photo WHERE menuid = '" + TextBox1.Text + "'"
            Dim cmd As New SqlCommand(update, konek)
            Dim ms As New MemoryStream
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            Dim img As Byte()
            img = ms.ToArray
            cmd.Parameters.Add("@photo", SqlDbType.Image).Value = img
            If cmd.ExecuteNonQuery = 1 Then
                MsgBox("Data berhasil diubah!", vbInformation)
                bersihkandata()
                tampilkandata()
            Else
                MsgBox("Gagal mengubah", vbExclamation)
            End If
            konek.Close()
            cmd.Dispose()
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim sql As String
        konekdb()
        sql = "SELECT * FROM menu WHERE menuid = '" + TextBox1.Text + "'"
        cmd = New SqlCommand(sql, konek)
        rd = cmd.ExecuteReader
        rd.Read()

        If rd.HasRows = True Then
            TextBox1.Text = rd.Item(0)
            TextBox2.Text = rd.Item(1)
            TextBox3.Text = rd.Item(2)

        Else
            MsgBox("Data tidak ditemukan!", vbExclamation)
        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pesan As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Then
            MsgBox("Silahkan cari data terlebih dahulu!", vbExclamation)
            Exit Sub
        Else
            pesan = MsgBox("Apakah anda ingin melanjutkan menghapus data ini?", vbYesNo + vbInformation)
            If pesan = vbNo Then
                Exit Sub
                TextBox1.Focus()
            End If
            Dim hapus As String = "DELETE FROM menu WHERE menuid LIKE '" + TextBox1.Text + "'"
            Dim cmd As New SqlCommand(hapus, konek)
            Dim ms As New MemoryStream
            PictureBox1.Image.Save(ms, PictureBox1.Image.RawFormat)
            Dim img As Byte()
            img = ms.ToArray
            cmd.Parameters.Add("@photo", SqlDbType.Image).Value = img
            If cmd.ExecuteNonQuery = 1 Then
                MsgBox("Data berhasil dihapus!", vbInformation)
                bersihkandata()
                tampilkandata()
            Else
                MsgBox("Gagal mengubah", vbExclamation)
            End If
            konek.Close()
            cmd.Dispose()
        End If

    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        FrmAdminNav.Show()
        Me.Hide()
    End Sub
End Class