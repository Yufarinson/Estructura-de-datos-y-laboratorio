using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Descomposicion;

class Descomponer
{
    private int _numero;

    public Descomponer(int numero)
    {
        Numero = numero;
    }

    public int Numero { get => _numero; set => _numero = ValidateNumero(value); }

    public void DescomponerNumero()
    {
        int n = _numero;
        Console.Write($"{n} = ");

        bool esPrimero = true;
        for (int i = 2; i <= n; i++)
        {
            while (n % i == 0)
            {
                if (!esPrimero)
                    Console.Write(" x ");

                Console.Write(i);
                n /= i;
                esPrimero = false;
            }
        }
        Console.WriteLine();
    }

    private int ValidateNumero(int numero)
    {
        if (numero <= 0)
        {
            throw new Exception($"The value {numero} is not valid");
        }
        return numero;
    }
}
