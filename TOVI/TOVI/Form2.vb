Imports System.Data.OleDb
Public Class Form2
    Dim conn As New OleDb.OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data source=" & _
     Application.StartupPath + "\Pisos.mdb")

    Private Sub Form2_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        End
    End Sub

    Private Sub Form2_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Try
            conn.Open()
            MsgBox("Conectado", vbInformation, "Correcto")

        Catch ex As Exception
            MsgBox("Error al conectar", vbInformation, "Sin conexion")

        End Try
        conn.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

        Dim comando As New OleDbCommand
        conn.Open()
        Try
            comando = New OleDbCommand("INSERT INTO Nomina(Nombre, Dias, Costo_d, Fecha, Horas, Costo, Prestaciones, Total, Obra, Clave)" & Chr(13) &
                                        "Values(TextBox1, TextBox2, TextBox9, TextBox3, TextBox4, TextBox5, TextBox6, TextBox7, TextBox8, TextBox13)", conn)

            comando.Parameters.AddWithValue("@Nombre", TextBox1.Text)
            comando.Parameters.AddWithValue("@Dias", TextBox2.Text)
            comando.Parameters.AddWithValue("@Costo_d", TextBox9.Text)
            comando.Parameters.AddWithValue("@Fecha", TextBox3.Text)
            comando.Parameters.AddWithValue("@Horas", TextBox4.Text)
            comando.Parameters.AddWithValue("@Costo", TextBox5.Text)
            comando.Parameters.AddWithValue("@Prestaciones", TextBox6.Text)
            comando.Parameters.AddWithValue("@Total", TextBox7.Text)
            comando.Parameters.AddWithValue("@Obra", TextBox8.Text)
            comando.Parameters.AddWithValue("@Clave", TextBox13.Text)
            comando.ExecuteNonQuery()
            MsgBox("OK", vbInformation, "Correcto")

        Catch ex As Exception
            MsgBox("Error", vbInformation, "Sin conexion")
        End Try
        conn.Close()


       

    End Sub

   
   

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox1.Focus()


    End Sub

    Dim omi As OleDbCommand
    Dim adaptador1 As New OleDbDataAdapter
    Dim registro1 As New DataSet

    Private Sub Button8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button8.Click
        conn.Open()
        Dim consul As String
        Dim lista As Byte
        If TextBox13.Text = "" Then
            MsgBox("INGRESE REGISTRO PARA PODER ELIMINAR")
        ElseIf TextBox13.Text <> "" Then
            consul = "SELECT * FROM Nomina WHERE Clave='" & TextBox13.Text & "'"
            adaptador1 = New OleDbDataAdapter(consul, conn)
            registro1 = New DataSet
            adaptador1.Fill(registro1, "Nomina")
            lista = registro1.Tables("Nomina").Rows.Count
            If lista <> 0 Then
                Dim eliminar As String
                Dim si As Byte
                si = MsgBox("¿ESTÁ SEGURO DE ELIMINAR EL REGISTRO?", vbYesNo, "ADVERTENCIA")
                If si = vbYes Then
                    eliminar = "DELETE FROM Nomina WHERE Clave = '" & TextBox13.Text & " ' "
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

    Private Sub Button9_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button9.Click
        Dim buscar As String
        Dim adaptador As New OleDbDataAdapter
        Dim registro As New DataSet

        buscar = "SELECT * FROM Nomina"
        adaptador = New OleDbDataAdapter(buscar, conn)
        registro = New DataSet
        adaptador.Fill(registro, "Nomina")
        DataGridView1.DataSource = registro
        DataGridView1.DataMember = "Nomina"
    End Sub

    Dim registro3 As New DataSet
    Dim dt As New OleDbDataAdapter
    

    Private Sub Button10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button10.Click
        Button11.Visible = True
        Button10.Visible = False
        MsgBox("INGRESA LOS NUEVOS DATOS")
        TextBox13.Enabled = False
        TextBox14.Visible = True
        Button12.Visible = True



        conn.Open()
        Dim own As String
        own = "SELECT * FROM Nomina WHERE Clave = '" & TextBox13.Text & "'"
        dt = New OleDbDataAdapter(own, conn)
        registro3 = New DataSet
        dt.Fill(registro3, "Nomina")
        For Each cuenta As DataRow In registro3.Tables("Nomina").Rows
            TextBox1.Text = cuenta.Item("Nombre")
            TextBox2.Text = cuenta.Item("Dias")
            TextBox9.Text = cuenta.Item("Costo_d")
            TextBox3.Text = cuenta.Item("Fecha")
            TextBox4.Text = cuenta.Item("Horas")
            TextBox5.Text = cuenta.Item("Costo")
            TextBox6.Text = cuenta.Item("Prestaciones")
            TextBox7.Text = cuenta.Item("Total")
            TextBox8.Text = cuenta.Item("Obra")
            TextBox14.Clear()
        Next



            
        conn.Close()


    End Sub

    Dim registro2 As New DataSet
    Dim adaptador As New OleDbDataAdapter
    Dim comi As New OleDbCommand

    Private Sub Button11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button11.Click
        conn.Open()
        If TextBox13.Text = "" Then
            MsgBox("INGRESA NÚMERO DE CLAVE")
        Else

            Button11.Visible = False
            Button10.Visible = True
            TextBox13.Enabled = True
            TextBox14.Visible = False
            Button12.Visible = False


            Dim Consul As String
            Dim lista As Byte


            Consul = "SELECT * FROM Nomina WHERE Clave='" & TextBox13.Text & "'"
            adaptador = New OleDbDataAdapter(Consul, conn)
            registro2 = New DataSet
            adaptador.Fill(registro2, "Nomina")
            lista = registro2.Tables("Nomina").Rows.Count
            If lista <> 0 Then
                Dim modificar As String
                modificar = "UPDATE Nomina SET Nombre= '" & TextBox1.Text &
                    "', Dias = '" & TextBox2.Text &
                    "', Costo_d = '" & TextBox9.Text &
                    "', Fecha = '" & TextBox3.Text &
                    "', Horas = '" & TextBox4.Text &
                    "', Costo = '" & TextBox5.Text &
                    "', Prestaciones = '" & TextBox6.Text &
                    "', Total= '" & TextBox7.Text &
                    "', Obra = '" & TextBox8.Text &
                    "', Clave = '" & TextBox14.Text &
                    "' WHERE Clave='" & TextBox13.Text & "'"
                comi = New OleDbCommand(modificar, conn)
                comi.ExecuteNonQuery()

            Else
                MsgBox("NO HAY REGISTRO EXISTENTE")
            End If

        End If
        conn.Close()

    End Sub

   
    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        ACCESOS.Show()
        Me.Hide()
    End Sub


    Private Sub Button12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button12.Click
        TextBox1.Clear()
        TextBox2.Clear()
        TextBox3.Clear()
        TextBox4.Clear()
        TextBox5.Clear()
        TextBox6.Clear()
        TextBox7.Clear()
        TextBox8.Clear()
        TextBox9.Clear()
        TextBox12.Clear()
        TextBox13.Clear()
        TextBox14.Clear()
        TextBox1.Focus()

        Button11.Visible = False
        Button10.Visible = True
        TextBox13.Enabled = True
        TextBox14.Visible = False
        Button12.Visible = False

    End Sub

  
    
    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        TextBox12.Text = (Val(TextBox2.Text) * Val(TextBox9.Text)) + (Val(TextBox4.Text) * Val(TextBox5.Text))
        TextBox7.Text = (TextBox12.Text - (TextBox12.Text * TextBox6.Text))

    End Sub
End Class