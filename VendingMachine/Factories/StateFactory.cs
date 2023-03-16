using System;
using VendingMachine.Models;
using VendingMachine.Models.StateMachine.States;
using VendingMachine.Services;

namespace VendingMachine.Factories
{
	public class StateFactory
	{
		private readonly InsertCoinService _insertCoinService;
		private readonly SelectProductService _selectProductService;
		private readonly ReturnCoinsService _returnCoinsService;
		public enum State
		{
			InitialState,
			InsertCoins,
			ReturnCoins,
			SelectProduct,
			SoldOut
			
		}

		public StateFactory(
			InsertCoinService insertCoinService,
			SelectProductService selectProductService,
			ReturnCoinsService returnCoinsService)
		{
			_insertCoinService = insertCoinService;
			_selectProductService = selectProductService;
			_returnCoinsService = returnCoinsService;
		}

		public IState GetState(State state) => state switch
		{
			State.InitialState => new InitialState(this),
			State.InsertCoins => new InsertCoins(_insertCoinService),
			State.ReturnCoins => new ReturnCoins(_returnCoinsService),
			State.SelectProduct => new SelectProduct(_selectProductService),
			_ => throw new ArgumentOutOfRangeException(nameof(state), state, "Unknown State Given")
		};
	}
}

