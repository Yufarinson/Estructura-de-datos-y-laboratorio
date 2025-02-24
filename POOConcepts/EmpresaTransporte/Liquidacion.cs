using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpresaTransporte_11;

public class Liquidacion
{

    public int Ruta { get; set; }
    public int NumeroViajes { get; set; }
    public int NumeroPasajeros { get; set; }
    public int NumeroEncomiendas10k { get; set; }
    public int NumeroEncomienda10_20k { get; set; }
    public int NumeroEncomiendas20k { get; set; }
    double seguroAyudante = 0;


    public Liquidacion()
    {
        
    }

    public Liquidacion(int _ruta, int _numeroViajes, int _numeroPasajeros, int _encomiendas10k,
        int _encomiendas10_20k, int _encomiendas20k)
    {
        Ruta = _ruta;
        NumeroViajes = _numeroViajes;
        NumeroPasajeros = _numeroPasajeros;
        NumeroEncomiendas10k = _encomiendas10k;
        NumeroEncomienda10_20k = _encomiendas10_20k;
        NumeroEncomiendas20k = _encomiendas20k;
    }

    public double CalcularComisiones()
    {
        double comision = 0;
        int pasajerosExtras = 0;

        if (Ruta == 1)
        {
            if (NumeroPasajeros < 50)
            {
                comision = 500000;
            }
            else if (NumeroPasajeros > 50 && NumeroPasajeros <= 100)
            {
                comision = 500000 + (500000 * 0.05);
            }
            else if (NumeroPasajeros > 100 && NumeroPasajeros <= 150)
            {
                comision = 500000 + (500000 * 0.06);
            }
            else if (NumeroPasajeros > 150 && NumeroPasajeros <= 200)
            {
                comision = 500000 + (500000 * 0.07);
            }
            else if (NumeroPasajeros > 200)
            {
                pasajerosExtras = NumeroPasajeros - 200;
                comision = (500000 * 0.07 + pasajerosExtras * 50) + 500000;
            }
            return comision;
        }
        else if (Ruta == 2)
        {
            if (NumeroPasajeros < 50)
            {
                comision = 600000;
            }
            else if (NumeroPasajeros > 50 && NumeroPasajeros <= 100)
            {
                comision = 600000 +(600000 * 0.07);
            }
            else if (NumeroPasajeros > 100 && NumeroPasajeros <= 150)
            {
                comision = 600000 + (600000 * 0.08);
            }
            else if (NumeroPasajeros > 150 && NumeroPasajeros <= 200)
            {
                comision = 600000 + (600000 * 0.09);
            }
            else if (NumeroPasajeros > 200)
            {
                pasajerosExtras = NumeroPasajeros - 200;
                comision = (600000 * 0.09 + pasajerosExtras * 60) + 600000;
            }
            return comision;
        }
        else if (Ruta == 3)
        {
            if (NumeroPasajeros < 50)
            {
                comision = 800000;
            }
            else if (NumeroPasajeros > 50 && NumeroPasajeros <= 100)
            {
                comision = 800000 + (800000 * 0.10);
            }
            else if (NumeroPasajeros > 100 && NumeroPasajeros <= 150)
            {
                comision = 800000 + (800000 * 0.13);
            }
            else if (NumeroPasajeros > 150 && NumeroPasajeros <= 200)
            {
                comision = 800000 + (800000 * 0.15);
            }
            else if (NumeroPasajeros > 200)
            {
                pasajerosExtras = NumeroPasajeros - 200;
                comision = (800000 * 0.15 + pasajerosExtras * 100) + 800000;
            }
            return comision;
        }
        else if (Ruta == 4)
        {
            if (NumeroPasajeros < 50)
            {
                comision = 1000000;
            }
            else if (NumeroPasajeros > 50 && NumeroPasajeros <= 100)
            {
                comision = 1000000 +(1000000 * 0.125);
            }
            else if (NumeroPasajeros > 100 && NumeroPasajeros <= 150)
            {
                comision = 1000000 +(1000000 * 0.15);
            }
            else if (NumeroPasajeros > 150 && NumeroPasajeros <= 200)
            {
                comision = 1000000 + (1000000 * 0.17);
            }
            else if (NumeroPasajeros > 200)
            {
                pasajerosExtras = NumeroPasajeros - 200;
                comision = (1000000 * 0.17 + pasajerosExtras * 120) + 1000000;
            }
            return comision;
        }

        return comision;
    }

