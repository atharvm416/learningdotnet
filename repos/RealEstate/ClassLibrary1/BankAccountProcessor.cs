using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1;

public class BankAccountProcessor : IBankAccount
{
    private decimal savingBalance = 0;
    public void deposit(decimal amount)
    {
        savingBalance = savingBalance + amount;
    }

    public bool withdraw(decimal amount)
    {
        savingBalance -= amount;
        return true;
    }

    public decimal checkbalance()
    {
        return savingBalance;
    }
}
