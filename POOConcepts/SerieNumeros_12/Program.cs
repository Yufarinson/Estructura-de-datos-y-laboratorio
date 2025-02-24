
using SerieNumeros_12;

Console.WriteLine("Cuántos números deseas: ");
int numero = Convert.ToInt32(Console.ReadLine());

var obj = new SerieNumeros(numero);

obj.MostrarNumeros();
Console.Write($"La sumatoria es: {obj.SumatoriaDeNumeros()}");
Console.Write($"\nEl promedio es: {obj.PromedioDeNumeros()}");
