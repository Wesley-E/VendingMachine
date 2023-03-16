using VendingMachine.Factories;
using VendingMachine.Models.StateMachine;
using VendingMachine.Models.StateMachine.States;
using VendingMachine.Services;

namespace VendingMachine;

internal static class Program
{
    private static void Main(string[] args)
    {
        var stateFactory = new StateFactory(
            new InsertCoinService(), 
            new SelectProductService(),
            new ReturnCoinsService());
        var context = new Context(stateFactory, new VendingContext());
        while (true)
        {
            context.Process();
        }
    }
}