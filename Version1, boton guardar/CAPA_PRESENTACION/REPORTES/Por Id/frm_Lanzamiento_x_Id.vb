Public Class frm_Lanzamiento_x_Id

    Public id_competencia As Integer

    Private Sub frm_Lanzamiento_x_Id_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim reportelanzamiento As New Lanzamiento_x_Id
        reportelanzamiento.SetParameterValue("@Id_Competencia", id_competencia)
        CrystalReportViewer1.ReportSource = reportelanzamiento
    End Sub
End Class