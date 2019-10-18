Imports System.Web.UI.WebControls

Public MustInherit Class CtlTxt
    Inherits System.Web.UI.UserControl
    Private Out_TipoDatos As String '--- tipo de datos 
    Private Out_SetFocus As Boolean = False
    Private Out_AutoPostBack As Boolean = False
    Private Out_Ancho As Integer
    Private Out_Ele As Integer
    Private Out_Maximo As Integer
    Private Out_Decimal As Boolean
    Private Out_Formateo As Boolean
    Private Out_Enfoque As Boolean
    Private Out_Index As Boolean
    '---> declaracion de Propiedades del objeto 
    Public Sub Enfoque()
        TextBox1.Focus()
    End Sub
    Public Property Color() As Drawing.Color
        Get
            Return TextBox1.BackColor
        End Get
        Set(ByVal value As Drawing.Color)
            TextBox1.BackColor = value
        End Set
    End Property
    Public Property ColorTexto() As Drawing.Color
        Get
            Return TextBox1.ForeColor
        End Get
        Set(ByVal value As Drawing.Color)
            TextBox1.ForeColor = value
        End Set
    End Property
    Public Property ColorBorde() As Drawing.Color
        Get
            Return TextBox1.BorderColor
        End Get
        Set(ByVal value As Drawing.Color)
            TextBox1.BorderColor = value
        End Set
    End Property
    Public Property Desactiva() As Boolean
        Get
            Return TextBox1.Enabled
        End Get
        Set(ByVal value As Boolean)
            TextBox1.Enabled = value
        End Set
    End Property
    Public Property SoloLetura() As Boolean
        Get
            Return TextBox1.ReadOnly
        End Get
        Set(ByVal value As Boolean)
            TextBox1.ReadOnly = value
        End Set
    End Property
    Public Property Multilinea() As Boolean
        Get
            Return TextBox1.TextMode = TextBoxMode.MultiLine
        End Get
        Set(ByVal value As Boolean)
            If value = True Then
                TextBox1.TextMode = TextBoxMode.MultiLine
            Else
                TextBox1.TextMode = TextBoxMode.SingleLine
            End If
        End Set
    End Property
    Public Property MultiWrap() As Boolean
        Get
            Return TextBox1.Wrap
        End Get
        Set(ByVal value As Boolean)
            TextBox1.Wrap = value
        End Set
    End Property
    Public Property TabIndex() As Integer
        Get
            Return TextBox1.TabIndex
        End Get
        Set(ByVal value As Integer)
            TextBox1.TabIndex = value
        End Set
    End Property
    Public Property Dec() As Boolean
        Get
            Return Out_Decimal
        End Get
        Set(ByVal value As Boolean)
            Out_Decimal = value
        End Set
    End Property
    Public Property Formateo() As Boolean
        Get
            Return Out_Formateo
        End Get
        Set(ByVal value As Boolean)
            Out_Formateo = value
        End Set
    End Property
    Public Property TipoDatos() As String
        Get
            Return Out_TipoDatos
        End Get
        Set(ByVal value As String)
            If value < Me.TipoDatos Then
                Throw New Exception _
                    ("El valor ingresado no es correcto o debe contener minimo un valor")
            Else
                Out_TipoDatos = value
                If value = "Texto" Then
                    TextBox1.Attributes.Add("onKeypress", "javascript:var str=String.fromCharCode(window.event.keyCode);var may=str.toUpperCase(); if (may=='Ñ'){may='N'}; var code=may.charCodeAt(0);window.event.keyCode=code;")
                    'TextBox1.Attributes.Add("onkeydown", "javascript:this.value=this.value.toUpperCase();")
                ElseIf value = "Numerico" Then
                    If Dec = True Then
                        If Formateo = True Then
                            TextBox1.Attributes.Add("onkeypress", "return(currencyFormat(this,',','.',event))")
                        Else
                            TextBox1.Attributes.Add("onkeypress", "onlyDigits(event,'decOK')")
                        End If
                    Else
                        TextBox1.Attributes.Add("onkeypress", "onlyDigits(event,'noDec')")
                    End If
                ElseIf value = "Fecha" Then
                    TextBox1.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase();")
                End If
            End If
        End Set
    End Property
    Public Property Text() As String
        Get
            Return TextBox1.Text
        End Get
        Set(ByVal value As String)
            TextBox1.Text = value
            TextBox1.ToolTip = value
        End Set
    End Property
    Public ReadOnly Property Length() As String
        Get
            Return Len(Trim(TextBox1.Text))
        End Get
    End Property
    Public Property Ancho() As Integer
        Get
            Return Out_Ancho
        End Get
        Set(ByVal value As Integer)
            If value < Me.Ancho Then
                Throw New Exception _
                    ("El valor ingresado no es correcto o deber ser mayor que cero")
            Else
                Out_Ancho = value
                TextBox1.Width = value
            End If
        End Set
    End Property
    Public Property Largo() As String
        Get
            Return TextBox1.Height.ToString
        End Get
        Set(ByVal value As String)
            TextBox1.Height = Val(value)
        End Set
    End Property
    Public Property Maximo() As Integer
        Get
            Return Out_Maximo
        End Get
        Set(ByVal value As Integer)
            If value < Me.Maximo Then
                Throw New Exception _
                    ("El valor ingresado no es correcto o deber ser mayor que cero")
            Else
                Out_Maximo = value
                TextBox1.MaxLength = Out_Maximo
            End If
        End Set
    End Property
    Public Property AutoPostBack() As Boolean
        Get
            Return Out_AutoPostBack
        End Get
        Set(ByVal value As Boolean)
            Out_AutoPostBack = value
        End Set
    End Property
    '----> logica de conexion a la base de datos 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load, Me.Load
        If (Not MyBase.IsPostBack) Then
            'TextBox1.Attributes.Add("onkeyup", "javascript:this.value=this.value.toUpperCase();")
            'Dim scriptText As String = ""
            'scriptText &= "<script>"
            'scriptText &= "	var isIE = document.all?true:false; "
            'scriptText &= "	var isNS = document.layers?true:false; "
            'scriptText &= "function onlyDigits(e,decReq){"
            'scriptText &= "	var key = (isIE) ? window.event.keyCode : e.which; "
            'scriptText &= "	var obj = (isIE) ? event.srcElement : e.target; "
            'scriptText &= "	var isNum = (key > 47 && key < 58) ? true:false;"
            'scriptText &= "	var dotOK = (key==46 && decReq=='decOK' && (obj.value.indexOf('.')<0 || obj.value.length==0)) ? true:false;"
            'scriptText &= "	window.event.keyCode = (!isNum && !dotOK && isIE) ? 0:key; "
            'scriptText &= "	e.which = (!isNum && !dotOK && isNS) ? 0:key;"
            'scriptText &= "	return (isNum || dotOK);"
            'scriptText &= "}"
            'scriptText &= "</script>"
            'Response.Write(scriptText)



            'scriptText = ""
            'scriptText &= "<SCRIPT LANGUAGE='JavaScript'>"
            'scriptText &= "<!-- Begin"
            'scriptText &= "function currencyFormat(fld, milSep, decSep, e) {"
            'scriptText &= "var sep = 0;"
            'scriptText &= "var key = '';"
            'scriptText &= "var i = j = 0;"
            'scriptText &= "var len = len2 = 0;"
            'scriptText &= "var strCheck = '0123456789';"
            'scriptText &= "var aux = aux2 = '';"
            'scriptText &= "var whichCode = (window.Event) ? e.which : e.keyCode;"
            'scriptText &= "if (whichCode == 13) return true;  // Enter"
            'scriptText &= "key = String.fromCharCode(whichCode);  // Get key value from key code"
            'scriptText &= "if (strCheck.indexOf(key) == -1) return false;  // Not a valid key"
            'scriptText &= "len = fld.value.length;"
            'scriptText &= "for(i = 0; i < len; i++)"
            'scriptText &= "if ((fld.value.charAt(i) != '0') && (fld.value.charAt(i) != decSep)) break;"
            'scriptText &= "aux = '';"
            'scriptText &= "for(; i < len; i++)"
            'scriptText &= "if (strCheck.indexOf(fld.value.charAt(i))!=-1) aux += fld.value.charAt(i);"
            'scriptText &= "aux += key;"
            'scriptText &= "len = aux.length;"
            'scriptText &= "if (len == 0) fld.value = '';"
            'scriptText &= "if (len == 1) fld.value = '0'+ decSep + '0' + aux;"
            'scriptText &= "if (len == 2) fld.value = '0'+ decSep + aux;"
            'scriptText &= "if (len > 2) {"
            'scriptText &= "aux2 = '';"
            'scriptText &= "for (j = 0, i = len - 3; i >= 0; i--) {"
            'scriptText &= "if (j == 3) {"
            'scriptText &= "aux2 += milSep;"
            'scriptText &= "j = 0;"
            'scriptText &= "}"
            'scriptText &= "aux2 += aux.charAt(i);"
            'scriptText &= "j++;"
            'scriptText &= "}"
            'scriptText &= "fld.value = '';"
            'scriptText &= "len2 = aux2.length;"
            'scriptText &= "for (i = len2 - 1; i >= 0; i--)"
            'scriptText &= "fld.value += aux2.charAt(i);"
            'scriptText &= "fld.value += decSep + aux.substr(len - 2, len);"
            'scriptText &= "}"
            'scriptText &= "return false;"
            'scriptText &= "}"
            'scriptText &= "//  End -->"
            'scriptText &= "</script>"
            'Response.Write(scriptText)
            'Call Carga_DDL()
        End If
    End Sub

    '----> Eventos de lo controles
    Public Event Enter()  '----> Evento indica la posicion del cursor 

    Public Sub Posiciona()
        TextBox1.Focus()
    End Sub
    Public Sub Carga_DDL()
    End Sub

    Protected Sub TextBox1_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles TextBox1.TextChanged
        RaiseEvent Enter()
    End Sub
End Class



