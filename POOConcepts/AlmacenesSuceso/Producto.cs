using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AlmacenesSuceso_10;

public class Producto
{

    private double _costoCompra_CC;
    private int _tipoProducto_TP;
    private int _tipoConservacion_TC;
    private double _periodoConservacion_PC;
    private double _periodoAlmacenamiento_PA;
    private double _volumenEnLitros_VOL;
    private int _medioAlmacenamiento_MA;

    double vr_v;
    double vr_p;

    public Producto()
    {

    }

    public Producto(double cc, int tp, int tc, double pc, double pa, double vol, int ma)
    {
        _costoCompra_CC = cc;
        _tipoProducto_TP = tp;
        _tipoConservacion_TC = tc;
        _periodoConservacion_PC = pc;
        _periodoAlmacenamiento_PA = pa;
        _volumenEnLitros_VOL = vol;
        _medioAlmacenamiento_MA = ma;
    }

    public double CC { get => _costoCompra_CC; set => _costoCompra_CC = ValidarEntradaDouble(); }
    public int TP { get => _tipoProducto_TP; set => _tipoProducto_TP = ValidarEntradaEntero(); }
    public int TC { get => _tipoConservacion_TC; set => _tipoConservacion_TC = ValidarEntradaEntero(); }
    public double PC { get => _periodoConservacion_PC; set => _periodoConservacion_PC = ValidarEntradaEntero(); }
    public double PA { get => _periodoAlmacenamiento_PA; set => _periodoAlmacenamiento_PA = ValidarEntradaEntero(); }
    public double VOL { get => _volumenEnLitros_VOL; set => _volumenEnLitros_VOL = ValidarEntradaDouble(); }
    public int MA { get => _medioAlmacenamiento_MA; set => _medioAlmacenamiento_MA = ValidarEntradaEntero(); }


    public double CostoAlmacenamiento()
    {
        if (TP == 1)
        {
            if (TC == 1 && PC < 10)
            {
                return CC * 0.05;
            }
            else if (TC == 1 && PC >= 10)
            {
                return CC * 0.10;
            }
            else if (TC == 2 && PA < 20)
            {
                return CC * 0.03;
            }
            else if (TC == 2 && PA > 20)
            {
                return CC * 0.10;
            }
            else if (TC == 2 && PA == 20)
            {
                return CC * 0.05;
            }
            return 0;
        }
        else if (TP == 2)
        {
            if (VOL >= 50)
            {
                return CC * 0.10;
            }
            else if (VOL < 50)
            {
                return CC * 0.20;
            }
            return 0;
        }


        return 0;
    }

    public double DepreciacionProducto()
    {

        if (PA < 30)
        {
            return 0.95;
        }
        else if (PA >= 30)
        {
            return 0.85;
        }
        return 0;
    }


    public double CostoDeExhibicion()
    {
        double CA = CostoAlmacenamiento();
        if (TP == 1)
        {
            if (TC == 1 && MA == 1)
            {
                return CA * 2;
            }
            else if (TC == 1 && MA == 2)
            {
                return CA;
            }
            return 0;
        }
        else if (TP == 2)
        {
            if (MA == 3)
            {
                return CA * 0.05;
            }
            else if (MA == 4)
            {
                return CA * 0.07;
            }
            return 0;
        }
        return 0;
    }


    public int ValidarEntradaEntero()
    {
        int entrada;
        while (!int.TryParse(Console.ReadLine(), out entrada) || entrada < 1 || entrada > 4)
        {
            Console.Write($"{entrada}, no es un valor correcto. Inténtalo de nuevo ingresando un valor correcto: ");
        }
        return entrada;
    }

    public double ValidarEntradaDouble()
    {
        double entrada;
        while (!double.TryParse(Console.ReadLine(), out entrada) || entrada < 0)
        {
            Console.Write($"{entrada}, no es un valor correcto. Inténtalo de nuevo ingresando un valor correcto: ");
        }
        return entrada;
    }

}
