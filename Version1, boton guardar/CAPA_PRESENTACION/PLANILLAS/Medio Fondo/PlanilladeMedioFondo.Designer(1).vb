﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlanilladeMedioFondo
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
        Me.btnActualizar = New System.Windows.Forms.Button()
        Me.btnComenzar = New System.Windows.Forms.Button()
        Me.btnGuardar = New System.Windows.Forms.Button()
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.grbSeries = New System.Windows.Forms.GroupBox()
        Me.rbtSerie3 = New System.Windows.Forms.RadioButton()
        Me.rbtSerie2 = New System.Windows.Forms.RadioButton()
        Me.rbtSerie1 = New System.Windows.Forms.RadioButton()
        Me.btnAceptar = New System.Windows.Forms.Button()
        Me.btnAgregarSerie3 = New System.Windows.Forms.Button()
        Me.btnAgregarSerie1 = New System.Windows.Forms.Button()
        Me.btnAgregarSerie2 = New System.Windows.Forms.Button()
        Me.btnAgregarAtleta = New System.Windows.Forms.Button()
        Me.btnQuitarAtleta = New System.Windows.Forms.Button()
        Me.btnImprimir = New System.Windows.Forms.Button()
        Me.dgvPlanillaMedioFondo = New System.Windows.Forms.DataGridView()
        Me.Seleccionar = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.Numero = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Apellido = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Nombre = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Institución = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Tiempo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Clasificación = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboJuez3 = New System.Windows.Forms.ComboBox()
        Me.cboJuez2 = New System.Windows.Forms.ComboBox()
        Me.cboJuez1 = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ComboBox3 = New System.Windows.Forms.ComboBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ComboBox5 = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.cboPruebas = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ComboBox2 = New System.Windows.Forms.ComboBox()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBox1 = New System.Windows.Forms.ComboBox()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.grbSeries.SuspendLayout()
        CType(Me.dgvPlanillaMedioFondo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnActualizar
        '
        Me.btnActualizar.Location = New System.Drawing.Point(625, 470)
        Me.btnActualizar.Name = "btnActualizar"
        Me.btnActualizar.Size = New System.Drawing.Size(75, 23)
        Me.btnActualizar.TabIndex = 695
        Me.btnActualizar.Text = "Actualizar"
        Me.btnActualizar.UseVisualStyleBackColor = True
        '
        'btnComenzar
        '
        Me.btnComenzar.Location = New System.Drawing.Point(544, 470)
        Me.btnComenzar.Name = "btnComenzar"
        Me.btnComenzar.Size = New System.Drawing.Size(75, 23)
        Me.btnComenzar.TabIndex = 694
        Me.btnComenzar.Text = "Comenzar"
        Me.btnComenzar.UseVisualStyleBackColor = True
        '
        'btnGuardar
        '
        Me.btnGuardar.Location = New System.Drawing.Point(706, 470)
        Me.btnGuardar.Name = "btnGuardar"
        Me.btnGuardar.Size = New System.Drawing.Size(75, 23)
        Me.btnGuardar.TabIndex = 692
        Me.btnGuardar.Text = "Guardar"
        Me.btnGuardar.UseVisualStyleBackColor = True
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(787, 470)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 691
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'grbSeries
        '
        Me.grbSeries.Controls.Add(Me.rbtSerie3)
        Me.grbSeries.Controls.Add(Me.rbtSerie2)
        Me.grbSeries.Controls.Add(Me.rbtSerie1)
        Me.grbSeries.Controls.Add(Me.btnAceptar)
        Me.grbSeries.Controls.Add(Me.btnAgregarSerie3)
        Me.grbSeries.Controls.Add(Me.btnAgregarSerie1)
        Me.grbSeries.Controls.Add(Me.btnAgregarSerie2)
        Me.grbSeries.Location = New System.Drawing.Point(622, 200)
        Me.grbSeries.Name = "grbSeries"
        Me.grbSeries.Size = New System.Drawing.Size(211, 171)
        Me.grbSeries.TabIndex = 690
        Me.grbSeries.TabStop = False
        Me.grbSeries.Text = "Seleccione"
        '
        'rbtSerie3
        '
        Me.rbtSerie3.AutoSize = True
        Me.rbtSerie3.Location = New System.Drawing.Point(34, 100)
        Me.rbtSerie3.Name = "rbtSerie3"
        Me.rbtSerie3.Size = New System.Drawing.Size(58, 17)
        Me.rbtSerie3.TabIndex = 670
        Me.rbtSerie3.TabStop = True
        Me.rbtSerie3.Text = "Serie 3"
        Me.rbtSerie3.UseVisualStyleBackColor = True
        '
        'rbtSerie2
        '
        Me.rbtSerie2.AutoSize = True
        Me.rbtSerie2.Location = New System.Drawing.Point(34, 71)
        Me.rbtSerie2.Name = "rbtSerie2"
        Me.rbtSerie2.Size = New System.Drawing.Size(58, 17)
        Me.rbtSerie2.TabIndex = 670
        Me.rbtSerie2.TabStop = True
        Me.rbtSerie2.Text = "Serie 2"
        Me.rbtSerie2.UseVisualStyleBackColor = True
        '
        'rbtSerie1
        '
        Me.rbtSerie1.AutoSize = True
        Me.rbtSerie1.Location = New System.Drawing.Point(34, 42)
        Me.rbtSerie1.Name = "rbtSerie1"
        Me.rbtSerie1.Size = New System.Drawing.Size(58, 17)
        Me.rbtSerie1.TabIndex = 670
        Me.rbtSerie1.TabStop = True
        Me.rbtSerie1.Text = "Serie 1"
        Me.rbtSerie1.UseVisualStyleBackColor = True
        '
        'btnAceptar
        '
        Me.btnAceptar.Location = New System.Drawing.Point(71, 138)
        Me.btnAceptar.Name = "btnAceptar"
        Me.btnAceptar.Size = New System.Drawing.Size(75, 23)
        Me.btnAceptar.TabIndex = 669
        Me.btnAceptar.Text = "Aceptar"
        Me.btnAceptar.UseVisualStyleBackColor = True
        '
        'btnAgregarSerie3
        '
        Me.btnAgregarSerie3.Location = New System.Drawing.Point(107, 97)
        Me.btnAgregarSerie3.Name = "btnAgregarSerie3"
        Me.btnAgregarSerie3.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregarSerie3.TabIndex = 669
        Me.btnAgregarSerie3.Text = "Agregar"
        Me.btnAgregarSerie3.UseVisualStyleBackColor = True
        '
        'btnAgregarSerie1
        '
        Me.btnAgregarSerie1.Location = New System.Drawing.Point(108, 39)
        Me.btnAgregarSerie1.Name = "btnAgregarSerie1"
        Me.btnAgregarSerie1.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregarSerie1.TabIndex = 669
        Me.btnAgregarSerie1.Text = "Agregar"
        Me.btnAgregarSerie1.UseVisualStyleBackColor = True
        '
        'btnAgregarSerie2
        '
        Me.btnAgregarSerie2.Location = New System.Drawing.Point(107, 68)
        Me.btnAgregarSerie2.Name = "btnAgregarSerie2"
        Me.btnAgregarSerie2.Size = New System.Drawing.Size(75, 23)
        Me.btnAgregarSerie2.TabIndex = 669
        Me.btnAgregarSerie2.Text = "Agregar"
        Me.btnAgregarSerie2.UseVisualStyleBackColor = True
        '
        'btnAgregarAtleta
        '
        Me.btnAgregarAtleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAgregarAtleta.Location = New System.Drawing.Point(351, 186)
        Me.btnAgregarAtleta.Name = "btnAgregarAtleta"
        Me.btnAgregarAtleta.Size = New System.Drawing.Size(132, 27)
        Me.btnAgregarAtleta.TabIndex = 688
        Me.btnAgregarAtleta.Text = "Agregar Atleta"
        Me.btnAgregarAtleta.UseVisualStyleBackColor = True
        '
        'btnQuitarAtleta
        '
        Me.btnQuitarAtleta.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnQuitarAtleta.Location = New System.Drawing.Point(489, 186)
        Me.btnQuitarAtleta.Name = "btnQuitarAtleta"
        Me.btnQuitarAtleta.Size = New System.Drawing.Size(132, 27)
        Me.btnQuitarAtleta.TabIndex = 687
        Me.btnQuitarAtleta.Text = "Quitar Atleta"
        Me.btnQuitarAtleta.UseVisualStyleBackColor = True
        '
        'btnImprimir
        '
        Me.btnImprimir.Location = New System.Drawing.Point(15, 470)
        Me.btnImprimir.Name = "btnImprimir"
        Me.btnImprimir.Size = New System.Drawing.Size(75, 23)
        Me.btnImprimir.TabIndex = 689
        Me.btnImprimir.Text = "Imprimir"
        Me.btnImprimir.UseVisualStyleBackColor = True
        '
        'dgvPlanillaMedioFondo
        '
        Me.dgvPlanillaMedioFondo.AllowUserToAddRows = False
        Me.dgvPlanillaMedioFondo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvPlanillaMedioFondo.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Seleccionar, Me.Numero, Me.Apellido, Me.Nombre, Me.Institución, Me.Tiempo, Me.Clasificación})
        Me.dgvPlanillaMedioFondo.Location = New System.Drawing.Point(15, 219)
        Me.dgvPlanillaMedioFondo.Name = "dgvPlanillaMedioFondo"
        Me.dgvPlanillaMedioFondo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.dgvPlanillaMedioFondo.Size = New System.Drawing.Size(601, 245)
        Me.dgvPlanillaMedioFondo.TabIndex = 686
        '
        'Seleccionar
        '
        Me.Seleccionar.HeaderText = "Seleccionar"
        Me.Seleccionar.Name = "Seleccionar"
        '
        'Numero
        '
        Me.Numero.HeaderText = "Nro."
        Me.Numero.Name = "Numero"
        Me.Numero.Width = 50
        '
        'Apellido
        '
        Me.Apellido.HeaderText = "Apellido"
        Me.Apellido.Name = "Apellido"
        '
        'Nombre
        '
        Me.Nombre.HeaderText = "Nombre"
        Me.Nombre.Name = "Nombre"
        '
        'Institución
        '
        Me.Institución.HeaderText = "Institución"
        Me.Institución.Name = "Institución"
        '
        'Tiempo
        '
        Me.Tiempo.HeaderText = "Tiempo"
        Me.Tiempo.Name = "Tiempo"
        Me.Tiempo.Width = 60
        '
        'Clasificación
        '
        Me.Clasificación.HeaderText = "Clasif."
        Me.Clasificación.Name = "Clasificación"
        Me.Clasificación.Width = 50
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboJuez3)
        Me.GroupBox1.Controls.Add(Me.cboJuez2)
        Me.GroupBox1.Controls.Add(Me.cboJuez1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label13)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.ComboBox3)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.ComboBox5)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.cboPruebas)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TextBox3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.ComboBox2)
        Me.GroupBox1.Controls.Add(Me.PictureBox1)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ComboBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox1)
        Me.GroupBox1.Controls.Add(Me.TextBox2)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(848, 168)
        Me.GroupBox1.TabIndex = 685
        Me.GroupBox1.TabStop = False
        '
        'cboJuez3
        '
        Me.cboJuez3.FormattingEnabled = True
        Me.cboJuez3.Location = New System.Drawing.Point(502, 136)
        Me.cboJuez3.Name = "cboJuez3"
        Me.cboJuez3.Size = New System.Drawing.Size(121, 21)
        Me.cboJuez3.TabIndex = 626
        '
        'cboJuez2
        '
        Me.cboJuez2.FormattingEnabled = True
        Me.cboJuez2.Location = New System.Drawing.Point(502, 112)
        Me.cboJuez2.Name = "cboJuez2"
        Me.cboJuez2.Size = New System.Drawing.Size(121, 21)
        Me.cboJuez2.TabIndex = 627
        '
        'cboJuez1
        '
        Me.cboJuez1.FormattingEnabled = True
        Me.cboJuez1.Location = New System.Drawing.Point(502, 86)
        Me.cboJuez1.Name = "cboJuez1"
        Me.cboJuez1.Size = New System.Drawing.Size(121, 21)
        Me.cboJuez1.TabIndex = 628
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(458, 139)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(38, 13)
        Me.Label9.TabIndex = 625
        Me.Label9.Text = "Juez 3"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(458, 115)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(38, 13)
        Me.Label12.TabIndex = 624
        Me.Label12.Text = "Juez 2"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(458, 89)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(38, 13)
        Me.Label13.TabIndex = 623
        Me.Label13.Text = "Juez 1"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.Location = New System.Drawing.Point(182, 135)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(60, 15)
        Me.Label17.TabIndex = 622
        Me.Label17.Text = "Categoría"
        '
        'ComboBox3
        '
        Me.ComboBox3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox3.FormattingEnabled = True
        Me.ComboBox3.Location = New System.Drawing.Point(249, 132)
        Me.ComboBox3.Name = "ComboBox3"
        Me.ComboBox3.Size = New System.Drawing.Size(121, 23)
        Me.ComboBox3.TabIndex = 621
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(11, 133)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(35, 15)
        Me.Label10.TabIndex = 617
        Me.Label10.Text = "Sexo"
        '
        'ComboBox5
        '
        Me.ComboBox5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ComboBox5.FormattingEnabled = True
        Me.ComboBox5.Location = New System.Drawing.Point(52, 132)
        Me.ComboBox5.Name = "ComboBox5"
        Me.ComboBox5.Size = New System.Drawing.Size(121, 23)
        Me.ComboBox5.TabIndex = 615
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(126, 100)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(47, 15)
        Me.Label11.TabIndex = 616
        Me.Label11.Text = "Prueba"
        '
        'cboPruebas
        '
        Me.cboPruebas.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cboPruebas.FormattingEnabled = True
        Me.cboPruebas.Location = New System.Drawing.Point(179, 97)
        Me.cboPruebas.Name = "cboPruebas"
        Me.cboPruebas.Size = New System.Drawing.Size(123, 21)
        Me.cboPruebas.TabIndex = 618
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(120, 13)
        Me.Label1.TabIndex = 613
        Me.Label1.Text = "Código de Competencia"
        '
        'TextBox3
        '
        Me.TextBox3.Location = New System.Drawing.Point(42, 97)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(69, 20)
        Me.TextBox3.TabIndex = 165
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(649, 11)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(193, 48)
        Me.Label2.TabIndex = 148
        Me.Label2.Text = "Asociación Atlética " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Córdoba Centro"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'ComboBox2
        '
        Me.ComboBox2.FormattingEnabled = True
        Me.ComboBox2.Location = New System.Drawing.Point(277, 60)
        Me.ComboBox2.Name = "ComboBox2"
        Me.ComboBox2.Size = New System.Drawing.Size(144, 21)
        Me.ComboBox2.TabIndex = 164
        '
        'PictureBox1
        '
        Me.PictureBox1.Image = Global.CAPA_PRESENTACION.My.Resources.Resources._972035_491669154244375_182680477_n
        Me.PictureBox1.Location = New System.Drawing.Point(694, 61)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(100, 79)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 149
        Me.PictureBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(218, 63)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(53, 13)
        Me.Label8.TabIndex = 163
        Me.Label8.Text = "Localidad"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(198, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(44, 13)
        Me.Label3.TabIndex = 150
        Me.Label3.Text = "Nombre"
        '
        'TextBox4
        '
        Me.TextBox4.Location = New System.Drawing.Point(132, 25)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.ReadOnly = True
        Me.TextBox4.Size = New System.Drawing.Size(50, 20)
        Me.TextBox4.TabIndex = 614
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(427, 28)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(34, 13)
        Me.Label4.TabIndex = 151
        Me.Label4.Text = "Lugar"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 104)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(30, 13)
        Me.Label7.TabIndex = 162
        Me.Label7.Text = "Hora"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(446, 60)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(80, 13)
        Me.Label5.TabIndex = 152
        Me.Label5.Text = "Fecha de Inicio"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(532, 54)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(91, 20)
        Me.DateTimePicker1.TabIndex = 160
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(0, 63)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 155
        Me.Label6.Text = "Provincia"
        '
        'ComboBox1
        '
        Me.ComboBox1.FormattingEnabled = True
        Me.ComboBox1.Location = New System.Drawing.Point(57, 60)
        Me.ComboBox1.Name = "ComboBox1"
        Me.ComboBox1.Size = New System.Drawing.Size(150, 21)
        Me.ComboBox1.TabIndex = 159
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(250, 25)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(154, 20)
        Me.TextBox1.TabIndex = 156
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(467, 25)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(167, 20)
        Me.TextBox2.TabIndex = 157
        '
        'PlanilladeMedioFondo
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(873, 506)
        Me.Controls.Add(Me.btnActualizar)
        Me.Controls.Add(Me.btnComenzar)
        Me.Controls.Add(Me.btnGuardar)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.grbSeries)
        Me.Controls.Add(Me.btnAgregarAtleta)
        Me.Controls.Add(Me.btnQuitarAtleta)
        Me.Controls.Add(Me.btnImprimir)
        Me.Controls.Add(Me.dgvPlanillaMedioFondo)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PlanilladeMedioFondo"
        Me.Text = "Planilla de Medio Fondo"
        Me.grbSeries.ResumeLayout(False)
        Me.grbSeries.PerformLayout()
        CType(Me.dgvPlanillaMedioFondo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnActualizar As System.Windows.Forms.Button
    Friend WithEvents btnComenzar As System.Windows.Forms.Button
    Friend WithEvents btnGuardar As System.Windows.Forms.Button
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents grbSeries As System.Windows.Forms.GroupBox
    Friend WithEvents rbtSerie3 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSerie2 As System.Windows.Forms.RadioButton
    Friend WithEvents rbtSerie1 As System.Windows.Forms.RadioButton
    Friend WithEvents btnAceptar As System.Windows.Forms.Button
    Friend WithEvents btnAgregarSerie3 As System.Windows.Forms.Button
    Friend WithEvents btnAgregarSerie1 As System.Windows.Forms.Button
    Friend WithEvents btnAgregarSerie2 As System.Windows.Forms.Button
    Friend WithEvents btnAgregarAtleta As System.Windows.Forms.Button
    Friend WithEvents btnQuitarAtleta As System.Windows.Forms.Button
    Friend WithEvents btnImprimir As System.Windows.Forms.Button
    Friend WithEvents dgvPlanillaMedioFondo As System.Windows.Forms.DataGridView
    Friend WithEvents Seleccionar As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents Numero As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Apellido As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Nombre As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Institución As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Tiempo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Clasificación As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ComboBox2 As System.Windows.Forms.ComboBox
    Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DateTimePicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ComboBox1 As System.Windows.Forms.ComboBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents ComboBox3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ComboBox5 As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents cboPruebas As System.Windows.Forms.ComboBox
    Friend WithEvents cboJuez3 As System.Windows.Forms.ComboBox
    Friend WithEvents cboJuez2 As System.Windows.Forms.ComboBox
    Friend WithEvents cboJuez1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
End Class
