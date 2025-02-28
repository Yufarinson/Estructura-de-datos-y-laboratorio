using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taller_02_Herencia;

public abstract class GeometricFigure
{
    public string Name { get; set; } = null!;

    public GeometricFigure(string name)
    {
        Name = name;
    }

    public abstract double GetArea();

    public abstract double GetPerimeter();

    public override string ToString()
    {
        return $"{Name, -15} => Area.....: {GetArea(),15:F5}    Perimeter: {GetPerimeter(),15:F5}";
    }
}
