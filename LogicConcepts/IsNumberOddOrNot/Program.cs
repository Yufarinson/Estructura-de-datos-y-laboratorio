
using System;

var numberInt = string.Empty;
do
{
    Console.WriteLine("Ingrese un numero o ingresa la letra 's' para salir");
    numberInt = Console.ReadLine();

    if (numberInt!.ToLower() == "s")
    {
        continue;
    }
    var numberIntUno = 0;
    if (int.TryParse(numberInt, out numberIntUno))
    {

            if (numberIntUno % 2 == 0)
            {
                Console.WriteLine($"El número {numberIntUno}, es par.");
            }
            else
            {
                Console.WriteLine($"El número {numberIntUno}, es impar.");
            }
    }
    else
    {
        Console.WriteLine($"lo que ingresaste: {numberInt}, no es un número entero");
    }

} while (numberInt!.ToLower() != "s");
Console.WriteLine("Gracias por usar nuestro programa");
