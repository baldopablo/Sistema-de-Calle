Imports System.Data
Imports System.Data.SqlClient
Imports CAPA_NEGOCIO
Imports CAPA_ENTIDAD

Public Class Informe_Final_Marcha


    Private dcu As SqlDataAdapter
    Private dor As SqlDataAdapter
    Private ds As DataSet
    Private cn As SqlConnection
    Private str As String

    Private Sub Informe_Final_Marcha_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        PrepararFormulario()

        'crear conexion
        cn = New SqlConnection
        str = "Data Source=VALE\VALERIA;Initial Catalog=TESIS ATLETISMO 2016;Integrated Security=True"
        cn.ConnectionString = str

        ' creamos los adaptadores
        dcu = New SqlDataAdapter("select * from Competencia where Id_Disciplina= 404 order by Fecha_Inicio desc", cn)
        dor = New SqlDataAdapter("SELECT dbo.Atleta_X_Competencia.Id_Competencia,dbo.Atleta.Dorsal,dbo.Atleta.Nombre_Atleta,dbo.Atleta.Apellido_Atleta,dbo.Sexo.Sexo,DATEDIFF (year,dbo.Atleta.Fecha_Nacimiento, GETDATE()) as Edad,t.t3 AS [Categoría],Localidad.Nombre_Localidad,dbo.Club_Federación.Nombre_Club,dbo.Atleta.Id_Atleta ,dbo.Resultados_X_Competencia.Mejor,dbo.Resultados_X_Competencia.Posicion FROM dbo.Competencia INNER JOIN dbo.Atleta_X_Competencia ON dbo.Competencia.Id_Competencia = dbo.Atleta_X_Competencia.Id_Competencia INNER JOIN dbo.Atleta ON dbo.Atleta_X_Competencia.Id_Atleta = dbo.Atleta.Id_Atleta inner join Sexo on Atleta.Id_Sexo=sexo.Id_sexo inner join Club_Federación on Atleta.Id_Club_Federación=Club_Federación.Id_Club_Federación inner join Resultados_X_Competencia on Atleta_X_Competencia.Id_Resultados_X_Competencia=Resultados_X_Competencia.Id_Resultados_X_Competencia inner join Localidad on Localidad.Id_Localidad=Atleta.Id_Localidad INNER JOIN (VALUES(9, 10, 'Pre-Infantiles'),(11, 12, 'Infantiles'),(13, 14, 'Cadetes'),(15, 17, 'Menores'),(18, 19, 'Juveniles'),(20, 100, 'Mayores')) AS T (t1, t2, t3) ON CONVERT(int, DATEDIFF(d, Atleta.Fecha_Nacimiento, GETDATE())/365.25)BETWEEN T.t1 AND T.t2 where Id_Disciplina=404 order by Fecha_Inicio desc", cn)

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
        Me.dgvMarchaMaestro.DataSource = ds
        Me.dgvMarchaMaestro.DataMember = "Competencia"


        'asignar al datagridview detalles la relacion ue acabamos de crear por codigo
        Me.dgvMarchaDetalle.DataSource = ds
        Me.dgvMarchaDetalle.DataMember = "Competencia.Competencia_Atletas"
       
    End Sub

    Sub PrepararFormulario()

        btnReporte.Enabled = True
        btnCerrar.Enabled = True
       
    End Sub

  

 

    Private Sub btnCerrar_Click(sender As System.Object, e As System.EventArgs) Handles btnCerrar.Click
        Me.Close()
    End Sub

   

    Private Sub btnReporte_Click(sender As System.Object, e As System.EventArgs) Handles btnReporte.Click
        Dim objForm As New Marcha_x_Id
        Dim id_comp As Integer = dgvMarchaMaestro.CurrentRow.Cells(0).Value
        frm_Marcha_x_Id.id_competencia = id_comp
        frm_Marcha_x_Id.ShowDialog()
    End Sub

    Private Sub Label1_Click(sender As System.Object, e As System.EventArgs) Handles Label1.Click

    End Sub
End Class