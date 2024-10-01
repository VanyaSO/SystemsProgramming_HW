namespace HW_4;
// Предположим, у вас есть консольное приложение, имитирующее банк с несколькими банкоматами.
// Каждый банкомат позволяет клиентам снимать деньги со своих счетов.
// Однако если два клиента попытаются снять деньги одновременно, существует риск того, что основной баланс в банке,
// станет отрицательным, в итоге выдача средств клиенту засчитается, но купюр он не получит.


class Bank
{
    private int _balance = 1000;

    public void WithdrawMoney(int sum)
    {
        lock (this)
        {
            if (sum > _balance)
            {
                Console.WriteLine("Недостаточно средств");
            }
            else
            {
                Thread.Sleep(500);
                _balance -= sum;
            }
        }
    }

    public int GetBalance() => _balance;
}

class ATM
{
    private Bank bank;

    public ATM(Bank bank)
    {
        this.bank = bank;
    }

    public void WithdrawMoney(int amount) => bank.WithdrawMoney(amount);
}

class Program
{
    static void Main()
    {
        Bank bank = new Bank();
        ATM atm = new ATM(bank);
        ATM atm1 = new ATM(bank);

        new Thread(() => atm.WithdrawMoney(500)).Start(); 
        new Thread(() => atm1.WithdrawMoney(750)).Start(); 

        Console.WriteLine($"Баланс: {bank.GetBalance()}");
        Console.ReadLine();
    }
}
