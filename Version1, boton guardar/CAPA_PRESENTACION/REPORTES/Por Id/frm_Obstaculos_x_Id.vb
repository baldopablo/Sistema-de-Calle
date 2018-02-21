Public Class frm_Obstaculos_x_Id

    Public id_competencia As Integer

    Private Sub frm_Obstaculos_x_Id_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim reporteobstaculos As New Obstaculos_x_Id
        reporteobstaculos.SetParameterValue("@Id_Competencia", id_competencia)
        CrystalReportViewer1.ReportSource = reporteobstaculos
    End Sub
End Class