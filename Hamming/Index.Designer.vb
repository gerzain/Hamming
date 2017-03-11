<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Index
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Index))
        Me.txtBinario = New System.Windows.Forms.TextBox
        Me.btnHamming = New System.Windows.Forms.Button
        Me.txtHamming = New System.Windows.Forms.TextBox
        Me.txtCorregido = New System.Windows.Forms.TextBox
        Me.btnError = New System.Windows.Forms.Button
        Me.txtBError = New System.Windows.Forms.TextBox
        Me.lbError = New System.Windows.Forms.Label
        Me.lbResultado = New System.Windows.Forms.Label
        Me.lbPasos = New System.Windows.Forms.ListBox
        Me.SuspendLayout()
        '
        'txtBinario
        '
        Me.txtBinario.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBinario.Location = New System.Drawing.Point(12, 15)
        Me.txtBinario.MaxLength = 64
        Me.txtBinario.Name = "txtBinario"
        Me.txtBinario.Size = New System.Drawing.Size(250, 47)
        Me.txtBinario.TabIndex = 6
        '
        'btnHamming
        '
        Me.btnHamming.Location = New System.Drawing.Point(268, 15)
        Me.btnHamming.Name = "btnHamming"
        Me.btnHamming.Size = New System.Drawing.Size(87, 27)
        Me.btnHamming.TabIndex = 8
        Me.btnHamming.Text = "Hamming"
        Me.btnHamming.UseVisualStyleBackColor = True
        '
        'txtHamming
        '
        Me.txtHamming.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHamming.Location = New System.Drawing.Point(12, 68)
        Me.txtHamming.MaxLength = 64
        Me.txtHamming.Name = "txtHamming"
        Me.txtHamming.Size = New System.Drawing.Size(609, 47)
        Me.txtHamming.TabIndex = 9
        '
        'txtCorregido
        '
        Me.txtCorregido.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCorregido.Location = New System.Drawing.Point(12, 216)
        Me.txtCorregido.MaxLength = 64
        Me.txtCorregido.Name = "txtCorregido"
        Me.txtCorregido.Size = New System.Drawing.Size(609, 47)
        Me.txtCorregido.TabIndex = 12
        '
        'btnError
        '
        Me.btnError.Location = New System.Drawing.Point(534, 130)
        Me.btnError.Name = "btnError"
        Me.btnError.Size = New System.Drawing.Size(87, 27)
        Me.btnError.TabIndex = 11
        Me.btnError.Text = "Error"
        Me.btnError.UseVisualStyleBackColor = True
        '
        'txtBError
        '
        Me.txtBError.Font = New System.Drawing.Font("Calibri", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBError.Location = New System.Drawing.Point(12, 163)
        Me.txtBError.MaxLength = 64
        Me.txtBError.Name = "txtBError"
        Me.txtBError.Size = New System.Drawing.Size(609, 47)
        Me.txtBError.TabIndex = 10
        '
        'lbError
        '
        Me.lbError.AutoSize = True
        Me.lbError.Location = New System.Drawing.Point(9, 145)
        Me.lbError.Name = "lbError"
        Me.lbError.Size = New System.Drawing.Size(287, 15)
        Me.lbError.TabIndex = 13
        Me.lbError.Text = "Varia un Bit de este TextBox para econtrar el error :"
        '
        'lbResultado
        '
        Me.lbResultado.AutoSize = True
        Me.lbResultado.Location = New System.Drawing.Point(9, 266)
        Me.lbResultado.Name = "lbResultado"
        Me.lbResultado.Size = New System.Drawing.Size(68, 15)
        Me.lbResultado.TabIndex = 14
        Me.lbResultado.Text = "Resultado :"
        '
        'lbPasos
        '
        Me.lbPasos.FormattingEnabled = True
        Me.lbPasos.ItemHeight = 15
        Me.lbPasos.Location = New System.Drawing.Point(12, 305)
        Me.lbPasos.Name = "lbPasos"
        Me.lbPasos.Size = New System.Drawing.Size(609, 154)
        Me.lbPasos.TabIndex = 15
        '
        'Index
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 15.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(633, 472)
        Me.Controls.Add(Me.lbPasos)
        Me.Controls.Add(Me.lbResultado)
        Me.Controls.Add(Me.lbError)
        Me.Controls.Add(Me.txtCorregido)
        Me.Controls.Add(Me.btnError)
        Me.Controls.Add(Me.txtBError)
        Me.Controls.Add(Me.txtHamming)
        Me.Controls.Add(Me.btnHamming)
        Me.Controls.Add(Me.txtBinario)
        Me.Font = New System.Drawing.Font("Calibri", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Index"
        Me.Text = "Index"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtBinario As System.Windows.Forms.TextBox
    Friend WithEvents btnHamming As System.Windows.Forms.Button
    Friend WithEvents txtHamming As System.Windows.Forms.TextBox
    Friend WithEvents txtCorregido As System.Windows.Forms.TextBox
    Friend WithEvents btnError As System.Windows.Forms.Button
    Friend WithEvents txtBError As System.Windows.Forms.TextBox
    Friend WithEvents lbError As System.Windows.Forms.Label
    Friend WithEvents lbResultado As System.Windows.Forms.Label
    Friend WithEvents lbPasos As System.Windows.Forms.ListBox

End Class
