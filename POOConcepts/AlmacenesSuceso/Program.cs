using AlmacenesSuceso_10;
using System.Reflection;

var dato1 = new Producto();
var bandera = false;
var comparar = "";

do
{
    Console.WriteLine("***DATOS DE ENTRADA***");

    Console.Write("\nCosto de compra: ");
    var cc = dato1.ValidarEntradaDouble();

    Console.Write("Tipo de producto [1]Perecedero [2]No perecedero: ");
    var tp = dato1.ValidarEntradaEntero();

    Console.Write("Tipo de conservacion [1]Frío [2]Ambiente: ");
    var tc = dato1.ValidarEntradaEntero();


    Console.Write("Periodo de conservación (días): ");
    var pc = dato1.ValidarEntradaDouble();

    Console.Write("Periodo de almacenamiento (días): ");
    var pa = dato1.ValidarEntradaDouble();

    Console.Write("Volumen (litros): ");
    var vol = dato1.ValidarEntradaDouble();

    Console.Write("Medio de almacenamiento [1]Nevera, [2]Congelador, [3]Estantería, [4]Guacal: ");
    var ma = dato1.ValidarEntradaEntero();



    var dato2 = new Producto(cc, tp, tc, pc, pa, vol, ma);

    Console.WriteLine("\n\n***FACTURA***");


    var costoAlmacenamiento = dato2.CostoAlmacenamiento();
    var porcentajeDepreciacion = dato2.DepreciacionProducto();
    var costoExhibicion = dato2.CostoDeExhibicion();
    var valorProducto = (cc + costoAlmacenamiento + costoExhibicion) * porcentajeDepreciacion;
    var valorVenta = valorProducto + (tp == 2 ? valorProducto * 0.20 : valorProducto * 0.40);



    Console.Write($"Costo compra.............................................................{cc}");
    Console.Write($"\nTipo de producto [P]erecedero, [N]o perecedero...........................{tp}");
    Console.Write($"\nTipo de conservación [F]rio, [A]mbiente..................................{tc}");
    Console.Write($"\nPeriodo de conservación (días)...........................................{pc}");
    Console.Write($"\nPeriodo de almacenamiento (días).........................................{pa}");
    Console.Write($"\nVolumen (litros).........................................................{vol}");
    Console.Write($"\nMedio de almacenamiento [N]evera, [C]ongelador, [E]stantería, [G]uacal...{ma}");
    Console.Write($"\n***Cálculos***");
    Console.Write($"\nCostos de almacenamiento.................................................{costoAlmacenamiento}");
    Console.Write($"\nPorcentaje de depreciación...............................................{porcentajeDepreciacion}");
    Console.Write($"\nCosto de exhibición......................................................{costoExhibicion}");
    Console.Write($"\nValor producto...........................................................{valorProducto}");
    Console.Write($"\nValor venta..............................................................{valorVenta}");

    do
    {
        Console.Write("\nDesea realizar un nuevo cálculo? [S]í [N]o: ");
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
Console.Write("\nGracias por usar nuestro servicio...\n\n");
