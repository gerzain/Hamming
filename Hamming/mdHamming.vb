Imports System.Math
Module mdHamming
    'Funcion para convertir de binario a texto o texto a binario segun la opcion de direccion
    'se recibe un vector de datos boleanos
    Function BinTexTexBin(ByVal Vector() As Boolean, ByVal Texto As String, ByVal mk As Integer, ByVal Direccion As Boolean)
        Dim i As Integer
        'Si direccion = true, entonces se convertira de texto a binario, y se devolvera un vector
        If Direccion = True Then
            For i = 1 To Texto.Length
                If Texto(i - 1).ToString = 1 Then
                    Vector(i) = True
                Else
                    Vector(i) = False
                End If
            Next i
            Return Vector
            'Si direccion = false, entonces se convertira de binario a texto, y se devolvera un string
            'siguiendo el formato Big Endian
        Else
            Texto = ""
            For i = 1 To mk
                If Vector(i) = True Then
                    Texto = Texto + "1"
                Else
                    Texto = Texto + "0"
                End If
            Next i
            Return Texto
        End If
    End Function

    'Funcion para armar posiciones de la data, en este caso la data debe ir en las posiciones
    'que no son multiplos de 2^k, (posiciones 3, 5, 6, 7, 9, 10, 11, 12, 13, 14, 15, 17, etc.)
    Function ArmarPosiciones(ByVal Vector() As Boolean, ByVal m As Integer)
        Dim VPosicion(2 * m + 1) As Boolean
        Dim i, c, mk, Potencia As Integer
        Dim Centinela As Boolean = False
        i = 3
        c = 1
        Potencia = 2
        While c <= m And Centinela = False
            VPosicion(i) = Vector(c)
            If c <> m Then
                c = c + 1
                i = i + 1
                If i = Pow(2, Potencia) Then
                    Potencia = Potencia + 1
                    i = i + 1
                End If
            Else
                Centinela = True
            End If
        End While
        mk = i

        Clipboard.SetText(mk.ToString)
        Return VPosicion
    End Function
    'Funcion para sacar los miniverctores que son necesarios para el calculo de cada bit de paridad
    'Posición 1: salta 1, comprueba 1, salta 1, comprueba 1, etc.
    'Posición 2: comprueba 1, salta 2, comprueba 2, salta 2, comprueba 2, etc.
    'Posición 4: comprueba 3, salta 4, comprueba 4, salta 4, comprueba 4, etc.
    'Posición 8: comprueba 7, salta 8, comprueba 8, salta 8, comprueba 8, etc.
    'Posición 16: comprueba 15, salta 16, comprueba 16, salta 16, comprueba 16, etc.
    Function ArmarSecuenciaPar(ByVal Vector() As Boolean, ByVal Index As Integer, ByVal mk As Integer, ByVal m As Integer)
        Dim VSecuencia(m) As Boolean
        Dim Cantidad As Integer = Pow(2, Index)
        Dim i, c, Terminos, Puntero As Integer

        i = 1
        For c = Cantidad To mk Step 2 * Cantidad
            VSecuencia(i) = Vector(c)

            Puntero = c
            Terminos = 1
            While Terminos < Cantidad
                Terminos = Terminos + 1
                i = i + 1
                If (i <= m) And (Puntero + 1 <= mk) Then
                    VSecuencia(i) = Vector(Puntero + 1)
                End If
                Puntero = Puntero + 1
            End While
            i = i + 1
        Next c

        Return VSecuencia
    End Function
    'Funcion generadora de paridad entre 2 bits
    Function GParidadPar(ByVal A As Boolean, ByVal B As Boolean) As Boolean
        GParidadPar = A Xor B
        Return GParidadPar
    End Function
    'Funcion recursiva para determinar la paridad de los minivectores
    'generados para cada bit de paridad
    Function DetParidad(ByVal Vector() As Boolean, ByVal m As Integer) As Boolean
        Dim i As Integer

        If m <= 1 Then
            DetParidad = Vector(m)
            Return DetParidad
        End If

        DetParidad = GParidadPar(Vector(1), Vector(2))

        If m <= 2 Then
            Return DetParidad
        End If
        For i = 3 To m
            DetParidad = GParidadPar(DetParidad, Vector(i))
        Next i

        Return DetParidad
    End Function
    'Funcion que enlaza el vector de datos con el vector de paridades
    'en sus posiciones designadas
    Function ArmarSecuenciaYParidad(ByVal Vector() As Boolean, ByVal VParidad() As Boolean, ByVal m As Integer, ByVal k As Integer)
        Dim VHamming(m + k) As Boolean
        Dim i, c As Integer
        i = 1
        c = 1
        While (i <= (m + k)) And (c <= k)
            Vector(i) = VParidad(c)
            i = Pow(2, c)
            c = c + 1
        End While
        VHamming = Vector

        Return VHamming
    End Function
    'Funcion para convertir un binario a su representacion en numero entero
    'siguiendo el formato Big Endian
    Function BinarioANumero(ByVal Binario As String) As Integer
        Dim Tamano, i, c As Integer
        BinarioANumero = 0
        Tamano = Binario.Length
        c = Tamano
        For i = Tamano To 1 Step -1
            If Binario(i - 1).ToString = 1 Then
                BinarioANumero = Pow(2, i - 1) + BinarioANumero
            Else
                BinarioANumero = BinarioANumero
            End If
        Next i
        Return BinarioANumero
    End Function
End Module
