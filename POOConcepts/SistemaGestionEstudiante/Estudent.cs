using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEstudiante;

class Estudent
{
    private string _nombre;
    private int _edad;
    private List<double> listCalificaciones;

    public Estudent(string nombre, int edad)
    {
        Nombre = nombre;
        Edad = edad;
        listCalificaciones = new List<double>();
    }

    public string Nombre { get => _nombre; set => _nombre = value; }
    public int Edad { get => _edad; set => _edad = ValidateEdad(value); }

    public void AgregarCalificacion()
    {
        Console.Write("Ingrese la cantidad de calificaciones: ");
        if (!int.TryParse(Console.ReadLine(), out int cantidadCalificaciones) || cantidadCalificaciones <= 0)
        {
            throw new Exception("Cantidad de calificaciones no válida.");
        }

        for (int i = 0; i < cantidadCalificaciones; i++)
        {
            Console.Write($"Ingrese la nota {i + 1}: ");
            if (!double.TryParse(Console.ReadLine(), out double calificacion) || !ValidateCalificaciones(calificacion))
            {
                throw new Exception("La calificación no es válida.");
            }
            listCalificaciones.Add(calificacion);
        }
    }

    public double CalcularPromedioNotas()
    {
        if (listCalificaciones.Count == 0)
            return 0; // Evita división por cero

        double suma = 0;
        foreach (var nota in listCalificaciones)
        {
            suma += nota;
        }
        return suma / listCalificaciones.Count;
    }

    public void MostrarInformacion()
    {
        Console.WriteLine($"Nombre: {Nombre}");
        Console.WriteLine($"Edad: {Edad}");
        Console.WriteLine($"Lista de Calificaciones: {string.Join(", ", listCalificaciones)}");
        Console.WriteLine($"Promedio de calificaciones: {CalcularPromedioNotas()}");
    }

    private int ValidateEdad(int valor)
    {
        if (valor < 0)
            throw new Exception($"La edad {valor} no es válida.");
        return valor;
    }

    private bool ValidateCalificaciones(double valor)
    {
        return valor >= 0 && valor <= 5;
    }
}
