using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOConcepts;

public class ComissionEmployee : Employee
{

    private float _comissionPercentaje;
    private decimal _seles;
    public ComissionEmployee(int id, string firstName, string lastName, bool isActive, Date? bornDate, Date? hireDate, float comissionPercentaje, decimal seles) 
        : base(id, firstName, lastName, isActive, bornDate, hireDate)
    {
        ComissionPercentaje = comissionPercentaje;
        Seles = seles;
    }

    public float ComissionPercentaje { get => _comissionPercentaje; set => _comissionPercentaje = ValidateComissionPercentaje(value); }
    public decimal Seles { get => _seles; set => _seles = ValidateSales(value); }

    public override string ToString()
    {
        return $"{base.ToString()}\n\t" +
            $"Comission %.....: {ComissionPercentaje,20:P2}\n\t" +
            $"Sales...........: {Seles,20:C2}\n\t" +
            $"Value to pay....: {GetValueToPay(),20:C2}";
    }

    public override decimal GetValueToPay()
    {
        return (decimal) ComissionPercentaje * Seles;
    }

    private float ValidateComissionPercentaje(float comissionPercentaje)
    {
        if (comissionPercentaje < 0 || comissionPercentaje > 0.3)
        {
            throw new Exception($"The comission percentaje: {comissionPercentaje:P2} is not valid.");
        }
        return comissionPercentaje;
    }

    private decimal ValidateSales(decimal sales)
    {
        if (sales < 0)
        {
            throw new Exception($"The sales: {sales:C2} is less than $0.00.");
        }
        return sales;
    }
}
