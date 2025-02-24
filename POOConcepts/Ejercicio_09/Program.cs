
using Ejercicio_09;

var dato1 = new EnvioMercancia();
var bandera = false;
var comparar = "";

do
{

    Console.Write("Ingrese el peso de la mercancia: ");
    var peso = dato1.ValidarEntradaDouble();

    Console.Write("Ingrese el precio de la mercancia: ");
    var precio = dato1.ValidarEntradaDouble();

    var dia = "";
    do
    {
        Console.Write("Es lunes? [S]í [N]n: ");
        dia = Console.ReadLine();

        if (dia.ToLower() != "s" && dia.ToLower() != "n")
        {
            Console.Write($"Ingresa [S]í [N]o. {dia} no es un valor  válido\n");
        }
    } while (dia.ToLower() != "s" && dia.ToLower() != "n");

    var tipoPago = "";
    do
    {
        Console.Write("Tipo de pago [E]fectivo [T]arjeta: ");
        tipoPago = Console.ReadLine();

        if (tipoPago.ToLower() != "t" && tipoPago.ToLower() != "e")
        {
            Console.WriteLine($"Ingresa [T]arjeta [E]fectivo. {tipoPago} no es un valor  válido\n");
        }
    } while (tipoPago.ToLower() != "t" && tipoPago.ToLower() != "e");

    var tarifa = dato1.CalcularTarifas(peso);
    var descuentos = dato1.CalcularDescuento(precio);
    var promocion = tarifa * dato1.CalcularPromociones(dia, tipoPago, precio);
    var calculoDescuento = tarifa * descuentos;
    var valorPagar = tarifa - promocion - calculoDescuento;

    if (promocion > 0)
    {
        valorPagar = promocion; // Aplicamos la promoción
        calculoDescuento = 0; // No aplicamos el descuento
    }
    else
    {
        valorPagar = calculoDescuento; // Aplicamos el descuento si no hay promoción
        promocion = 0; // No aplicamos la promoción
    }

    valorPagar = tarifa - promocion - calculoDescuento;

    Console.WriteLine("\n\n...............COSTO ENVÍO..............\n\n ");
    Console.WriteLine($"Peso de la mercancía..................: {peso}");
    Console.WriteLine($"valor de la mercancía.................: {precio}");
    Console.WriteLine($"Es lunes [S]í [N]o:.................... {dia}");
    Console.WriteLine($"Tipo de pago [E] fectivo [T]arjeta:.... {tipoPago}");
    Console.WriteLine($"Tarifa:................................ {tarifa}");
    Console.WriteLine($"Promoción:............................. {promocion}");
    Console.WriteLine($"Descuento:............................. {calculoDescuento}");
    Console.WriteLine($"Total a pagar:......................... {valorPagar}\n");

    do
    {
        Console.Write("Desea realizar otro envío? [S]í [N]o: ");
        comparar = Console.ReadLine();
        if (comparar.ToLower() == "s")
        {
            bandera = true;
        }
        else if (comparar.ToLower() == "n")
        {
            bandera = false;
        }

        if (comparar.ToLower() != "s" && comparar.ToLower() != "n")
        {
            Console.WriteLine($"Ingresa [S]í [N]n. {comparar} no es un valor  válido\n");
        }
    } while (comparar.ToLower() != "s" && comparar.ToLower() != "n");
    Console.Write("\n\n");

} while (bandera);
Console.Write("Gracias por usar nuestro servicio...\n\n");