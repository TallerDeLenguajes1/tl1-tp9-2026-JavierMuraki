namespace LectorTagMP3;

public class Id3v1Tag {
    private string? header;
    private string? titulo;
    private string? artista;
    private string? album;
    private string? anio;
    private string? comentario;
    private string? genero;

    public string? Header       { get => header; }
    public string? Titulo       { get => titulo; }
    public string? Artista      { get => artista; }
    public string? Album        { get => album; }
    public string? Anio         { get => anio; }
    public string? Comentario   { get => comentario; }
    public string? Genero       { get => genero; }

    public void LeerBuffer(byte[] MP3_Buffer) {

    }
}