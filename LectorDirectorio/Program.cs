string? PATH; // C:\Users\Alumno\Downloads

do { // Ingreso del PATH
    Console.Write("Ingrese el PATH de un directorio que desea analizar: ");
    PATH = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(PATH))    Console.WriteLine("No ingresaste nada, intenta de nuevo.\n");
    else if (!Directory.Exists(PATH))       Console.WriteLine("No existe el directiorio, intente de nuevo.\n");
    else break; // Todo perfecto, se detiene el bucle
} while (true);

// Preparacion del arcivo reporte_archivos.csv
string Path_reporte_archivos = Path.Join(PATH, "reporte_archivos.csv");
FileStream File_reporte_archivos;
if (!File.Exists(Path_reporte_archivos))    File_reporte_archivos = File.Create(Path_reporte_archivos);
else                                        File_reporte_archivos = new FileStream(Path_reporte_archivos, FileMode.Open);
StreamWriter Writer_reporte_archivos = new StreamWriter(File_reporte_archivos);

// Consigue todos los Directorios y Archivos
DirectoryInfo InformacionDirectorio = new DirectoryInfo(PATH);
DirectoryInfo[] Directorios = InformacionDirectorio.GetDirectories();
FileInfo[] Archivos = InformacionDirectorio.GetFiles();

// Escribe en la consola los Direcorios y Archivos, tambien registra los Archivos en reporte_archivos.csv
foreach (DirectoryInfo DIR in Directorios) Console.WriteLine($"[CARPETA]: {DIR.Name}");
foreach (FileInfo FILE in Archivos) {
    Console.WriteLine($"[ARCHIVO]: {FILE.Name,-54} | Tamanio: {FILE.Length/1024} KB");
    Writer_reporte_archivos.WriteLine($"{FILE.Name};{FILE.Length/1024} KB;{FILE.LastWriteTime}"); // Escritura dentro del reporte_archivos.csv
}

// Cierre del reporte_archivos.csv
Writer_reporte_archivos.Close();
File_reporte_archivos.Close();