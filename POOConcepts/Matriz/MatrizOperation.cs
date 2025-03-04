using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matriz;

class MatrizOperation
{
    private int _orden;
    private int _sumatoria;
    private int _valorMaximo;
    private int _valorMinimo;
    private int[,] _matriz;

    public MatrizOperation()
    {
        _sumatoria = 0;
        _valorMaximo = int.MinValue;
        _valorMinimo = int.MaxValue;
    }

    public MatrizOperation(int orden)
    {
        Orden = orden;
        _matriz = new int[Orden, Orden];
    }

    public int Orden { get => _orden; set => _orden = ValidateOrden(value); }

    public void LlenarMatriz()
    {
        for (int i = 0; i < Orden; i++)
        {
            for (int j = 0; j < Orden; j++)
            {
                _matriz[i, j] = (i + 1) - j;
                _sumatoria += _matriz[i, j];

                if (_matriz[i, j] > _valorMaximo)
                    _valorMaximo = _matriz[i, j];

                if (_matriz[i, j] < _valorMinimo)
                    _valorMinimo = _matriz[i, j];

                Console.Write($"{_matriz[i, j],3} ");
            }
            Console.WriteLine();
        }
    }

    public void MostrarResultados()
    {
        Console.WriteLine($"La sumatoria es: {_sumatoria}");
        Console.WriteLine($"El valor máximo es: {_valorMaximo}");
        Console.WriteLine($"El valor mínimo es: {_valorMinimo}");
    }


    public int ValidateOrden(int value)
    {
        if (value <= 0)
        {
            throw new Exception($"The value {value} is not valid");
        }
        return value;
    }
}
