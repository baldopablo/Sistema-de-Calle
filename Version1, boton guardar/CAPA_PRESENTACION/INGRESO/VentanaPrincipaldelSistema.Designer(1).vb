<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class VentanaPrincipaldelSistema
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub


    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.MenuStrip = New System.Windows.Forms.MenuStrip()
        Me.StatusStrip = New System.Windows.Forms.StatusStrip()
        Me.ToolStripStatusLabel = New System.Windows.Forms.ToolStripStatusLabel()
        Me.ToolTip = New System.Windows.Forms.ToolTip(Me.components)
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.UsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoUsuarioToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListaDeUsuariosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SalirToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AtletasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoAtletaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListaDeAtletasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CompetenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevaCompetenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListaDeCompetenciasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.JuezToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoJuezToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListaDeJuecesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ClubFederaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.NuevoClubFederaciónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ListaDeClubesFederacionesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.InformesGeneralesToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AtletasPorCompetenciaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CalleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.PistaYCampoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CrossCountryToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.FondoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LanzamientoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MaratónToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MarchaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.MedioFondoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ObstáculosToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.SaltoToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.AltoYGarrochaToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.LargoYTripleToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.VelocidadToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.EstadísticasToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.StatusStrip.SuspendLayout()
        Me.MenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip
        '
        Me.MenuStrip.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow
        Me.MenuStrip.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip.Name = "MenuStrip"
        Me.MenuStrip.Size = New System.Drawing.Size(841, 24)
        Me.MenuStrip.TabIndex = 5
        Me.MenuStrip.Text = "MenuStrip"
        '
        'StatusStrip
        '
        Me.StatusStrip.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripStatusLabel})
        Me.StatusStrip.Location = New System.Drawing.Point(0, 463)
        Me.StatusStrip.Name = "StatusStrip"
        Me.StatusStrip.Size = New System.Drawing.Size(841, 22)
        Me.StatusStrip.TabIndex = 7
        Me.StatusStrip.Text = "StatusStrip"
        '
        'ToolStripStatusLabel
        '
        Me.ToolStripStatusLabel.Name = "ToolStripStatusLabel"
        Me.ToolStripStatusLabel.Size = New System.Drawing.Size(42, 17)
        Me.ToolStripStatusLabel.Text = "Estado"
        '
        'MenuStrip1
        '
        Me.MenuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.UsuariosToolStripMenuItem, Me.AtletasToolStripMenuItem, Me.CompetenciaToolStripMenuItem, Me.JuezToolStripMenuItem, Me.ClubFederaciónToolStripMenuItem, Me.InformesGeneralesToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 24)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(841, 24)
        Me.MenuStrip1.TabIndex = 11
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'UsuariosToolStripMenuItem
        '
        Me.UsuariosToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoUsuarioToolStripMenuItem, Me.ListaDeUsuariosToolStripMenuItem, Me.SalirToolStripMenuItem})
        Me.UsuariosToolStripMenuItem.Name = "UsuariosToolStripMenuItem"
        Me.UsuariosToolStripMenuItem.Size = New System.Drawing.Size(64, 20)
        Me.UsuariosToolStripMenuItem.Text = "Usuarios"
        '
        'NuevoUsuarioToolStripMenuItem
        '
        Me.NuevoUsuarioToolStripMenuItem.Name = "NuevoUsuarioToolStripMenuItem"
        Me.NuevoUsuarioToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.NuevoUsuarioToolStripMenuItem.Text = "Nuevo Usuario"
        '
        'ListaDeUsuariosToolStripMenuItem
        '
        Me.ListaDeUsuariosToolStripMenuItem.Name = "ListaDeUsuariosToolStripMenuItem"
        Me.ListaDeUsuariosToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.ListaDeUsuariosToolStripMenuItem.Text = "Lista de Usuarios"
        '
        'SalirToolStripMenuItem
        '
        Me.SalirToolStripMenuItem.Name = "SalirToolStripMenuItem"
        Me.SalirToolStripMenuItem.Size = New System.Drawing.Size(162, 22)
        Me.SalirToolStripMenuItem.Text = "Salir"
        '
        'AtletasToolStripMenuItem
        '
        Me.AtletasToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoAtletaToolStripMenuItem, Me.ListaDeAtletasToolStripMenuItem})
        Me.AtletasToolStripMenuItem.Name = "AtletasToolStripMenuItem"
        Me.AtletasToolStripMenuItem.Size = New System.Drawing.Size(55, 20)
        Me.AtletasToolStripMenuItem.Text = "Atletas"
        '
        'NuevoAtletaToolStripMenuItem
        '
        Me.NuevoAtletaToolStripMenuItem.Name = "NuevoAtletaToolStripMenuItem"
        Me.NuevoAtletaToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.NuevoAtletaToolStripMenuItem.Text = "Nuevo Atleta"
        '
        'ListaDeAtletasToolStripMenuItem
        '
        Me.ListaDeAtletasToolStripMenuItem.Name = "ListaDeAtletasToolStripMenuItem"
        Me.ListaDeAtletasToolStripMenuItem.Size = New System.Drawing.Size(153, 22)
        Me.ListaDeAtletasToolStripMenuItem.Text = "Lista de Atletas"
        '
        'CompetenciaToolStripMenuItem
        '
        Me.CompetenciaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevaCompetenciaToolStripMenuItem, Me.ListaDeCompetenciasToolStripMenuItem})
        Me.CompetenciaToolStripMenuItem.Name = "CompetenciaToolStripMenuItem"
        Me.CompetenciaToolStripMenuItem.Size = New System.Drawing.Size(95, 20)
        Me.CompetenciaToolStripMenuItem.Text = "Competencias"
        '
        'NuevaCompetenciaToolStripMenuItem
        '
        Me.NuevaCompetenciaToolStripMenuItem.Name = "NuevaCompetenciaToolStripMenuItem"
        Me.NuevaCompetenciaToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.NuevaCompetenciaToolStripMenuItem.Text = "Nueva Competencia"
        '
        'ListaDeCompetenciasToolStripMenuItem
        '
        Me.ListaDeCompetenciasToolStripMenuItem.Name = "ListaDeCompetenciasToolStripMenuItem"
        Me.ListaDeCompetenciasToolStripMenuItem.Size = New System.Drawing.Size(193, 22)
        Me.ListaDeCompetenciasToolStripMenuItem.Text = "Lista de Competencias"
        '
        'JuezToolStripMenuItem
        '
        Me.JuezToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoJuezToolStripMenuItem, Me.ListaDeJuecesToolStripMenuItem})
        Me.JuezToolStripMenuItem.Name = "JuezToolStripMenuItem"
        Me.JuezToolStripMenuItem.Size = New System.Drawing.Size(53, 20)
        Me.JuezToolStripMenuItem.Text = "Jueces"
        '
        'NuevoJuezToolStripMenuItem
        '
        Me.NuevoJuezToolStripMenuItem.Name = "NuevoJuezToolStripMenuItem"
        Me.NuevoJuezToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.NuevoJuezToolStripMenuItem.Text = "Nuevo Juez"
        '
        'ListaDeJuecesToolStripMenuItem
        '
        Me.ListaDeJuecesToolStripMenuItem.Name = "ListaDeJuecesToolStripMenuItem"
        Me.ListaDeJuecesToolStripMenuItem.Size = New System.Drawing.Size(151, 22)
        Me.ListaDeJuecesToolStripMenuItem.Text = "Lista de Jueces"
        '
        'ClubFederaciónToolStripMenuItem
        '
        Me.ClubFederaciónToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.NuevoClubFederaciónToolStripMenuItem, Me.ListaDeClubesFederacionesToolStripMenuItem})
        Me.ClubFederaciónToolStripMenuItem.Name = "ClubFederaciónToolStripMenuItem"
        Me.ClubFederaciónToolStripMenuItem.Size = New System.Drawing.Size(129, 20)
        Me.ClubFederaciónToolStripMenuItem.Text = "Clubes/Federaciones"
        '
        'NuevoClubFederaciónToolStripMenuItem
        '
        Me.NuevoClubFederaciónToolStripMenuItem.Name = "NuevoClubFederaciónToolStripMenuItem"
        Me.NuevoClubFederaciónToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.NuevoClubFederaciónToolStripMenuItem.Text = "Nuevo Club/Federación"
        '
        'ListaDeClubesFederacionesToolStripMenuItem
        '
        Me.ListaDeClubesFederacionesToolStripMenuItem.Name = "ListaDeClubesFederacionesToolStripMenuItem"
        Me.ListaDeClubesFederacionesToolStripMenuItem.Size = New System.Drawing.Size(227, 22)
        Me.ListaDeClubesFederacionesToolStripMenuItem.Text = "Lista de Clubes/Federaciones"
        '
        'InformesGeneralesToolStripMenuItem
        '
        Me.InformesGeneralesToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AtletasPorCompetenciaToolStripMenuItem, Me.EstadísticasToolStripMenuItem})
        Me.InformesGeneralesToolStripMenuItem.Name = "InformesGeneralesToolStripMenuItem"
        Me.InformesGeneralesToolStripMenuItem.Size = New System.Drawing.Size(120, 20)
        Me.InformesGeneralesToolStripMenuItem.Text = "Informes Generales"
        '
        'AtletasPorCompetenciaToolStripMenuItem
        '
        Me.AtletasPorCompetenciaToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CalleToolStripMenuItem, Me.PistaYCampoToolStripMenuItem})
        Me.AtletasPorCompetenciaToolStripMenuItem.Name = "AtletasPorCompetenciaToolStripMenuItem"
        Me.AtletasPorCompetenciaToolStripMenuItem.Size = New System.Drawing.Size(134, 22)
        Me.AtletasPorCompetenciaToolStripMenuItem.Text = "Reportes"
        '
        'CalleToolStripMenuItem
        '
        Me.CalleToolStripMenuItem.Name = "CalleToolStripMenuItem"
        Me.CalleToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.CalleToolStripMenuItem.Text = "Calle"
        '
        'PistaYCampoToolStripMenuItem
        '
        Me.PistaYCampoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.CrossCountryToolStripMenuItem, Me.FondoToolStripMenuItem, Me.LanzamientoToolStripMenuItem, Me.MaratónToolStripMenuItem, Me.MarchaToolStripMenuItem, Me.MedioFondoToolStripMenuItem, Me.ObstáculosToolStripMenuItem, Me.SaltoToolStripMenuItem, Me.VelocidadToolStripMenuItem})
        Me.PistaYCampoToolStripMenuItem.Name = "PistaYCampoToolStripMenuItem"
        Me.PistaYCampoToolStripMenuItem.Size = New System.Drawing.Size(150, 22)
        Me.PistaYCampoToolStripMenuItem.Text = "Pista y Campo"
        '
        'CrossCountryToolStripMenuItem
        '
        Me.CrossCountryToolStripMenuItem.Name = "CrossCountryToolStripMenuItem"
        Me.CrossCountryToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.CrossCountryToolStripMenuItem.Text = "Cross Country"
        '
        'FondoToolStripMenuItem
        '
        Me.FondoToolStripMenuItem.Name = "FondoToolStripMenuItem"
        Me.FondoToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.FondoToolStripMenuItem.Text = "Fondo"
        '
        'LanzamientoToolStripMenuItem
        '
        Me.LanzamientoToolStripMenuItem.Name = "LanzamientoToolStripMenuItem"
        Me.LanzamientoToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.LanzamientoToolStripMenuItem.Text = "Lanzamiento"
        '
        'MaratónToolStripMenuItem
        '
        Me.MaratónToolStripMenuItem.Name = "MaratónToolStripMenuItem"
        Me.MaratónToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.MaratónToolStripMenuItem.Text = "Maratón"
        '
        'MarchaToolStripMenuItem
        '
        Me.MarchaToolStripMenuItem.Name = "MarchaToolStripMenuItem"
        Me.MarchaToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.MarchaToolStripMenuItem.Text = "Marcha"
        '
        'MedioFondoToolStripMenuItem
        '
        Me.MedioFondoToolStripMenuItem.Name = "MedioFondoToolStripMenuItem"
        Me.MedioFondoToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.MedioFondoToolStripMenuItem.Text = "Medio Fondo"
        '
        'ObstáculosToolStripMenuItem
        '
        Me.ObstáculosToolStripMenuItem.Name = "ObstáculosToolStripMenuItem"
        Me.ObstáculosToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.ObstáculosToolStripMenuItem.Text = "Obstáculos"
        '
        'SaltoToolStripMenuItem
        '
        Me.SaltoToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.AltoYGarrochaToolStripMenuItem, Me.LargoYTripleToolStripMenuItem})
        Me.SaltoToolStripMenuItem.Name = "SaltoToolStripMenuItem"
        Me.SaltoToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.SaltoToolStripMenuItem.Text = "Salto"
        '
        'AltoYGarrochaToolStripMenuItem
        '
        Me.AltoYGarrochaToolStripMenuItem.Name = "AltoYGarrochaToolStripMenuItem"
        Me.AltoYGarrochaToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.AltoYGarrochaToolStripMenuItem.Text = "Alto y Garrocha"
        '
        'LargoYTripleToolStripMenuItem
        '
        Me.LargoYTripleToolStripMenuItem.Name = "LargoYTripleToolStripMenuItem"
        Me.LargoYTripleToolStripMenuItem.Size = New System.Drawing.Size(156, 22)
        Me.LargoYTripleToolStripMenuItem.Text = "Largo y Triple"
        '
        'VelocidadToolStripMenuItem
        '
        Me.VelocidadToolStripMenuItem.Name = "VelocidadToolStripMenuItem"
        Me.VelocidadToolStripMenuItem.Size = New System.Drawing.Size(149, 22)
        Me.VelocidadToolStripMenuItem.Text = "Velocidad"
        '
        'EstadísticasToolStripMenuItem
        '
        Me.EstadísticasToolStripMenuItem.Name = "EstadísticasToolStripMenuItem"
        Me.EstadísticasToolStripMenuItem.Size = New System.Drawing.Size(152, 22)
        Me.EstadísticasToolStripMenuItem.Text = "Estadísticas"
        '
        'VentanaPrincipaldelSistema
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackColor = System.Drawing.Color.White
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.ClientSize = New System.Drawing.Size(841, 485)
        Me.Controls.Add(Me.StatusStrip)
        Me.Controls.Add(Me.MenuStrip1)
        Me.Controls.Add(Me.MenuStrip)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.IsMdiContainer = True
        Me.MainMenuStrip = Me.MenuStrip
        Me.Name = "VentanaPrincipaldelSistema"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asociación Atlética Córdoba Centro"
        Me.TransparencyKey = System.Drawing.Color.LightGray
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.StatusStrip.ResumeLayout(False)
        Me.StatusStrip.PerformLayout()
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ToolTip As System.Windows.Forms.ToolTip
    Friend WithEvents ToolStripStatusLabel As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents StatusStrip As System.Windows.Forms.StatusStrip
    Friend WithEvents MenuStrip As System.Windows.Forms.MenuStrip
    Friend WithEvents MenuStrip1 As System.Windows.Forms.MenuStrip
    Friend WithEvents UsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoUsuarioToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListaDeUsuariosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AtletasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoAtletaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListaDeAtletasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CompetenciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevaCompetenciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListaDeCompetenciasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents JuezToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoJuezToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListaDeJuecesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ClubFederaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents NuevoClubFederaciónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ListaDeClubesFederacionesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents InformesGeneralesToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AtletasPorCompetenciaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents EstadísticasToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SalirToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CalleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents PistaYCampoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents CrossCountryToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents FondoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LanzamientoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MaratónToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MarchaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents MedioFondoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents ObstáculosToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents VelocidadToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents SaltoToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents AltoYGarrochaToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents LargoYTripleToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem

End Class
