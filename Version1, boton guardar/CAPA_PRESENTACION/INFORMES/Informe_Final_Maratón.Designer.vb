<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Informe_Final_Maratón
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
        Me.btnCerrar = New System.Windows.Forms.Button()
        Me.dgvMaratonMaestro = New System.Windows.Forms.DataGridView()
        Me.btnReporte = New System.Windows.Forms.Button()
        Me.dgvMaratonDetalle = New System.Windows.Forms.DataGridView()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        CType(Me.dgvMaratonMaestro, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dgvMaratonDetalle, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'btnCerrar
        '
        Me.btnCerrar.Location = New System.Drawing.Point(578, 478)
        Me.btnCerrar.Name = "btnCerrar"
        Me.btnCerrar.Size = New System.Drawing.Size(75, 23)
        Me.btnCerrar.TabIndex = 106
        Me.btnCerrar.Text = "Cerrar"
        Me.btnCerrar.UseVisualStyleBackColor = True
        '
        'dgvMaratonMaestro
        '
        Me.dgvMaratonMaestro.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaratonMaestro.Location = New System.Drawing.Point(15, 50)
        Me.dgvMaratonMaestro.Name = "dgvMaratonMaestro"
        Me.dgvMaratonMaestro.Size = New System.Drawing.Size(641, 199)
        Me.dgvMaratonMaestro.TabIndex = 102
        '
        'btnReporte
        '
        Me.btnReporte.Location = New System.Drawing.Point(497, 478)
        Me.btnReporte.Name = "btnReporte"
        Me.btnReporte.Size = New System.Drawing.Size(75, 23)
        Me.btnReporte.TabIndex = 107
        Me.btnReporte.Text = "Reporte"
        Me.btnReporte.UseVisualStyleBackColor = True
        '
        'dgvMaratonDetalle
        '
        Me.dgvMaratonDetalle.AllowUserToAddRows = False
        Me.dgvMaratonDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvMaratonDetalle.Location = New System.Drawing.Point(12, 292)
        Me.dgvMaratonDetalle.Name = "dgvMaratonDetalle"
        Me.dgvMaratonDetalle.Size = New System.Drawing.Size(641, 163)
        Me.dgvMaratonDetalle.TabIndex = 108
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(249, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(145, 16)
        Me.Label2.TabIndex = 115
        Me.Label2.Text = "Lista de Competencias"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(271, 262)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(101, 16)
        Me.Label1.TabIndex = 115
        Me.Label1.Text = "Vista Preliminar"
        '
        'Informe_Final_Maratón
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(668, 513)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.dgvMaratonDetalle)
        Me.Controls.Add(Me.btnReporte)
        Me.Controls.Add(Me.btnCerrar)
        Me.Controls.Add(Me.dgvMaratonMaestro)
        Me.Name = "Informe_Final_Maratón"
        Me.Text = "Informe Final Maratón"
        CType(Me.dgvMaratonMaestro, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dgvMaratonDetalle, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCerrar As System.Windows.Forms.Button
    Friend WithEvents dgvMaratonMaestro As System.Windows.Forms.DataGridView
    Friend WithEvents btnReporte As System.Windows.Forms.Button
    Friend WithEvents dgvMaratonDetalle As System.Windows.Forms.DataGridView
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
End Class
