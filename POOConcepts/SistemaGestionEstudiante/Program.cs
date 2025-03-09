
using SistemaGestionEstudiante;

try
{
    Console.Write($"Ingrese el nombre del estudiante: ");
    var nombre = Console.ReadLine();

    Console.Write("Ingrese la edad del estudiante: ");
    if (!int.TryParse(Console.ReadLine(), out int edad))
    {
        throw new Exception("Edad no válida.");
    }

    var estudiante = new Estudent(nombre, edad);
    estudiante.AgregarCalificacion();
    estudiante.MostrarInformacion();
}
catch (Exception ex)
{
    Console.WriteLine($"Error: {ex.Message}");
}
