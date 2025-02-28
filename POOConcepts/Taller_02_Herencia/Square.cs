using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_02_Herencia;

public class Square : GeometricFigure
{
    private double _a;
    public Square(string name, double a) : base(name)
    {
        A = a;
    }

    public double A { get => _a; set => _a = ValidateA(value); }

    public override double GetArea()
    {
        return Math.Pow(A, 2);
    }

    public override double GetPerimeter()
    {
        return 4 * A;
    }

    public double ValidateA(double a)
    {
        if (a <= 0)
        {
            throw new Exception($"The side {a} must be greater than zero.");
        }
        return a;
    }
}
