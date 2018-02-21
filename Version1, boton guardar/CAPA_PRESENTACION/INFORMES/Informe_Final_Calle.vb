Imports System.Data
Imports System.Data.SqlClient
Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD

Public Class Informe_Final_Calle

    Private dcu As SqlDataAdapter
    Private dor As SqlDataAdapter
    Private ds As DataSet
    Private cn As SqlConnection
    Private str As String

    Dim capanegocio As New CNCompetencias

    Private Sub Informe_Final_Calle_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()

        'crear conexion
        cn = New SqlConnection
        str = "Data Source=VALE\VALERIA;Initial Catalog=TESIS ATLETISMO 2016;Integrated Security=True"
        cn.ConnectionString = str

        ' creamos los adaptadores
        dcu = New SqlDataAdapter("select Nombre_Competencia as 'Nombre',Lugar_Competencia as 'Lugar',Distancia,Fecha_Inicio as 'Fecha',Hora_Inicio as 'Hora' ,Id_Competencia from Competencia where Distancia<>0 order by Fecha_Inicio desc", cn)
        dor = New SqlDataAdapter("SELECT dbo.Atleta.Dorsal,dbo.Atleta.Nombre_Atleta as 'Nombre',dbo.Atleta.Apellido_Atleta as 'Apellido',dbo.Sexo.Sexo,DATEDIFF (year,dbo.Atleta.Fecha_Nacimiento, GETDATE()) as Edad,Localidad.Nombre_Localidad as 'Localidad',dbo.Atleta.Otra_Institución as 'Representa a',dbo.Atleta.Id_Atleta as 'Código',dbo.Resultados_X_Competencia.Mejor as 'Mejor Tiempo',dbo.Resultados_X_Competencia.Posicion as 'Posición',dbo.Atleta_X_Competencia.Id_Competencia FROM dbo.Competencia INNER JOIN dbo.Atleta_X_Competencia ON dbo.Competencia.Id_Competencia = dbo.Atleta_X_Competencia.Id_Competencia INNER JOIN dbo.Atleta ON dbo.Atleta_X_Competencia.Id_Atleta = dbo.Atleta.Id_Atleta inner join Sexo on Atleta.Id_Sexo=sexo.Id_sexo inner join Resultados_X_Competencia on Atleta_X_Competencia.Id_Resultados_X_Competencia=Resultados_X_Competencia.Id_Resultados_X_Competencia inner join Localidad on Localidad.Id_Localidad=Atleta.Id_Localidad where Distancia<>0 and posicion<>0 order by Fecha_Inicio desc", cn)

        'seteamos
        ds = New DataSet
        cn.Open()
        dcu.Fill(ds, "Competencia")
        dor.Fill(ds, "Atletas")
        cn.Close()

        ' relacionar las dos tablas del dataset por campo comun
        ds.Relations.Add("Competencia_Atletas", _
        ds.Tables("Competencia").Columns("Id_Competencia"), _
        ds.Tables("Atletas").Columns("Id_Competencia"))

        'asignar al datagrid maestro la tabla competencia
        Me.dgvInformeFinalCalle.DataSource = ds
        Me.dgvInformeFinalCalle.DataMember = "Competencia"


        'asignar al datagridview detalles la relacion ue acabamos de crear por codigo
        Me.dgvCompetenciaCalle.DataSource = ds
        Me.dgvCompetenciaCalle.DataMember = "Competencia.Competencia_Atletas"
        'Me.lblCompetencia.Text = "Competencia: " & _
        '    Me.ds.Tables("Competencia").Rows.Count
        'Me.lblAtleta.Text = "Atletas: " & _
        '    Me.dgvCompetenciaCalle.RowCount - 1
    End Sub

    Sub PrepararFormulario()
        btnReporte.Enabled = True
        btnCerrar.Enabled = True
        'grbDistancia.Enabled = False
        'grbFecha.Enabled = False

    End Sub

    'Private Sub rbtDistancia_CheckedChanged(sender As System.Object, e As System.EventArgs)
    '    If rbtDistancia.Checked = True And rbtFecha.Checked = False Then
    '        grbDistancia.Enabled = True
    '        grbFecha.Enabled = False
    '        btnReporte.Enabled = True
    '    End If
    'End Sub

    'Private Sub rbtFecha_CheckedChanged(sender As System.Object, e As System.EventArgs)
    '    If rbtFecha.Checked = True And rbtDistancia.Checked = False Then
    '        grbDistancia.Enabled = False
    '        grbFecha.Enabled = True
    '        btnReporte.Enabled = True
    '    End If
    'End Sub

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

    'Private Sub btnBuscarDistancia_Click(sender As System.Object, e As System.EventArgs)
    '    If txtDistancia.Text = "" Then
    '        MessageBox.Show("Debe ingresar una Distancia", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '    End If
    'End Sub

    'Private Sub dgvInformeFinalCalle_CellContentClick(sender As System.Object, e As System.Windows.Forms.DataGridViewCellEventArgs) Handles dgvInformeFinalCalle.CellContentClick
    '    Me.lblAtleta.Text = ""
    '    Me.lblAtleta.Text = "Atletas: " & _
    '        Me.dgvCompetenciaCalle.RowCount - 1
    'End Sub

    Private Sub btnReporte_Click(sender As System.Object, e As System.EventArgs) Handles btnReporte.Click
        Dim objForm As New Calle_x_Id
        Dim id_comp As Integer = dgvInformeFinalCalle.CurrentRow.Cells(5).Value
        frm_Calle_x_Id.id_competencia = id_comp
        frm_Calle_x_Id.ShowDialog()
    End Sub

End Class