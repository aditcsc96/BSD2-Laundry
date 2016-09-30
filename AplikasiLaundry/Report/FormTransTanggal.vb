Public Class FormTransTanggal

    Private Sub FormTransTanggal_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        FormUtama.ChildNumber -= 1
    End Sub
End Class