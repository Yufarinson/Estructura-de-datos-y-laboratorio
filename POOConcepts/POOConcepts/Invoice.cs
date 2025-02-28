using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOConcepts;

public class Invoice : IPay
{
    private float _quantity;
    private decimal _value;

    public Invoice(int id, string description, Date date, decimal value, float quantity)
    {
        Id = id;
        Description = description;
        Date = date;
        Quantity = quantity;
        Value = value;
    }

    public int Id { get; set; }
    public string Description { get; set; } = null!;
    public Date Date { get; set; } = null!;

    public float Quantity { get => _quantity; set => _quantity = ValidateQuantity(value); }
    public decimal Value { get => _value; set => _value = ValidateValue(value); }

    public override string ToString()
    {
        return $"{Id}\t{Description}\n\t" +
            $"Date...........: {Date,20:C2}\n\t" +
            $"Quantity.......: {Quantity,20:C2}\n\t" +
            $"Value..........: {Value,20:C2}\n\t" +
            $"To pay.........: {GetValueToPay(),20:C2}";
    }

    public decimal GetValueToPay()
    {
        return (decimal) Quantity * Value;
    }

    private float ValidateQuantity(float quiantity)
    {
        if (quiantity < 0)
        {
            throw new Exception($"The working hours: {quiantity} not is valid.");
        }
        return quiantity;
    }

    private decimal ValidateValue(decimal value)
    {
        if (value < 0)
        {
            throw new Exception($"The value: {value} not is valid.");
        }
        return value;
    }
}
