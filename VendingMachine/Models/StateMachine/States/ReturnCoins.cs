using System;
using VendingMachine.Services;

namespace VendingMachine.Models.StateMachine.States
{
	public class ReturnCoins : StateBase
	{
		private readonly ReturnCoinsService _returnCoinsService;
		public ReturnCoins(ReturnCoinsService returnCoinsService)
		{
			_returnCoinsService = returnCoinsService;
		}

		public override void Process()
		{
			_returnCoinsService.Process(Context);
		}
	}
}

