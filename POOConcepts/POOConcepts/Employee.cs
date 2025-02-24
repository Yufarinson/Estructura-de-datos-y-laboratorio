using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POOConcepts;

public abstract class Employee
{

    public Employee(int id, string firstName, string lastName, bool isActive, Date? bornDate, Date? hireDate)
    {
        ID = id;
        FirstName = firstName;
        LastName = lastName;
        IsActive = isActive;
        BornDate = bornDate;
        HireDate = hireDate;
    }


    public int ID { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public bool IsActive { get; set; }
    public Date? BornDate { get; set; }
    public Date? HireDate { get; set; }

    public override string ToString()
    {
        return $"{ID}\t{FirstName} {LastName}\n\t" +
            $"Is active.......: {IsActive,20:C2}\n\t" +
            $"Born Date.......: {BornDate,20:C2}\n\t" +
            $"Hire Date.......: {HireDate,20:C2}";
    }

    public abstract decimal GetValueToPay();
}
