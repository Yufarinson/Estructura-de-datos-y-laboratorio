using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_02_Herencia;

public class Parallelogram : Rectangle
{

    private double _h;
    public Parallelogram(string name, double a, double b, double h) : base(name, a, b)
    {
        H = h;
    }

    public double H { get => _h; set => _h = ValidateH(value); }

    public override double GetArea()
    {
        return A * H;
    }

    public override double GetPerimeter()
    {
        return 2 * (A + B);
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
