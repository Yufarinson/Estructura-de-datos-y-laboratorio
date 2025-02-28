using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_02_Herencia;

public class Circle : GeometricFigure
{
    private double _r;
    public Circle(string name, double r) : base(name)
    {
        R = r;
    }

    public double R {get => _r; set => _r = ValidateR(value);}

    public override double GetArea()
    {
        return Math.PI * Math.Pow(R, 2);
    }

    public override double GetPerimeter()
    {
        return 2 * Math.PI * R;
    }

    public double ValidateR(double r)
    {
        if (r <= 0)
        {
            throw new Exception($"The radius {r} must be greater than zero.");
        }
        return r;
    }
}
