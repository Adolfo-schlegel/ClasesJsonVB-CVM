Imports System.IO
Imports System.Net
Imports System.Net.Http
Imports Newtonsoft.Json

Module Program
    Private Const URL_CV_ExistenRegistros = "http://uxd1wapp1.admin.cargill.com:8071/sap/opu/odata/sap/ZOD_LIBRO_COMPRAS_SRV_02/PurchaseDocQuantitySet?$format=json"
    Public URL_CV_RegistrosLote As String = "http://uxd1wapp1.admin.cargill.com:8071/sap/opu/odata/sap/ZOD_LIBRO_COMPRAS_SRV_02/PurchaseDocHeaderSet(NroLote=22)/NP_PurchaseDocHeaderItems?$format=json"

    Sub Main(args As String())
        ' Dim result As String = CV_ExisteRegistros()
        'Console.WriteLine(result)
        'Console.ReadKey()
    End Sub

    Public Function CV_ExisteRegistros()

        Dim lstr_res As String = "OK"

        Dim result = GetExistenRegistros("https://localhost:7212/api/IntermediaSAP/GetExistenRegistros")

        If result Is Nothing Then
            lstr_res = "ERROR"
            Return lstr_res
        End If

        Return lstr_res
    End Function

    Public Async Function GetExistenRegistros(
    ByVal URL As String
    ) As Task(Of ExisteRegistros)

        Try
            Dim oRequest As WebRequest = WebRequest.Create(URL)
            Dim oResponse As WebResponse = oRequest.GetResponse()
            Dim sr As StreamReader = New StreamReader(oResponse.GetResponseStream())
            Dim json As String = Await sr.ReadToEndAsync()
            Dim result As ExisteRegistros = JsonConvert.DeserializeObject(Of ExisteRegistros)(json)

            Return result
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Async Function GetAsientos(
  ByVal URL As String
  ) As Task(Of AsientosCV)

        Try
            Dim oRequest As WebRequest = WebRequest.Create(URL)
            Dim oResponse As WebResponse = oRequest.GetResponse()
            Dim sr As StreamReader = New StreamReader(oResponse.GetResponseStream())
            Dim json As String = Await sr.ReadToEndAsync()
            Dim result As AsientosCV = JsonConvert.DeserializeObject(Of AsientosCV)(json)

            Return result
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Async Function GetDocumentosCV(
  ByVal URL As String
  ) As Task(Of DocumentosCV)

        Try
            Dim oRequest As WebRequest = WebRequest.Create(URL)
            Dim oResponse As WebResponse = oRequest.GetResponse()
            Dim sr As StreamReader = New StreamReader(oResponse.GetResponseStream())
            Dim json As String = Await sr.ReadToEndAsync()
            Dim result As DocumentosCV = JsonConvert.DeserializeObject(Of DocumentosCV)(json)

            Return result
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Async Function GetOrdenesDePago(
  ByVal URL As String
  ) As Task(Of OrdenesDePago)

        Try
            Dim oRequest As WebRequest = WebRequest.Create(URL)
            Dim oResponse As WebResponse = oRequest.GetResponse()
            Dim sr As StreamReader = New StreamReader(oResponse.GetResponseStream())
            Dim json As String = Await sr.ReadToEndAsync()
            Dim result As OrdenesDePago = JsonConvert.DeserializeObject(Of OrdenesDePago)(json)

            Return result
        Catch ex As Exception
            Return Nothing
        End Try
    End Function

    Public Async Function GetRetenciones(
  ByVal URL As String
  ) As Task(Of Retenciones)

        Try
            Dim oRequest As WebRequest = WebRequest.Create(URL)
            Dim oResponse As WebResponse = oRequest.GetResponse()
            Dim sr As StreamReader = New StreamReader(oResponse.GetResponseStream())
            Dim json As String = Await sr.ReadToEndAsync()
            Dim result As Retenciones = JsonConvert.DeserializeObject(Of Retenciones)(json)

            Return result
        Catch ex As Exception
            Return Nothing
        End Try
    End Function



















    'Public Function CV_ExisteRegistros(
    '    ByRef plst As List(Of String),
    '    ByVal pint_no_lote As Integer
    '    ) As String

    '    Dim lstr_url As String = URL_CV_RegistrosLote
    '    Dim lstr_res As String = "OK"


    '    lstr_url = lstr_url.Replace("[lote]", pint_no_lote)

    '    '---Falta hacer peticion----

    '    Return lstr_res

    'End Function


End Module
