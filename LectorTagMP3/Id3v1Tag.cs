using System.Text;
namespace LectorTagMP3;

public class Id3v1Tag {
    private string? header;
    private string? titulo;
    private string? artista;
    private string? album;
    private string? anio;
    private string? comentario;
    private int? genero;

    public string? Header       { get => header; }
    public string? Titulo       { get => titulo; }
    public string? Artista      { get => artista; }
    public string? Album        { get => album; }
    public string? Anio         { get => anio; }
    public string? Comentario   { get => comentario; }
    public int? Genero          { get => genero; }

    // Returna false si no pudo leerlo, true si pudo
    public bool LeerTags(FileStream MP3_FILE) {
        byte[] MP3_Buffer = new byte[128];

        MP3_FILE.Seek(-128, SeekOrigin.End);
        MP3_FILE.Read(MP3_Buffer, 0, 128);
        MP3_FILE.Seek(0, SeekOrigin.Begin);

        string tag = Encoding.UTF8.GetString(MP3_Buffer, 0, 3);
        if (tag != "TAG") return false;

        header =        "TAG";
        titulo =        Encoding.UTF8.GetString(MP3_Buffer, 3  , 30);
        artista =       Encoding.UTF8.GetString(MP3_Buffer, 33 , 30);
        album =         Encoding.UTF8.GetString(MP3_Buffer, 63 , 30);
        anio =          Encoding.UTF8.GetString(MP3_Buffer, 93 , 4 );
        comentario =    Encoding.UTF8.GetString(MP3_Buffer, 97 , 30);
        genero =        MP3_Buffer[127];

        return true;
    }
}