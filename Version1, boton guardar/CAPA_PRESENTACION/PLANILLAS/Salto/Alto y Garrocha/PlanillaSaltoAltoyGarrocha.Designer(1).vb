﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlanillaSaltoenAltoyGarrocha
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
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.btnComenzar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.cboUsuario = New System.Windows.Forms.ComboBox()
        Me.txtCodigoSalto = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtEstado = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.cboPrueba = New System.Windows.Forms.ComboBox()
        Me.txtHora = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboLocalidad = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.dtpfechainicio = New System.Windows.Forms.DateTimePicker()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboProvincia = New System.Windows.Forms.ComboBox()
        Me.txtNombre = New System.Windows.Forms.TextBox()
        Me.txtLugar = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.cboSexo = New System.Windows.Forms.ComboBox()
        Me.cboCategoria = New System.Windows.Forms.ComboBox()
        Me.cboJuez1 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.btnAltura = New System.Windows.Forms.Button()
        Me.grbResultados = New System.Windows.Forms.GroupBox()
        Me.btnNulo = New System.Windows.Forms.Button()
        Me.btnRehuso = New System.Windows.Forms.Button()
        Me.btnVálido = New System.Windows.Forms.Button()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.btnQuitar = New System.Windows.Forms.Button()
        Me.txtAltura5 = New System.Windows.Forms.TextBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.txtAltura3 = New System.Windows.Forms.TextBox()
        Me.btnAgregarAtleta = New System.Windows.Forms.Button()
        Me.txtAltura2 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.txtAltura1 = New System.Windows.Forms.TextBox()
        Me.dgvAltoyGarrocha = New System.Windows.Forms.DataGridView()
        Me.Dorsal = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Id_Atleta = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Apellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrimerSaltoAltura1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SegundoSaltoAltura1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TercerSaltoAltura1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrimerSaltoAltura2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SegundoSaltoAltura2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TercerSaltoAltura2 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrimerSaltoAltura3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SegundoSaltoAltura3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TercerSaltoAltura3 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrimerSaltoAltura4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SegundoSaltoAltura4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TercerSaltoAltura4 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PrimerSaltoAltura5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SegundoSaltoAltura5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TercerSaltoAltura5 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MejorAltura = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clasificación = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.grbResultados.SuspendLayout()
        CType(Me.dgvAltoyGarrocha, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(71, 565)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 171
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'btnComenzar
        '
        Me.btnComenzar.Location = New System.Drawing.Point(581, 566)
        Me.btnComenzar.Name = "btnComenzar"
        Me.btnComenzar.Size = New System.Drawing.Size(75, 23)
        Me.btnComenzar.TabIndex = 168
        Me.btnComenzar.Text = "Comenzar"
        Me.btnComenzar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(743, 565)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 169
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(824, 565)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 170
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(448, 562)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(43, 13)
        Me.Label16.TabIndex = 681
        Me.Label16.Text = "Usuario"
        '
        'cboUsuario
        '
        Me.cboUsuario.FormattingEnabled = True
        Me.cboUsuario.Location = New System.Drawing.Point(412, 578)
        Me.cboUsuario.Name = "cboUsuario"
        Me.cboUsuario.Size = New System.Drawing.Size(121, 21)
        Me.cboUsuario.TabIndex = 680
        '
        'txtCodigoSalto
        '
        Me.txtCodigoSalto.Location = New System.Drawing.Point(322, 579)
        Me.txtCodigoSalto.Name = "txtCodigoSalto"
        Me.txtCodigoSalto.ReadOnly = True
        Me.txtCodigoSalto.Size = New System.Drawing.Size(50, 20)
        Me.txtCodigoSalto.TabIndex = 679
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(291, 563)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 13)
        Me.Label14.TabIndex = 678
        Me.Label14.Text = "Código de Competencia"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtEstado)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.cboPrueba)
        Me.GroupBox2.Controls.Add(Me.txtHora)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.cboLocalidad)
        Me.GroupBox2.Controls.Add(Me.PictureBox1)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.dtpfechainicio)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.cboProvincia)
        Me.GroupBox2.Controls.Add(Me.txtNombre)
        Me.GroupBox2.Controls.Add(Me.txtLugar)
        Me.GroupBox2.Location = New System.Drawing.Point(18, 4)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(882, 147)
        Me.GroupBox2.TabIndex = 642
        Me.GroupBox2.TabStop = False
        '
        'txtEstado
        '
        Me.txtEstado.Location = New System.Drawing.Point(339, 111)
        Me.txtEstado.Name = "txtEstado"
        Me.txtEstado.Size = New System.Drawing.Size(109, 20)
        Me.txtEstado.TabIndex = 688
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(213, 114)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(120, 13)
        Me.Label15.TabIndex = 687
        Me.Label15.Text = "Estado de Competencia"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(7, 114)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(41, 13)
        Me.Label17.TabIndex = 686
        Me.Label17.Text = "Prueba"
        '
        'cboPrueba
        '
        Me.cboPrueba.FormattingEnabled = True
        Me.cboPrueba.Location = New System.Drawing.Point(48, 111)
        Me.cboPrueba.Name = "cboPrueba"
        Me.cboPrueba.Size = New System.Drawing.Size(121, 21)
        Me.cboPrueba.TabIndex = 685
        '
        'txtHora
        '
        Me.txtHora.Location = New System.Drawing.Point(460, 67)
        Me.txtHora.Name = "txtHora"
        Me.txtHora.Size = New System.Drawing.Size(69, 20)
        Me.txtHora.TabIndex = 165
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(660, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 48)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "Asociación Atlética " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Córdoba Centro"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'cboLocalidad
        '
        Me.cboLocalidad.FormattingEnabled = True
        Me.cboLocalidad.Location = New System.Drawing.Point(72, 67)
        Me.cboLocalidad.Name = "cboLocalidad"
        Me.cboLocalidad.Size = New System.Drawing.Size(144, 21)
        Me.cboLocalidad.TabIndex = 164
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CAPA_PRESENTACION.My.Resources.Resources._972035_491669154244375_182680477_n
        Me.PictureBox1.Location = New System.Drawing.Point(705, 62)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 79)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 149
        Me.PictureBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 70)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 163
        Me.Label8.Text = "Localidad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "Nombre"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(237, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 151
        Me.Label4.Text = "Lugar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(424, 74)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 162
        Me.Label7.Text = "Hora"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(227, 74)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(80, 13)
        Me.Label6.TabIndex = 152
        Me.Label6.Text = "Fecha de Inicio"
        '
        'dtpfechainicio
        '
        Me.dtpfechainicio.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.dtpfechainicio.Location = New System.Drawing.Point(313, 68)
        Me.dtpfechainicio.Name = "dtpfechainicio"
        Me.dtpfechainicio.Size = New System.Drawing.Size(91, 20)
        Me.dtpfechainicio.TabIndex = 160
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(418, 28)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(51, 13)
        Me.Label9.TabIndex = 155
        Me.Label9.Text = "Provincia"
        '
        'cboProvincia
        '
        Me.cboProvincia.FormattingEnabled = True
        Me.cboProvincia.Location = New System.Drawing.Point(475, 25)
        Me.cboProvincia.Name = "cboProvincia"
        Me.cboProvincia.Size = New System.Drawing.Size(150, 21)
        Me.cboProvincia.TabIndex = 159
        '
        'txtNombre
        '
        Me.txtNombre.Location = New System.Drawing.Point(65, 25)
        Me.txtNombre.Name = "txtNombre"
        Me.txtNombre.Size = New System.Drawing.Size(154, 20)
        Me.txtNombre.TabIndex = 156
        '
        'txtLugar
        '
        Me.txtLugar.Location = New System.Drawing.Point(277, 25)
        Me.txtLugar.Name = "txtLugar"
        Me.txtLugar.Size = New System.Drawing.Size(127, 20)
        Me.txtLugar.TabIndex = 157
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(40, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(54, 13)
        Me.Label18.TabIndex = 684
        Me.Label18.Text = "Categoría"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(59, 12)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(31, 13)
        Me.Label19.TabIndex = 683
        Me.Label19.Text = "Sexo"
        '
        'cboSexo
        '
        Me.cboSexo.FormattingEnabled = True
        Me.cboSexo.Items.AddRange(New Object() {"--Seleccionar--", "Femenino", "Masculino"})
        Me.cboSexo.Location = New System.Drawing.Point(100, 9)
        Me.cboSexo.Name = "cboSexo"
        Me.cboSexo.Size = New System.Drawing.Size(121, 21)
        Me.cboSexo.TabIndex = 681
        '
        'cboCategoria
        '
        Me.cboCategoria.FormattingEnabled = True
        Me.cboCategoria.Items.AddRange(New Object() {"--Seleccionar--", "Mayores", "Juveniles", "Menores", "Cadetes", "Infantiles", "Pre-Infantiles"})
        Me.cboCategoria.Location = New System.Drawing.Point(100, 36)
        Me.cboCategoria.Name = "cboCategoria"
        Me.cboCategoria.Size = New System.Drawing.Size(121, 21)
        Me.cboCategoria.TabIndex = 682
        '
        'cboJuez1
        '
        Me.cboJuez1.FormattingEnabled = True
        Me.cboJuez1.Location = New System.Drawing.Point(367, 24)
        Me.cboJuez1.Name = "cboJuez1"
        Me.cboJuez1.Size = New System.Drawing.Size(121, 21)
        Me.cboJuez1.TabIndex = 620
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(289, 27)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(72, 13)
        Me.Label12.TabIndex = 615
        Me.Label12.Text = "Juez Principal"
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(662, 566)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 676
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(220, 567)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(69, 20)
        Me.TextBox1.TabIndex = 679
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(153, 570)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(61, 13)
        Me.Label20.TabIndex = 678
        Me.Label20.Text = "id resultado"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboSexo)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.cboCategoria)
        Me.GroupBox1.Controls.Add(Me.Label18)
        Me.GroupBox1.Controls.Add(Me.cboJuez1)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 160)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(883, 67)
        Me.GroupBox1.TabIndex = 682
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Seleccionar"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(543, 506)
        Me.TextBox4.Multiline = True
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(103, 31)
        Me.TextBox4.TabIndex = 694
        '
        'btnAltura
        '
        Me.btnAltura.Location = New System.Drawing.Point(446, 506)
        Me.btnAltura.Name = "btnAltura"
        Me.btnAltura.Size = New System.Drawing.Size(91, 31)
        Me.btnAltura.TabIndex = 693
        Me.btnAltura.Text = "Ingrese la altura"
        Me.btnAltura.UseVisualStyleBackColor = True
        '
        'grbResultados
        '
        Me.grbResultados.Controls.Add(Me.btnNulo)
        Me.grbResultados.Controls.Add(Me.btnRehuso)
        Me.grbResultados.Controls.Add(Me.btnVálido)
        Me.grbResultados.Location = New System.Drawing.Point(65, 490)
        Me.grbResultados.Name = "grbResultados"
        Me.grbResultados.Size = New System.Drawing.Size(342, 60)
        Me.grbResultados.TabIndex = 692
        Me.grbResultados.TabStop = False
        Me.grbResultados.Text = "Opciones de Resultado"
        '
        'btnNulo
        '
        Me.btnNulo.Location = New System.Drawing.Point(125, 14)
        Me.btnNulo.Name = "btnNulo"
        Me.btnNulo.Size = New System.Drawing.Size(91, 32)
        Me.btnNulo.TabIndex = 533
        Me.btnNulo.Text = "Nulo (X)"
        Me.btnNulo.UseVisualStyleBackColor = True
        '
        'btnRehuso
        '
        Me.btnRehuso.Location = New System.Drawing.Point(222, 15)
        Me.btnRehuso.Name = "btnRehuso"
        Me.btnRehuso.Size = New System.Drawing.Size(91, 32)
        Me.btnRehuso.TabIndex = 533
        Me.btnRehuso.Text = "Rehuso (=)"
        Me.btnRehuso.UseVisualStyleBackColor = True
        '
        'btnVálido
        '
        Me.btnVálido.Location = New System.Drawing.Point(28, 15)
        Me.btnVálido.Name = "btnVálido"
        Me.btnVálido.Size = New System.Drawing.Size(91, 31)
        Me.btnVálido.TabIndex = 533
        Me.btnVálido.Text = "Válido (O)"
        Me.btnVálido.UseVisualStyleBackColor = True
        '
        'TextBox8
        '
        Me.TextBox8.Location = New System.Drawing.Point(601, 242)
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.ReadOnly = True
        Me.TextBox8.Size = New System.Drawing.Size(135, 20)
        Me.TextBox8.TabIndex = 691
        '
        'btnQuitar
        '
        Me.btnQuitar.Location = New System.Drawing.Point(760, 291)
        Me.btnQuitar.Name = "btnQuitar"
        Me.btnQuitar.Size = New System.Drawing.Size(111, 23)
        Me.btnQuitar.TabIndex = 695
        Me.btnQuitar.Text = "Quitar Atleta"
        Me.btnQuitar.UseVisualStyleBackColor = True
        '
        'txtAltura5
        '
        Me.txtAltura5.Location = New System.Drawing.Point(542, 242)
        Me.txtAltura5.Name = "txtAltura5"
        Me.txtAltura5.Size = New System.Drawing.Size(60, 20)
        Me.txtAltura5.TabIndex = 690
        Me.txtAltura5.Text = "Altura 5"
        Me.txtAltura5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox7
        '
        Me.TextBox7.Location = New System.Drawing.Point(483, 242)
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(60, 20)
        Me.TextBox7.TabIndex = 689
        Me.TextBox7.Text = "Altura 4"
        Me.TextBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtAltura3
        '
        Me.txtAltura3.Location = New System.Drawing.Point(424, 242)
        Me.txtAltura3.Name = "txtAltura3"
        Me.txtAltura3.Size = New System.Drawing.Size(60, 20)
        Me.txtAltura3.TabIndex = 688
        Me.txtAltura3.Text = "Altura 3"
        Me.txtAltura3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnAgregarAtleta
        '
        Me.btnAgregarAtleta.Location = New System.Drawing.Point(760, 262)
        Me.btnAgregarAtleta.Name = "btnAgregarAtleta"
        Me.btnAgregarAtleta.Size = New System.Drawing.Size(111, 23)
        Me.btnAgregarAtleta.TabIndex = 683
        Me.btnAgregarAtleta.Text = "Agregar Atleta"
        Me.btnAgregarAtleta.UseVisualStyleBackColor = True
        '
        'txtAltura2
        '
        Me.txtAltura2.Location = New System.Drawing.Point(365, 242)
        Me.txtAltura2.Name = "txtAltura2"
        Me.txtAltura2.Size = New System.Drawing.Size(60, 20)
        Me.txtAltura2.TabIndex = 687
        Me.txtAltura2.Text = "Altura 2"
        Me.txtAltura2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'TextBox6
        '
        Me.TextBox6.Location = New System.Drawing.Point(12, 242)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.ReadOnly = True
        Me.TextBox6.Size = New System.Drawing.Size(296, 20)
        Me.TextBox6.TabIndex = 686
        '
        'txtAltura1
        '
        Me.txtAltura1.Location = New System.Drawing.Point(306, 242)
        Me.txtAltura1.Name = "txtAltura1"
        Me.txtAltura1.Size = New System.Drawing.Size(60, 20)
        Me.txtAltura1.TabIndex = 685
        Me.txtAltura1.Text = "Altura 1"
        Me.txtAltura1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'dgvAltoyGarrocha
        '
        Me.dgvAltoyGarrocha.AllowUserToAddRows = False
        Me.dgvAltoyGarrocha.AllowUserToDeleteRows = False
        Me.dgvAltoyGarrocha.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvAltoyGarrocha.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Dorsal, Me.Id_Atleta, Me.Nombre, Me.Apellido, Me.PrimerSaltoAltura1, Me.SegundoSaltoAltura1, Me.TercerSaltoAltura1, Me.PrimerSaltoAltura2, Me.SegundoSaltoAltura2, Me.TercerSaltoAltura2, Me.PrimerSaltoAltura3, Me.SegundoSaltoAltura3, Me.TercerSaltoAltura3, Me.PrimerSaltoAltura4, Me.SegundoSaltoAltura4, Me.TercerSaltoAltura4, Me.PrimerSaltoAltura5, Me.SegundoSaltoAltura5, Me.TercerSaltoAltura5, Me.MejorAltura, Me.Clasificación})
        Me.dgvAltoyGarrocha.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.dgvAltoyGarrocha.Location = New System.Drawing.Point(12, 262)
        Me.dgvAltoyGarrocha.MultiSelect = False
        Me.dgvAltoyGarrocha.Name = "dgvAltoyGarrocha"
        Me.dgvAltoyGarrocha.ReadOnly = True
        Me.dgvAltoyGarrocha.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvAltoyGarrocha.Size = New System.Drawing.Size(724, 226)
        Me.dgvAltoyGarrocha.TabIndex = 684
        '
        'Dorsal
        '
        Me.Dorsal.HeaderText = "Dorsal"
        Me.Dorsal.Name = "Dorsal"
        Me.Dorsal.ReadOnly = True
        Me.Dorsal.Width = 50
        '
        'Id_Atleta
        '
        Me.Id_Atleta.HeaderText = "Id_Atleta"
        Me.Id_Atleta.Name = "Id_Atleta"
        Me.Id_Atleta.ReadOnly = True
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        Me.Nombre.ReadOnly = True
        '
        'Apellido
        '
        Me.Apellido.HeaderText = "Apellido"
        Me.Apellido.Name = "Apellido"
        Me.Apellido.ReadOnly = True
        '
        'PrimerSaltoAltura1
        '
        Me.PrimerSaltoAltura1.HeaderText = "1°"
        Me.PrimerSaltoAltura1.Name = "PrimerSaltoAltura1"
        Me.PrimerSaltoAltura1.ReadOnly = True
        Me.PrimerSaltoAltura1.Width = 20
        '
        'SegundoSaltoAltura1
        '
        Me.SegundoSaltoAltura1.HeaderText = "2°"
        Me.SegundoSaltoAltura1.Name = "SegundoSaltoAltura1"
        Me.SegundoSaltoAltura1.ReadOnly = True
        Me.SegundoSaltoAltura1.Width = 20
        '
        'TercerSaltoAltura1
        '
        Me.TercerSaltoAltura1.HeaderText = "3°"
        Me.TercerSaltoAltura1.Name = "TercerSaltoAltura1"
        Me.TercerSaltoAltura1.ReadOnly = True
        Me.TercerSaltoAltura1.Width = 20
        '
        'PrimerSaltoAltura2
        '
        Me.PrimerSaltoAltura2.HeaderText = "1°"
        Me.PrimerSaltoAltura2.Name = "PrimerSaltoAltura2"
        Me.PrimerSaltoAltura2.ReadOnly = True
        Me.PrimerSaltoAltura2.Width = 20
        '
        'SegundoSaltoAltura2
        '
        Me.SegundoSaltoAltura2.HeaderText = "2°"
        Me.SegundoSaltoAltura2.Name = "SegundoSaltoAltura2"
        Me.SegundoSaltoAltura2.ReadOnly = True
        Me.SegundoSaltoAltura2.Width = 20
        '
        'TercerSaltoAltura2
        '
        Me.TercerSaltoAltura2.HeaderText = "3°"
        Me.TercerSaltoAltura2.Name = "TercerSaltoAltura2"
        Me.TercerSaltoAltura2.ReadOnly = True
        Me.TercerSaltoAltura2.Width = 20
        '
        'PrimerSaltoAltura3
        '
        Me.PrimerSaltoAltura3.HeaderText = "1°"
        Me.PrimerSaltoAltura3.Name = "PrimerSaltoAltura3"
        Me.PrimerSaltoAltura3.ReadOnly = True
        Me.PrimerSaltoAltura3.Width = 20
        '
        'SegundoSaltoAltura3
        '
        Me.SegundoSaltoAltura3.HeaderText = "2°"
        Me.SegundoSaltoAltura3.Name = "SegundoSaltoAltura3"
        Me.SegundoSaltoAltura3.ReadOnly = True
        Me.SegundoSaltoAltura3.Width = 20
        '
        'TercerSaltoAltura3
        '
        Me.TercerSaltoAltura3.HeaderText = "3°"
        Me.TercerSaltoAltura3.Name = "TercerSaltoAltura3"
        Me.TercerSaltoAltura3.ReadOnly = True
        Me.TercerSaltoAltura3.Width = 20
        '
        'PrimerSaltoAltura4
        '
        Me.PrimerSaltoAltura4.HeaderText = "1°"
        Me.PrimerSaltoAltura4.Name = "PrimerSaltoAltura4"
        Me.PrimerSaltoAltura4.ReadOnly = True
        Me.PrimerSaltoAltura4.Width = 20
        '
        'SegundoSaltoAltura4
        '
        Me.SegundoSaltoAltura4.HeaderText = "2°"
        Me.SegundoSaltoAltura4.Name = "SegundoSaltoAltura4"
        Me.SegundoSaltoAltura4.ReadOnly = True
        Me.SegundoSaltoAltura4.Width = 20
        '
        'TercerSaltoAltura4
        '
        Me.TercerSaltoAltura4.HeaderText = "3°"
        Me.TercerSaltoAltura4.Name = "TercerSaltoAltura4"
        Me.TercerSaltoAltura4.ReadOnly = True
        Me.TercerSaltoAltura4.Width = 20
        '
        'PrimerSaltoAltura5
        '
        Me.PrimerSaltoAltura5.HeaderText = "1°"
        Me.PrimerSaltoAltura5.Name = "PrimerSaltoAltura5"
        Me.PrimerSaltoAltura5.ReadOnly = True
        Me.PrimerSaltoAltura5.Width = 20
        '
        'SegundoSaltoAltura5
        '
        Me.SegundoSaltoAltura5.HeaderText = "2°"
        Me.SegundoSaltoAltura5.Name = "SegundoSaltoAltura5"
        Me.SegundoSaltoAltura5.ReadOnly = True
        Me.SegundoSaltoAltura5.Width = 20
        '
        'TercerSaltoAltura5
        '
        Me.TercerSaltoAltura5.HeaderText = "3°"
        Me.TercerSaltoAltura5.Name = "TercerSaltoAltura5"
        Me.TercerSaltoAltura5.ReadOnly = True
        Me.TercerSaltoAltura5.Width = 20
        '
        'MejorAltura
        '
        Me.MejorAltura.HeaderText = "Mejor Altura"
        Me.MejorAltura.Name = "MejorAltura"
        Me.MejorAltura.ReadOnly = True
        Me.MejorAltura.Width = 50
        '
        'Clasificación
        '
        Me.Clasificación.HeaderText = "Clasif."
        Me.Clasificación.Name = "Clasificación"
        Me.Clasificación.ReadOnly = True
        Me.Clasificación.Width = 80
        '
        'PlanillaSaltoenAltoyGarrocha
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(905, 600)
        Me.Controls.Add(Me.TextBox4)
        Me.Controls.Add(Me.btnAltura)
        Me.Controls.Add(Me.grbResultados)
        Me.Controls.Add(Me.TextBox8)
        Me.Controls.Add(Me.btnQuitar)
        Me.Controls.Add(Me.txtAltura5)
        Me.Controls.Add(Me.TextBox7)
        Me.Controls.Add(Me.txtAltura3)
        Me.Controls.Add(Me.btnAgregarAtleta)
        Me.Controls.Add(Me.txtAltura2)
        Me.Controls.Add(Me.TextBox6)
        Me.Controls.Add(Me.txtAltura1)
        Me.Controls.Add(Me.dgvAltoyGarrocha)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.cboUsuario)
        Me.Controls.Add(Me.Label20)
        Me.Controls.Add(Me.txtCodigoSalto)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnComenzar)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "PlanillaSaltoenAltoyGarrocha"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Planilla Salto en Alto y Garrocha"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.grbResultados.ResumeLayout(False)
        CType(Me.dgvAltoyGarrocha, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents btnComenzar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboPrueba As System.Windows.Forms.ComboBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents cboSexo As System.Windows.Forms.ComboBox
    Friend WithEvents cboCategoria As System.Windows.Forms.ComboBox
    Friend WithEvents cboJuez1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtHora As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboLocalidad As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents dtpfechainicio As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboProvincia As System.Windows.Forms.ComboBox
    Friend WithEvents txtNombre As System.Windows.Forms.TextBox
    Friend WithEvents txtLugar As System.Windows.Forms.TextBox
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents txtCodigoSalto As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtEstado As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents cboUsuario As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents btnAltura As System.Windows.Forms.Button
    Friend WithEvents grbResultados As System.Windows.Forms.GroupBox
    Friend WithEvents btnNulo As System.Windows.Forms.Button
    Friend WithEvents btnRehuso As System.Windows.Forms.Button
    Friend WithEvents btnVálido As System.Windows.Forms.Button
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents btnQuitar As System.Windows.Forms.Button
    Friend WithEvents txtAltura5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents txtAltura3 As System.Windows.Forms.TextBox
    Friend WithEvents btnAgregarAtleta As System.Windows.Forms.Button
    Friend WithEvents txtAltura2 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents txtAltura1 As System.Windows.Forms.TextBox
    Friend WithEvents dgvAltoyGarrocha As System.Windows.Forms.DataGridView
    Friend WithEvents Dorsal As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Id_Atleta As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Apellido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrimerSaltoAltura1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SegundoSaltoAltura1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TercerSaltoAltura1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrimerSaltoAltura2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SegundoSaltoAltura2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TercerSaltoAltura2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrimerSaltoAltura3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SegundoSaltoAltura3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TercerSaltoAltura3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrimerSaltoAltura4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SegundoSaltoAltura4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TercerSaltoAltura4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PrimerSaltoAltura5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SegundoSaltoAltura5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents TercerSaltoAltura5 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents MejorAltura As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Clasificación As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
