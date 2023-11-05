Imports System.Data.SqlClient
Public Class FrmMember
    Dim databaru As Boolean
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

    Sub tampilkandata()
        konekdb()
        Dim da As SqlDataAdapter
        Dim ds As DataSet
        da = New SqlDataAdapter("SELECT * FROM msmember", konek)
        ds = New DataSet
        ds.Clear()
        da.Fill(ds, "msmember")
        DataGridView1.DataSource = (ds.Tables("msmember"))
    End Sub
    Private Sub FrmMember_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_SMKNusantaraDataSet5.msmember' table. You can move, or remove it, as needed.
        Me.MsmemberTableAdapter1.Fill(Me.DB_SMKNusantaraDataSet5.msmember)
        'TODO: This line of code loads data into the 'DB_SMKNusantaraDataSet2.msmember' table. You can move, or remove it, as needed.
        Me.MsmemberTableAdapter.Fill(Me.DB_SMKNusantaraDataSet2.msmember)
        databaru = True
        tampilkandata()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim pesan, simpan As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Data belum lengkap!", vbExclamation)
            Exit Sub
            TextBox1.Focus()
        Else
            If databaru Then
                pesan = MsgBox("Apakah Anda yakin ingin melanjutkan menyimpan data ini?", vbYesNo + vbInformation)
                If pesan = vbNo Then
                    Exit Sub
                    TextBox1.Focus()
                End If
                simpan = "INSERT INTO msmember(memberid,name,email,joindate) VALUES('" & TextBox1.Text & "','" & TextBox2.Text & "','" & TextBox3.Text & "','" & Today & "')"
                jalankansql(simpan)
                MsgBox("Data berhasil disimpan!", vbInformation)
                bersihkandata()
                tampilkandata()

            End If
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        Dim cmd As SqlCommand
        Dim rd As SqlDataReader
        Dim sql As String
        konekdb()
        sql = "SELECT * FROM msmember WHERE memberid = '" + TextBox1.Text + "'"
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

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim pesan, ubah As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Data belum lengkap!", vbExclamation)
            Exit Sub
            TextBox1.Focus()
        Else
            If databaru Then
                pesan = MsgBox("Apakah Anda yakin ingin melanjutkan mengubah data ini?", vbYesNo + vbInformation)
                If pesan = vbNo Then
                    Exit Sub
                    TextBox1.Focus()
                End If
                ubah = "UPDATE msmember SET name = '" + TextBox2.Text + "', email = '" + TextBox3.Text + "', joindate = '" + Today + "' WHERE memberid = '" + TextBox1.Text + "'"
                jalankansql(ubah)
                MsgBox("Data berhasil diubah!", vbInformation)
                bersihkandata()
                tampilkandata()
            End If
        End If

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim pesan, hapus As String
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Then
            MsgBox("Silahkan cari data yang ingin dihapus terlebih dahulu!", vbExclamation)
            Exit Sub
            TextBox1.Focus()
        Else
            If databaru Then
                pesan = MsgBox("Apakah Anda yakin ingin melanjutkan menghapus data ini?", vbYesNo + vbInformation)
                If pesan = vbNo Then
                    Exit Sub
                    TextBox1.Focus()
                End If
                hapus = "DELETE FROM msmember WHERE memberid LIKE '" + TextBox1.Text + "'"
                jalankansql(hapus)
                MsgBox("Data berhasil dihapus!", vbInformation)
                bersihkandata()
                tampilkandata()
            End If
        End If

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FrmAdminNav.Show()
        Me.Hide()
    End Sub
End Class