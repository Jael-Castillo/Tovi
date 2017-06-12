Imports System.Data.OleDb
Public Class Almacen
    Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & _
     Application.StartupPath + "\Pisos.mdb")

    Private Sub Almacen_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub Almacen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            MsgBox("Conectado", vbInformation, "Correcto")

        Catch ex As Exception
            MsgBox("Error al conectar", vbInformation, "Sin conexion")

        End Try
        conn.Close()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim comando As New OleDbCommand
        conn.Open()
        Try
            comando = New OleDbCommand("INSERT INTO Almacen(Nombre, Material, Num_obra, Salida_mat)" & Chr(13) &
                                        "Values(TextBox1, TextBox2, TextBox3, TextBox4)", conn)

            comando.Parameters.AddWithValue("@Nombre", TextBox1.Text)
            comando.Parameters.AddWithValue("@Material", TextBox2.Text)
            comando.Parameters.AddWithValue("@Num_obra", TextBox3.Text)
            comando.Parameters.AddWithValue("@Salida_mat", TextBox4.Text)

            comando.ExecuteNonQuery()
            MsgBox("OK", vbInformation, "Correcto")

        Catch ex As Exception
            MsgBox("Error", vbInformation, "Sin conexion")
        End Try
        conn.Close()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()

        TextBox1.Focus()
    End Sub

    Dim omi As OleDbCommand
    Dim adaptador1 As New OleDbDataAdapter
    Dim registro1 As New DataSet
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        conn.Open()
        Dim consul As String
        Dim lista As Byte
        If TextBox1.Text = "" Then
            MsgBox("INGRESE REGISTRO PARA PODER ELIMINAR")
        ElseIf TextBox1.Text <> "" Then
            consul = "SELECT * FROM Almacen WHERE Nombre='" & TextBox1.Text & "'"
            adaptador1 = New OleDbDataAdapter(consul, conn)
            registro1 = New DataSet
            adaptador1.Fill(registro1, "Almacen")
            lista = registro1.Tables("Almacen").Rows.Count
            If lista <> 0 Then
                Dim eliminar As String
                Dim si As Byte
                si = MsgBox("¿ESTÁ SEGURO DE ELIMINAR EL REGISTRO?", vbYesNo, "ADVERTENCIA")
                If si = vbYes Then
                    eliminar = "DELETE FROM Almacen WHERE Nombre = '" & TextBox1.Text & " ' "
                    omi = New OleDbCommand(eliminar, conn)
                    omi.ExecuteNonQuery()
                    DataGridView1.Update()
                Else
                End If
            Else
                MsgBox("EL NOMBRE QUE DESEA ELIMINAR, NO EXISTE, FAVOR DE VERIFICARLO")
            End If
        End If
        conn.Close()
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        Dim buscar As String
        Dim adaptador As New OleDbDataAdapter
        Dim registro As New DataSet

        buscar = "SELECT * FROM Almacen"
        adaptador = New OleDbDataAdapter(buscar, conn)
        registro = New DataSet
        adaptador.Fill(registro, "Almacen")
        DataGridView1.DataSource = registro
        DataGridView1.DataMember = "Almacen"
    End Sub

    

    
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ACCESOS.Show()
        Me.Hide()
    End Sub

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        Existencias.Show()
        Me.Hide()

    End Sub
End Class