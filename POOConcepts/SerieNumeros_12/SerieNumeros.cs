using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace SerieNumeros_12;

public class SerieNumeros
{
    public int Numeros { get; set; }

    public SerieNumeros()
    {

    }

    public SerieNumeros(int numeros)
    {
        Numeros = numeros;
    }

    public void MostrarNumeros()
    {
        for (int i = 1; i <= Numeros; i++)
        {
            Console.WriteLine(i);
        }
    }


    public int SumatoriaDeNumeros()
    {
        int suma = 0;
        for (int i = 1; i <= Numeros; i++)
        {
            suma += i;
        }


        return suma;
    }

    public double PromedioDeNumeros()
    {
        double promedio;

        promedio = SumatoriaDeNumeros() / Numeros;
        return promedio;
    }

}
