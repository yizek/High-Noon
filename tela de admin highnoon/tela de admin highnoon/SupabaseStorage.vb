' ============================================================
' Envia imagens de produtos para o Supabase e devolve o link
' público que fica salvo na coluna image_url.
'
' Funciona chamando uma Edge Function ("upload-product-image")
' que já roda no Supabase com a permissão necessária — por isso
' esse arquivo NÃO precisa de nenhuma chave secreta.
'
' PRÉ-REQUISITO: referência a System.Net.Http no projeto
'   (botão direito no projeto > Add Reference > Assemblies >
'    Framework > marcar "System.Net.Http")
' ============================================================

Imports System.Net.Http
Imports System.Net.Http.Headers

Public Class SupabaseStorage

    Private Const FUNCTION_URL As String = "https://pbqooeovnkbrtvevkbse.supabase.co/functions/v1/upload-product-image"

    ' Envia o arquivo de imagem escolhido e devolve a URL pública
    ' pra salvar no banco (coluna image_url).
    Public Function UploadImagem(caminhoArquivoLocal As String) As String

        Dim bytesImagem As Byte() = System.IO.File.ReadAllBytes(caminhoArquivoLocal)
        Dim nomeArquivo As String = System.IO.Path.GetFileName(caminhoArquivoLocal)

        Using client As New HttpClient()
            client.DefaultRequestHeaders.Add("x-filename", nomeArquivo)

            Dim conteudo As New ByteArrayContent(bytesImagem)
            conteudo.Headers.ContentType = New MediaTypeHeaderValue(TipoMime(caminhoArquivoLocal))

            Dim resposta = client.PostAsync(FUNCTION_URL, conteudo).GetAwaiter().GetResult()
            Dim corpoResposta = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult()

            If Not resposta.IsSuccessStatusCode Then
                Throw New Exception("Falha ao enviar imagem: " & corpoResposta)
            End If

            ' Resposta é algo como {"url":"https://...supabase.co/storage/v1/object/public/product-images/xxxx.jpg"}
            Dim marcador As String = """url"":"""
            Dim inicio As Integer = corpoResposta.IndexOf(marcador) + marcador.Length
            Dim fim As Integer = corpoResposta.IndexOf("""", inicio)

            If inicio < marcador.Length OrElse fim < 0 Then
                Throw New Exception("Resposta inesperada do servidor: " & corpoResposta)
            End If

            Return corpoResposta.Substring(inicio, fim - inicio)
        End Using

    End Function

    Private Function TipoMime(caminho As String) As String
        Select Case System.IO.Path.GetExtension(caminho).ToLower()
            Case ".png" : Return "image/png"
            Case ".jpg", ".jpeg" : Return "image/jpeg"
            Case ".gif" : Return "image/gif"
            Case ".webp" : Return "image/webp"
            Case Else : Return "application/octet-stream"
        End Select
    End Function

End Class
