using Matriz;

try
{
    Console.Write("Ingrese orden de la matriz: ");
    int orden = int.Parse(Console.ReadLine());

    MatrizOperation matriz = new MatrizOperation(orden);
    matriz.LlenarMatriz();
    matriz.MostrarResultados();
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}
