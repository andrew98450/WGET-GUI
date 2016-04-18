Imports System.Net
Public Class Form1
    Public WithEvents web As New WebClient
    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        SaveFileDialog2.ShowDialog()
        TextBox2.Text = SaveFileDialog2.FileName
    End Sub
   
    Private Sub Button1_Click(ByVal sender As Object , ByVal e As EventArgs) Handles Button1.Click
        Try
            RichTextBox1.Text += "GET Time: " + Date.Now.ToString + vbCrLf
            RichTextBox1.Text += "GET : " + TextBox1.Text + " To " + TextBox2.Text + " Downloading..." + vbCrLf
            web.DownloadFileAsync(New Uri(TextBox1.Text), TextBox2.Text)
        Catch ex As Exception
            RichTextBox1.Text += "GET Fail....."
        End Try
    End Sub
    Private Sub web_DownloadFileCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles web.DownloadFileCompleted
    End Sub
    Private Sub web_DownloadProgressChanged(sender As Object, e As DownloadProgressChangedEventArgs) Handles web.DownloadProgressChanged
        ProgressBar1.Value = e.ProgressPercentage
        Label2.Text = "Download Status: " & e.BytesReceived.ToString / 1000000 & " MB / " & e.TotalBytesToReceive.ToString / 1000000 & " MB"
        Label4.Text = ProgressBar1.Value & "%"
        If ProgressBar1.Value = 100 Then
            RichTextBox1.Text += "GET Successfly....." + vbCrLf
        End If
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        SaveFileDialog1.ShowDialog()
        TextBox3.Text = SaveFileDialog1.FileName
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        My.Computer.FileSystem.WriteAllText(TextBox3.Text, RichTextBox1.Text, False)
        MessageBox.Show("Successfly Save Log File Path: " + TextBox3.Text)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        TextBox3.Text = My.Computer.FileSystem.SpecialDirectories.Desktop + "\Log.txt"
        SaveFileDialog1.Filter = "*.txt|*.txt|*.all|*.*"
        SaveFileDialog2.Filter = "*.all|*.*"
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        RichTextBox1.Text = ""
    End Sub
End Class
