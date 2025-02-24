using POOConcepts;


try
{
    var secretario = new SalaryEmployee(1, "Sandra", "Martinez", true, new Date(1981, 11, 14), new Date(2022, 3, 14), 2500000M);
    var manager = new SalaryEmployee(1, "Fabio", "Ochoa", true, new Date(1981, 11, 14), new Date(2022, 3, 14), 11746324.15M);

    var employees = new List<Employee>() { secretario, manager };

    foreach (var employee in employees)
    {
        Console.WriteLine(employee);
        Console.WriteLine("______________________________________________");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex);
}
