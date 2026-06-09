using LectorTagMP3;
string? MP3_PATH; // C:\Users\Alumno\Downloads


do { // Ingreso del MP3_PATH
    Console.Write("Ingrese el PATH de un archivo MP3 que desea analizar: ");
    MP3_PATH = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(MP3_PATH))    Console.WriteLine("No ingresaste nada, intenta de nuevo.\n");
    else if (!File.Exists(MP3_PATH))       Console.WriteLine("No existe el archivo, intente de nuevo.\n");
    else break; // Todo perfecto, se detiene el bucle
} while (true);
