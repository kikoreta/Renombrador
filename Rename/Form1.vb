Imports System.IO

Public Class Form1

    Public Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Dim Carpeta = TextBox1.Text
        Dim ExtArch = "*." + TextBox2.Text
        Dim Nombre = TextBox4.Text
        Dim ExtDesead = "." + TextBox3.Text
        Dim ArchTotal = 0
        Dim Contador1 As Integer = 0
        Dim Contador1a As String
        Dim Contador2 As Integer = 0
        Dim Contador2a As String

        ArchTotal = Directory.GetFiles(Carpeta, ExtArch).Count

        For Each archivo In My.Computer.FileSystem.GetFiles(Carpeta, FileIO.SearchOption.SearchTopLevelOnly, ExtArch)

            Dim directorio = Path.GetDirectoryName(archivo) + "\"
            Dim NombArch = Path.GetFileNameWithoutExtension(archivo)
            Dim arch01 = directorio + Nombre + Mid(NombArch, Nombre.Length + 1) + ExtDesead
            Contador1 = Contador1 + 1

            Select Case ArchTotal
                Case Is <= 100
                    Contador1a = Contador1.ToString("00")
                Case Is <= 1000
                    Contador1a = Contador1.ToString("000")
                Case Is <= 10000
                    Contador1a = Contador1.ToString("0000")
                Case Else
                    Contador1a = Contador1.ToString("0")
                    Exit Select
            End Select

            Select Case File.Exists(arch01)
                Case True
                    GoTo Cont2
                Case False
                    My.Computer.FileSystem.RenameFile(archivo, Nombre + Contador1a + ExtDesead)
                    GoTo Fin
            End Select

Cont2:
            Contador2 = Contador2 + 1
            Contador2a = Contador2.ToString("00")
            Dim arch02 = directorio + Nombre + Contador1a + "-" + Contador2a + ExtDesead
            Select Case File.Exists(arch02)
                Case True
                    GoTo Cont2
                Case False
                    My.Computer.FileSystem.RenameFile(archivo, Nombre + Contador1a + "-" + Contador2a + ExtDesead)
                    Contador2 = 0
            End Select
Fin:
        Next

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim browfolder As New FolderBrowserDialog
        If (browfolder.ShowDialog() = DialogResult.OK) Then

            TextBox1.Text = browfolder.SelectedPath
        End If
    End Sub

End Class
