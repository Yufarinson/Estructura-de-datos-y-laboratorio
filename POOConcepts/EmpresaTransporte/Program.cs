
using EmpresaTransporte_11;

var obj = new Liquidacion();

Console.WriteLine("***DATOS DE ENTRADA***");

Console.Write("Ruta [1] [2] [3] [4]");
var ruta = obj.ValidarEntradaEntero();

Console.Write("Número de viajes: ");
var numeroViajes = obj.ValidarEntradaEntero();

Console.Write("Número de pasajeros total: ");
var numeroPasajeros = obj.ValidarEntradaEntero();

Console.Write("Número de encomienda de menos de 10kg: ");
int paquete10k = obj.ValidarEntradaEntero();

Console.Write("Número de encomienda de entre 10kg y menos de 20kg: ");
int paquete10k_20k = obj.ValidarEntradaEntero();

Console.Write("Número de encomienda de más de 20k: ");
int paquete20k = obj.ValidarEntradaEntero();

var valor = new Liquidacion(ruta, numeroViajes, numeroPasajeros, paquete10k, paquete10k_20k, paquete20k);

Console.WriteLine("\n***CALCULOS***");
Console.WriteLine($"Ingreso por pasajeros: {valor.CalcularComisiones()}");
Console.WriteLine($"Ingreso por encomiendas: {valor.CalcularValorPaquete()}");

Console.WriteLine("\n***TOTAL INGRESOS***");
Console.WriteLine($"Total ingresos: {valor.CalcularComisiones() + valor.CalcularValorPaquete()}");
Console.WriteLine($"Pago ayudante: {valor.CalcularPagoAyudante()}");
Console.WriteLine($"Seguro seguro: {valor.CalcularPagoSeguroAyudante()}");
Console.WriteLine($"Pago combustible: {valor.CalcularConsumoCombustible()}");

Console.WriteLine("\n***TOTAL DEDUCCIONES***");
Console.WriteLine($"Total deducciones: {(valor.CalcularComisiones() + valor.CalcularValorPaquete()) - valor.CalcularPagoAyudante() - valor.CalcularPagoSeguroAyudante() - valor.CalcularConsumoCombustible()}");
Console.WriteLine($"Total a liquidar: {valor.CalcularPagoSeguroAyudante()}");
