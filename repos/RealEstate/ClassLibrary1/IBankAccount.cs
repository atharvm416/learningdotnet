public interface IBankAccount
{
    void deposit(decimal amount);

    bool withdraw (decimal amount);

    decimal checkbalance();
}