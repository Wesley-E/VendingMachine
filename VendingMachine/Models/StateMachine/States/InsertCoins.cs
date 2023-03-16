using System;
using VendingMachine.Services;

namespace VendingMachine.Models.StateMachine.States
{
	public class InsertCoins : StateBase
	{
		private readonly InsertCoinService _insertCoinService;
		public InsertCoins(
			InsertCoinService insertCoinService)
		{
			_insertCoinService = insertCoinService;
		}

        public override void Process()
        {
	        _insertCoinService.Process(Context);
        }
        
    }
}

