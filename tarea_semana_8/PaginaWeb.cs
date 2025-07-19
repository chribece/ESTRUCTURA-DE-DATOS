public class PaginaWeb
{
    public string Url { get; set; }
    public string Titulo { get; set; }

    public PaginaWeb(string url, string titulo)
    {
        Url = url;
        Titulo = titulo;
    }

    public override string ToString()
    {
        return $"{Titulo} ({Url})";
    }
}