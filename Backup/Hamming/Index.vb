Imports System.Math
Public Class Index
    Private Sub Index_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.txtHamming.Enabled = False
        Me.txtCorregido.Enabled = False
        Me.btnError.Enabled = False
    End Sub
    Private Sub btnHamming_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnHamming.Click
        Dim Vector(100) As Boolean
        Dim Palabra As String
        Dim i, m, k, mk As Integer

        Palabra = Trim(Me.txtBinario.Text)
        m = Palabra.Length
        If m <= 2 Then
            MsgBox("Analizamos mas de 2 bits", MsgBoxStyle.Exclamation)
            Me.txtBinario.Clear()
            Me.txtHamming.Clear()
            Me.txtBError.Clear()
            Me.txtCorregido.Clear()
            Me.txtBinario.Focus()
            Exit Sub
        End If

        Vector = BinTexTexBin(Vector, Palabra, 0, True)
        Vector = ArmarPosiciones(Vector, m)
    
        mk = Val(Clipboard.GetText())
        k = mk - m

        'Este porcion de codigo ta demas, solo lo hago para ver paso a paso
        Dim Paso1 As String
        Paso1 = BinTexTexBin(Vector, "", mk, False)
        Me.lbPasos.Items.Add("Paso 1 : Posiciones para bits de datos")
        Me.lbPasos.Items.Add(Paso1)
        Me.lbPasos.Items.Add(m.ToString + " bits de data inicial")
        Me.lbPasos.Items.Add(k.ToString + " bits de paridad a agregar")
        Me.lbPasos.Items.Add(mk.ToString + " bits en total de data protegida")
        'RichieRichieRichieRichieRichieRichieRichieRichieRichieRichieRichieRichie

        Dim sinParidad(k) As Boolean
        Dim Paridad(k) As Boolean

        For i = 0 To k - 1
            sinParidad = ArmarSecuenciaPar(Vector, i, mk, m)
            Paridad(i + 1) = DetParidad(sinParidad, m)
        Next i

        'Este porcion de codigo ta demas, solo lo hago para ver paso a paso
        Dim Paso2 As String
        Paso2 = BinTexTexBin(Paridad, "", k, False)
        Me.lbPasos.Items.Add("Paso 2 : Calculamos los bits de paridad")
        Me.lbPasos.Items.Add(Paso2)
        'RichieRichieRichieRichieRichieRichieRichieRichieRichieRichieRichieRichie


        Dim VHamming(mk) As Boolean
        Dim Hamming As String

        VHamming = ArmarSecuenciaYParidad(Vector, Paridad, m, k)
        Hamming = BinTexTexBin(VHamming, "", mk, False)

        'Este porcion de codigo ta demas, solo lo hago para ver paso a paso
        Dim Paso3 As String
        Paso3 = BinTexTexBin(VHamming, "", mk, False)
        Me.lbPasos.Items.Add("Paso 3 : Enlazamos los bits de paridad con los datos en sus posiciones especificas")
        Me.lbPasos.Items.Add(Paso3)
        'RichieRichieRichieRichieRichieRichieRichieRichieRichieRichieRichieRichie

        Me.txtHamming.Text = Hamming
        Me.txtBError.Text = Hamming
        Me.txtBError.MaxLength = Me.txtHamming.Text.Length
        Me.btnError.Enabled = True
    End Sub

    Private Sub btnError_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnError.Click
        Dim Vector(100) As Boolean
        Dim Palabra, Temp As String
        Dim i, m, k, mk As Integer

        Palabra = Trim(Me.txtBError.Text)
        Temp = Palabra

        'Este porcion de codigo ta demas, solo lo hago para ver paso a paso
        Dim Paso4 As String
        Paso4 = Palabra
        Me.lbPasos.Items.Add("Paso 4 : Cargamos la nueva data con un bit modificado")
        Me.lbPasos.Items.Add(Paso4)
        'RichieRichieRichieRichieRichieRichieRichieRichieRichieRichieRichieRichie

        mk = Palabra.Length
        Vector = BinTexTexBin(Vector, Palabra, 0, True)
        k = 0
        For i = 0 To mk
            If Pow(2, i) <= mk Then
                k = k + 1
            Else
                i = mk
            End If
        Next i
        m = mk - k
        Dim sinParidad(k) As Boolean
        Dim Paridad(k) As Boolean

        For i = 0 To k - 1
            sinParidad = ArmarSecuenciaPar(Vector, i, mk, m)
            Paridad(i + 1) = DetParidad(sinParidad, m)
        Next i

        Dim Binario As String
        Dim NroError As Integer

        Binario = BinTexTexBin(Paridad, "", k, False)
        NroError = BinarioANumero(Binario)

        'Este porcion de codigo ta demas, solo lo hago para ver paso a paso
        Dim Paso5 As String
        Paso5 = Binario
        Me.lbPasos.Items.Add("Paso 5 : Calculamos los bits de paridad de la nueva data")
        Me.lbPasos.Items.Add("formato Big Endian")
        Me.lbPasos.Items.Add(Paso5)
        Me.lbPasos.Items.Add(NroError.ToString + " Valor decimal de los bits de paridad, indican el bit de error")
        'RichieRichieRichieRichieRichieRichieRichieRichieRichieRichieRichieRichie

        If NroError = 0 Then
            Me.lbResultado.Text = "No existe error de codigo"
        Else
            Me.lbResultado.Text = "Existe un error en el bit " + NroError.ToString
        End If

        Palabra = ""
        For i = 0 To mk - 1
            If i <> NroError - 1 Then
                Palabra = Palabra + Temp(i)
            Else
                If Temp(i) = "1" Then
                    Palabra = Palabra + "0"
                Else
                    Palabra = Palabra + "1"
                End If
            End If
        Next i
        Me.txtCorregido.Text = Palabra
    End Sub

    Private Sub txtBinario_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBinario.KeyPress
        If InStr(1, "01" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub

    Private Sub txtBError_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBError.KeyPress
        If InStr(1, "01" & Chr(8), e.KeyChar) = 0 Then
            e.KeyChar = ""
        End If
    End Sub
End Class

