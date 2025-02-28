using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOConcepts;

public class HourlyEmployee : Employee
{
    private int _workingHours;
    private decimal _valueHours;
    public HourlyEmployee(int id, string firstName, string lastName, bool isActive, Date? bornDate, Date? hireDate, int workingHours, decimal valueHours) 
        : base(id, firstName, lastName, isActive, bornDate, hireDate)
    {
        WorkingHours = workingHours;
        ValueHours = valueHours;
    }

    public int WorkingHours { get => _workingHours; set => _workingHours = ValidateWorkingHours(value); }
    public decimal ValueHours { get => _valueHours; set => _valueHours = ValidateValueHours(value); }

    public override string ToString()
    {
        return $"{base.ToString()}\n\t" +
            $"Working hours...: {WorkingHours,20:N2}\n\t" +
            $"Hours value.....: {ValueHours,20:C2}\n\t" +
            $"Value to pay....: {GetValueToPay(),20:C2}";
    }

    public override decimal GetValueToPay()
    {
        return ValueHours * WorkingHours;
    }

    private int ValidateWorkingHours(int workingHours)
    {
        if (workingHours < 0)
        {
            throw new Exception($"The working hours: {workingHours} not is valid.");
        }
        return workingHours;
    }

    private decimal ValidateValueHours(decimal valueHours)
    {
        if (valueHours < 10000)
        {
            throw new Exception($"The value hours: {valueHours:C2} is less than $10,000.");
        }
        return valueHours;
    }
}
