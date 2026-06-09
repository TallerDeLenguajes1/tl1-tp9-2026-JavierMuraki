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
MP3_FILE.Read(Formato, 0, 3);
if (Encoding.ASCII.GetString(Formato) != "ID3") {
    Console.WriteLine("Formato invalido, no es un MP3!");
    MP3_FILE.Close();
    return;
}

// Leer los ultimos 128 Bytes
byte[] MP3_Buffer = new byte[128];
MP3_FILE.Seek(-128, SeekOrigin.End);
MP3_FILE.Read(MP3_Buffer, 0, 128);

// Cerrar el archivo
MP3_FILE.Close();