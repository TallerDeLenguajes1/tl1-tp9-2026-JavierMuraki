using System.Text;
using LectorTagMP3;
string? MP3_PATH; // C:\Users\Alumno\Downloads


do { // Ingreso del MP3_PATH
    Console.Write("Ingrese el PATH de un archivo MP3 que desea analizar: ");
    MP3_PATH = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(MP3_PATH))    Console.WriteLine("No ingresaste nada, intenta de nuevo.\n");
    else if (!File.Exists(MP3_PATH))       Console.WriteLine("No existe el archivo, intente de nuevo.\n");
    else break; // Todo perfecto, se detiene el bucle
} while (true);

// Abrir el archivo MP3
FileStream MP3_FILE = new FileStream(MP3_PATH, FileMode.Open);

// Verificar formato MP3
byte[] Formato = new byte[3];
if (Encoding.UTF8.GetString(Formato, 0, MP3_FILE.Read(Formato, 0, 3)) != "ID3") {
    Console.WriteLine("Formato invalido, no es un MP3!");
    MP3_FILE.Close();
    return;
}

Id3v1Tag LectorTag = new Id3v1Tag();

// Leer los tags del MP3
if (!LectorTag.LeerTags(MP3_FILE)) {
    Console.WriteLine("No se pudo leer los tags del MP3");
    MP3_FILE.Close();
    return;
}

// Datos
Console.WriteLine($"Header:     {LectorTag.Header}");
Console.WriteLine($"Titulo:     {LectorTag.Titulo}");
Console.WriteLine($"Artista:    {LectorTag.Artista}");
Console.WriteLine($"Album:      {LectorTag.Album}");
Console.WriteLine($"Anio:       {LectorTag.Anio}");
Console.WriteLine($"Comentario: {LectorTag.Comentario}");
Console.WriteLine($"Genero:     {LectorTag.Genero}");

// Cerrar el archivo
MP3_FILE.Close();