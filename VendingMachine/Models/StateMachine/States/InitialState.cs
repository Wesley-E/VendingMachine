using System;
using VendingMachine.Factories;
using VendingMachine.Services;

namespace VendingMachine.Models.StateMachine.States
{
    public class InitialState : StateBase
    {
        private readonly StateFactory _stateFactory;

        public InitialState(
            StateFactory stateFactory)
        {
            _stateFactory = stateFactory;
        }

        public override void Process()
        {
            do
            {
                while (!Console.KeyAvailable)
                {
                    // I = InsertCoin / S = SelectProduct
                    Console.WriteLine("To Insert Coin Press: I");
                    Console.WriteLine("To Select Product Press: S");
                    switch (Console.ReadKey(true).Key)
                    {
                        case ConsoleKey.I:
                        {
                            Context?.TransitionTo(_stateFactory.GetState(StateFactory.State.InsertCoins));
                            Context?.Process();
                            break;
                        }
                        case ConsoleKey.S:
                        {
                            Context?.TransitionTo(_stateFactory.GetState(StateFactory.State.SelectProduct));
                            Context?.Process();
                            break;
                        }
                    }
                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.A);
            Console.WriteLine("Hi");
        }
    }
}

