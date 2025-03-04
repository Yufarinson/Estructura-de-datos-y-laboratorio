using Descomposicion;

try
{
    Console.Write("Ingrese el número a descomponer: ");
    int numero = int.Parse(Console.ReadLine());

    Descomponer descomposicion = new Descomponer(numero);
    descomposicion.DescomponerNumero();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
