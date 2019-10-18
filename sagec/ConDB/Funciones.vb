Public Class Funciones
    Public Const MaxCuotas = 240
    Public LeerLíneaEnArchivoDeTexto As String
    Private m_sOriginal As String
    Private m_sClave As String
    Private Const mc_sClave As String = "123456"
    Private m_RaiseError As Boolean

    Private m_Accion As Integer

    Public Function Valcarcateres(ByVal StrCad As String) As String
        Dim strCadena As String = ""
        Dim strCadValidos As String = ""
        Dim strCaracValidos As String = "abcdefghijklmmnñopqrstuvwxyz"
        strCaracValidos &= UCase(strCaracValidos)
        strCaracValidos &= "1234567890!$%&/()=?¡¿-.,;|°:_+*# "
        StrCad = Replace(StrCad, "Ñ", "N")
        StrCad = Replace(StrCad, "á", "a")
        StrCad = Replace(StrCad, "é", "e")
        StrCad = Replace(StrCad, "í", "i")
        StrCad = Replace(StrCad, "ó", "o")
        StrCad = Replace(StrCad, "ú", "u")
        StrCad = Replace(StrCad, "Á", "A")
        StrCad = Replace(StrCad, "É", "E")
        StrCad = Replace(StrCad, "Í", "I")
        StrCad = Replace(StrCad, "Ó", "O")
        StrCad = Replace(StrCad, "Ú", "U")
        For i = 1 To Len(StrCad)
            If InStr(1, strCaracValidos, Mid(StrCad, i, 1)) > 0 Then
                strCadValidos &= Mid(StrCad, i, 1)
            Else
                strCadValidos &= " "
            End If
        Next
        Return strCadValidos
    End Function

    Public Sub FechasPago(ByVal fechaActivacion As Date, ByVal FecPago As Date, ByVal NumCuotas As Integer, ByVal Periodicidad As Integer, ByRef FecProx() As Date, ByRef DiasCuota() As Integer, ByRef DiasAcumul() As Integer)
        Dim MM, YYYY, i, Periodo, FinDeMes As Integer
        Dim FecProxi, FecAnte As Date
        Dim wFec, Ult_Dia As String
        Periodo = CInt(Periodicidad / 30)
        For i = 1 To MaxCuotas
            DiasCuota(i) = 0
            DiasAcumul(i) = 0
        Next i
        FecProxi = FecPago
        FecAnte = fechaActivacion
        Ult_Dia = "N"
        For i = 1 To NumCuotas
            FinDeMes = TOP_MES(FecProxi.Month, FecProxi.Year)
            If FecPago.Day = FinDeMes And i = 1 Then
                Ult_Dia = "S"
            End If
            If FecPago.Day > FinDeMes Then
                wFec = FinDeMes.ToString + "/" + FecProxi.Month.ToString + "/" + FecProxi.Year.ToString
                FecProxi = CDate(wFec)
                FecProx(i) = ProximoHabil(FecProxi)
            Else
                FecProx(i) = ProximoHabil(FecProxi)
            End If
            MM = FecProxi.AddMonths(Periodo).Month
            YYYY = FecProxi.AddMonths(Periodo).Year
            If Ult_Dia = "S" Or FecPago.Day > TOP_MES(MM, YYYY) Then
                wFec = TOP_MES(MM, YYYY).ToString + "/" + MM.ToString + "/" + YYYY.ToString
            Else
                wFec = FecPago.Day.ToString + "/" + FecProxi.AddMonths(Periodo).Month.ToString + "/" + FecProxi.AddMonths(Periodo).Year.ToString
            End If
            DiasCuota(i) = DateDiff(DateInterval.Day, FecAnte, FecProx(i))
            DiasAcumul(i) = DiasAcumul(i - 1) + DiasCuota(i)
            FecProxi = CDate(wFec) 'FecProx(i).AddMonths(Periodo)
            FecAnte = FecProx(i)
        Next i
    End Sub
    Public Function ProximoHabil(ByRef fecha As Date) As Date
        'NO sabado ni domingo
        If fecha.DayOfWeek = DayOfWeek.Saturday Then
            ProximoHabil = fecha.AddDays(2)
        ElseIf fecha.DayOfWeek = DayOfWeek.Sunday Then
            ProximoHabil = fecha.AddDays(1)
        Else
            ProximoHabil = fecha
        End If
    End Function
    Function COEF_IC(ByVal Tasa As Double, ByVal Plazo As Integer, ByVal Base As Integer) As Double
        Dim Coef, Expn As Double
        Coef = (Tasa / 100) + 1
        Expn = Plazo / Base
        Coef = Math.Pow(Coef, Expn)
        Return (Coef)
    End Function
    Function COEF_IS(ByVal Tasa As Double, ByVal Plazo As Integer, ByVal Base As Integer) As Double
        Dim Coef As Double
        Coef = (Tasa / 100) * (Plazo / Base) + 1
        Return (Coef)
    End Function
    Sub MONTOFINAL(ByVal Monto_Ini As Double, ByVal Tasa As Double, ByVal Plazo As Integer, ByVal Base As Integer, ByVal Tipo_Int As Integer, ByRef Monto_Fin As Double, ByRef Interes As Double)
        Dim Coef As Double
        If Tipo_Int = 0 Then
            Coef = COEF_IS(Tasa, Plazo, Base)
        Else
            Coef = COEF_IC(Tasa, Plazo, Base)
        End If
        Interes = Monto_Ini * (Coef - 1.0)
        Monto_Fin = Monto_Ini + Interes
    End Sub
    Function TOP_MES(ByVal mm As Integer, ByVal a4 As Integer) As Integer
        Dim dias_mes(,) As Integer = {{0, 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}, {0, 31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31}}
        Dim bisiesto As Integer
        If (a4 / 4) <> 0 Then
            bisiesto = 0
        Else
            bisiesto = 1
        End If
        Return (dias_mes(bisiesto, mm))
    End Function
    Public Function DesEncriptar(Optional ByVal sOriginal As String = "", _
                                 Optional ByVal sClave As String = "") As String
        ' Esta es una función que llamará directamente a ConvertirClave
        '
        m_Accion = 0
        DesEncriptar = ConvertirClave(sOriginal, sClave)
    End Function

    Public Function Encriptar(Optional ByVal sOriginal As String = "", _
                              Optional ByVal sClave As String = "") As String
        ' Esta es una función que llamará directamente a ConvertirClave
        '
        m_Accion = 1
        Encriptar = ConvertirClave(sOriginal, sClave)
    End Function

    Public Function ConvertirClave(Optional ByVal sOriginal As String = "", _
                                   Optional ByVal sClave As String = "") As String

        Dim LenOri As Long
        Dim LenClave As Long
        Dim i As Long, j As Long
        Dim cO As Long, cC As Long
        Dim k As Long
        Dim v As String

        ' se usarán los valores de las propiedades
        If Len(sOriginal) = 0 Then _
            sOriginal = m_sOriginal

        If Len(sClave) = 0 Then _
            sClave = m_sClave

        ' Si se especifica el último parámetro,

        LenOri = Len(sOriginal)
        LenClave = Len(sClave)

        v = Space$(LenOri)
        i = 0&
        For j = 1 To LenOri
            i = i + 1
            If i > LenClave Then
                i = 1
            End If
            cO = Asc(Mid$(sOriginal, j, 1))
            cC = Asc(Mid$(sClave, i, 1))
            If m_Accion Then
                k = cO + cC
                If k > 255 Then
                    k = k - 255
                End If
            Else
                k = cO - cC
                If k < 0 Then
                    k = k + 255
                End If
            End If
            Mid$(v, j, 1) = Chr(k)
        Next

        ConvertirClave = v
    End Function
End Class