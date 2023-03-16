using VendingMachine.Models.StateMachine;
using VendingMachine.ValueSets;

namespace VendingMachine.Services;

public class InsertCoinService : IService
{
    public Context? Process(Context? context)
    {
        Console.WriteLine("Insert Coins");
        Console.WriteLine("Z = 1p / X = 2p / C = 5p / V = 10p / B = 20p / N = 50p / M = £1 / L = £2 / Exit = Backspace");
        
        while (!Console.KeyAvailable)
        {
            var key = Console.ReadKey(true).Key;
            if (key == ConsoleKey.Backspace)
                break;
            var insertedCoin = InsertCoin(key);
            if (insertedCoin == null)
            {
                Console.WriteLine($"{nameof(key)} is not a valid coin");
            }
            else
            {
                AdjustBalance(context, (decimal)insertedCoin);
            }
            
            Console.WriteLine($"Balance: {string.Format($"{context.VendingContext.CustomerBalance:C}")}");
        }
        return context;
    }

    // Z = 1p / X = 2p / C = 5p / V = 10p / B = 20p / N = 50p / M = £1 / L = £2
    private static int? InsertCoin(ConsoleKey key) => key switch
    {
        ConsoleKey.Z => (int) Coins.Z,
        ConsoleKey.X => (int) Coins.X,
        ConsoleKey.C => (int) Coins.C,
        ConsoleKey.V => (int) Coins.V,
        ConsoleKey.B => (int) Coins.B,
        ConsoleKey.N => (int) Coins.N,
        ConsoleKey.M => (int) Coins.M,
        ConsoleKey.L => (int) Coins.L,
        _ => null
    };

    private static void AdjustBalance(Context context, decimal amount)
    {
        amount /= 100;
        context.VendingContext.VendingMachineBalance += amount;
        context.VendingContext.CustomerBalance += amount;
    }
}