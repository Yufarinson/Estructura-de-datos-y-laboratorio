using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio_09;

public class EnvioMercancia
{
    private double peso_mercancia;
    private double precio_mercancia;
    private string es_lunes;

    public EnvioMercancia()
    {
        peso_mercancia = 289;
        precio_mercancia = 780000;
        es_lunes = "s";
    }

    public EnvioMercancia(double peso, double precio, string dia)
    {
        peso_mercancia = peso;
        precio_mercancia = precio;
        es_lunes = dia;
    }

    public double Peso
    {
        get => peso_mercancia;
        set => peso_mercancia = value;
    }

    public double Precio
    {
        get => precio_mercancia;
        set => precio_mercancia = value;
    }

    public string Dia
    {
        get => es_lunes;
        set => es_lunes = value;
    }

    public double ValidarEntradaDouble()
    {
        double valor;
        while (!double.TryParse(Console.ReadLine(), out valor) || valor < 0)
        {
            Console.Write($"Lo que ingresaste no es un valor valido, inténtelo de nuevo ingresando el peso: ");
        }
        return valor;
    }

    public double CalcularTarifas(double peso)
    {
        double tarifa = 0;
        double extra = 0;

        if (peso < 100)
        {
            tarifa = 20000;
        }
        else if (peso >= 100 && peso <= 150)
        {
            tarifa = 25000;
        }
        else if (peso >= 150 && peso <= 200)
        {
            tarifa = 30000;
        }
        else
        {
            extra = ((int)peso - 200) / 10;
            tarifa = 35000 + extra * 2000;
        }

        return tarifa;
    }

    public double CalcularDescuento(double valor)
    {

        if (valor >= 300000 && valor <= 600000)
        {
            return 0.10;
        }
        else if (valor > 600000 && valor <= 1000000)
        {
            return 0.20;
        }
        else 
        {
            return 0.30;
        }
    }

    public double CalcularPromociones(string dia, string ti_pago, double valor)
    {
        if (dia.ToLower() == "s" && ti_pago.ToLower() == "t")
        {
            return 0.50;
        }
        else if (dia.ToLower() == "s" && ti_pago.ToLower() == "e")
        {
            if (valor > 1000000)
            {
                return 0.60;
            }
        }
        return 0;
    }

}