    public double CalcularValorPaquete()
    {
        double ingreso = 0;

        if (Ruta == 1 || Ruta == 2)
        {
            // Para paquetes de menos de 10Kg
            if (NumeroEncomiendas10k < 50)
                ingreso += NumeroEncomiendas10k * 100;
            else if (NumeroEncomiendas10k >= 50 && NumeroEncomiendas10k <= 100)
                ingreso += NumeroEncomiendas10k * 120;
            else if (NumeroEncomiendas10k > 100 && NumeroEncomiendas10k <= 130)
                ingreso += NumeroEncomiendas10k * 150;
            else if (NumeroEncomiendas10k > 130)
                ingreso += NumeroEncomiendas10k * 160;

            // Para paquetes entre 10Kg y menos de 20Kg
            if (NumeroEncomienda10_20k < 50)
                ingreso += NumeroEncomienda10_20k * 120;
            else if (NumeroEncomienda10_20k >= 50 && NumeroEncomienda10_20k <= 100)
                ingreso += NumeroEncomienda10_20k * 140;
            else if (NumeroEncomienda10_20k > 100 && NumeroEncomienda10_20k <= 130)
                ingreso += NumeroEncomienda10_20k * 160;
            else if (NumeroEncomienda10_20k > 130)
                ingreso += NumeroEncomienda10_20k * 180;

            // Para paquetes de más de 20Kg (en rutas 1 y 2, según la tabla, no se indica la categoría "más de 20Kg")
            // La tabla para rutas 1 y 2 solo distingue dos categorías: menos de 10Kg y mayor o igual a 10Kg.
        }
        else if (Ruta == 3 || Ruta == 4)
        {
            // Para paquetes de menos de 10Kg
            if (NumeroEncomiendas10k < 50)
                ingreso += NumeroEncomiendas10k * 130;
            else if (NumeroEncomiendas10k >= 50 && NumeroEncomiendas10k <= 100)
                ingreso += NumeroEncomiendas10k * 160;
            else if (NumeroEncomiendas10k > 100 && NumeroEncomiendas10k <= 130)
                ingreso += NumeroEncomiendas10k * 175;
            else if (NumeroEncomiendas10k > 130)
                ingreso += NumeroEncomiendas10k * 200;

            // Para paquetes entre 10Kg y menos de 20Kg
            if (NumeroEncomienda10_20k < 50)
                ingreso += NumeroEncomienda10_20k * 140;
            else if (NumeroEncomienda10_20k >= 50 && NumeroEncomienda10_20k <= 100)
                ingreso += NumeroEncomienda10_20k * 180;
            else if (NumeroEncomienda10_20k > 100 && NumeroEncomienda10_20k <= 130)
                ingreso += NumeroEncomienda10_20k * 200;
            else if (NumeroEncomienda10_20k > 130)
                ingreso += NumeroEncomienda10_20k * 250;

            // Para paquetes de 20Kg o más
            if (NumeroEncomiendas20k < 50)
                ingreso += NumeroEncomiendas20k * 130;  // Si la tabla tuviera un valor para "menos de 10Kg" en esta categoría, pero en rutas 3 y 4 se indica que se usa cuando el peso es mayor o igual a 20Kg.
            else if (NumeroEncomiendas20k >= 50 && NumeroEncomiendas20k <= 100)
                ingreso += NumeroEncomiendas20k * 210;
            else if (NumeroEncomiendas20k > 100 && NumeroEncomiendas20k <= 130)
                ingreso += NumeroEncomiendas20k * 250;
            else if (NumeroEncomiendas20k > 130)
                ingreso += NumeroEncomiendas20k * 300;
        }

        return ingreso;
    }

    public double CalcularPagoAyudante()
    {
        double ingresoConductor = CalcularComisiones() + CalcularValorPaquete();
        double pagoAyudante = 0;

        if (ingresoConductor < 1000000)
        {
            pagoAyudante = ingresoConductor * 0.05;
            seguroAyudante = ingresoConductor * 0.03;
            return pagoAyudante + seguroAyudante;
        }
        else if (ingresoConductor >= 1000000 && ingresoConductor <= 2000000)
        {
            pagoAyudante = ingresoConductor * 0.08;
            seguroAyudante = ingresoConductor * 0.04;
            return pagoAyudante + seguroAyudante;
        }
        else if (ingresoConductor >= 2000000 && ingresoConductor <= 4000000)
        {
            pagoAyudante = ingresoConductor * 0.10;
            seguroAyudante = ingresoConductor * 0.06;
            return pagoAyudante + seguroAyudante;
        }

        pagoAyudante = ingresoConductor * 0.13;
        seguroAyudante = ingresoConductor * 0.09;
        return pagoAyudante + seguroAyudante;
    }

    public double CalcularPagoSeguroAyudante()
    {
        return seguroAyudante;
    }

    public double CalcularConsumoCombustible()
    {
        double consumo = 0;
        double pesoTotal = (NumeroPasajeros * 60);

        if (Ruta == 1)
        {
            consumo = ((8860 * 150) / 39) * 0.75;
        }
        else if (Ruta == 2)
        {
            consumo = ((8860 * 167) / 39) * 0.75;
        }
        else if (Ruta == 3)
        {
            consumo = ((8860 * 184) / 39) * 0.75;
        }
        else if (Ruta == 4) 
        {
            consumo = ((8860 * 203) / 39) * 0.75;
        }



        if (pesoTotal <= 5000)
        {
            return consumo;
        }
        else if (pesoTotal > 5000 && pesoTotal <= 10000)
        {
            return consumo *1.10;
        }
        else if (pesoTotal > 10000)
        {
            return consumo * 1.25;
        }

        return consumo;
    }

    public int ValidarEntradaEntero()
    {
        int numero;
        while (!int.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("El valor ingresado no es un número entero, por favor ingrese un número entero: ");
        }
        return numero;
    }

    public double ValidarEntradaDecimal()
    {
        double numero;
        while (!double.TryParse(Console.ReadLine(), out numero))
        {
            Console.WriteLine("El valor ingresado no es un número decimal, por favor ingrese un número decimal: ");
        }
        return numero;
    }
}
