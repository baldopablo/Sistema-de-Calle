Public Class frm_Fondo_x_Id

    Public id_competencia As Integer

    Private Sub frm_Fondo_x_Id_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Dim reportefondo As New Fondo_x_Id
        reportefondo.SetParameterValue("@Id_Competencia", id_competencia)
        CrystalReportViewer1.ReportSource = reportefondo
    End Sub
End Class