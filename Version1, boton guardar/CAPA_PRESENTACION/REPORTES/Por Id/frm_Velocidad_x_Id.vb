Public Class frm_Velocidad_x_Id
    Public id_competencia As Integer

    Private Sub frm_Velocidad_x_Id_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim reportevelocidad As New Velocidad_x_Id
        reportevelocidad.SetParameterValue("@Id_Competencia", id_competencia)
        CrystalReportViewer1.ReportSource = reportevelocidad
    End Sub
End Class