Imports System.IO
Imports System.Drawing.Imaging
Imports System.Data.SqlClient
Public Class FrmOrder
    Dim price, qty As String
    Private Sub FrmOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'DB_SMKNusantaraDataSet9.menu' table. You can move, or remove it, as needed.
        Me.MenuTableAdapter1.Fill(Me.DB_SMKNusantaraDataSet9.menu)
        'TODO: This line of code loads data into the 'DB_SMKNusantaraDataSet8.menu' table. You can move, or remove it, as needed.
        Me.MenuTableAdapter.Fill(Me.DB_SMKNusantaraDataSet8.menu)

    End Sub

    Private Sub DataGridView1_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Dim sql As String


        konekdb()
        Dim x, y As Integer
        sql = "SELECT * FROM menu WHERE name = '" + DataGridView1.Rows(x).Cells(y).Value + "'"
        Dim cmd As New SqlCommand(sql, konek)
        Dim rd As SqlDataReader = cmd.ExecuteReader
        rd.Read()
        Dim img As Byte() = DirectCast(rd.Item(3), Byte())
        Dim ms As MemoryStream = New MemoryStream(img)


        If rd.HasRows = True Then
            If DataGridView1.Rows(x).Cells(y).Value Then
                TextBox1.Text = rd.Item(1)
                TextBox2.Text = rd.Item(2)
            End If
            PictureBox1.Image = Image.FromStream(ms)
        Else
            MsgBox("Data tidak ditemukan!", vbExclamation)
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged
        price = TextBox2.Text
        qty = ComboBox1.Text
        If ComboBox1.Text = "1" Then
            TextBox2.Text = qty * price
        ElseIf ComboBox1.Text = "2" Then
            TextBox2.Text = qty * price
        ElseIf ComboBox1.Text = "3" Then
            TextBox2.Text = qty * price
        ElseIf ComboBox1.Text = "4" Then
            TextBox2.Text = qty * price
        ElseIf ComboBox1.Text = "5" Then
            TextBox2.Text = qty * price
        ElseIf ComboBox1.Text = "6" Then
            TextBox2.Text = qty * price
        ElseIf ComboBox1.Text = "7" Then
            TextBox2.Text = qty * price
        ElseIf ComboBox1.Text = "8" Then
            TextBox2.Text = qty * price
        ElseIf ComboBox1.Text = "9" Then
            TextBox2.Text = qty * price
        ElseIf ComboBox1.Text = "10" Then
            TextBox2.Text = qty * price
        End If
    End Sub
End Class