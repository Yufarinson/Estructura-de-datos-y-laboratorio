using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_02_Herencia;

public class Triangle : Rectangle
{

    private double _c;
    private double _h;
    public Triangle(string name, double a, double b , double c, double h) : base(name, a, b)
    {
        C = c;
        H = h;
    }

    public double C { get => _c; set => _c = ValidateC(value); }
    public double H { get => _h; set => _h = ValidateH(value); }

    public override double GetArea()
    {
        return (B * H) / 2;
    }

    public override double GetPerimeter()
    {
        return A + B + C;
    }

    public double ValidateC(double c)
    {
        if (c <= 0)
        {
            throw new Exception($"The side {c} must be greater than zero.");
        }
        return c;
    }

    public double ValidateH(double h)
    {
        if (h <= 0)
        {
            throw new Exception($"The height {h} must be greater than zero.");
        }
        return h;
    }
}
