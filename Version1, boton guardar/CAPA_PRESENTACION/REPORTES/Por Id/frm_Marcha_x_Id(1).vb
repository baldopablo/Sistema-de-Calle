Public Class frm_Marcha_x_Id

    Public id_competencia As Integer
    Private Sub frm_Marcha_x_Id_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim reportemarcha As New Marcha_x_Id
        reportemarcha.SetParameterValue("@Id_Competencia", id_competencia)
        CrystalReportViewer1.ReportSource = reportemarcha
    End Sub
End Class