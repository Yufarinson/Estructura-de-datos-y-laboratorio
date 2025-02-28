using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOConcepts;

public class BaseComissionEmployee : ComissionEmployee
{

    private decimal _salary;
    public BaseComissionEmployee(int id, string firstName, string lastName, bool isActive, Date? bornDate, Date? hireDate, float comissionPercentaje, decimal seles, decimal salary)
        : base(id, firstName, lastName, isActive, bornDate, hireDate, comissionPercentaje, seles)
    {
        Salary = salary;
    }

    public decimal Salary { get => _salary; set => _salary = ValidateSalary(value); }

    public override string ToString()
    {
        return $"{base.ToString()}\n\t" +
            $"Salary..........: {Salary,20:C2}\n\t" +
            $"Value to pay....: {GetValueToPay(),20:C2}";
    }

    public override decimal GetValueToPay()
    {
        return base.GetValueToPay() + Salary;
    }

    public decimal ValidateSalary(decimal salary)
    {
        if (salary < 500000)
        {
            throw new ArgumentException($"The salary: {salary:C2} is less than the $500.000.");
        }
        return salary;
    }
}
