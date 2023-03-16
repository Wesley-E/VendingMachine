using System;
using VendingMachine.Services;

namespace VendingMachine.Models.StateMachine.States
{
	public class SelectProduct : StateBase
	{
		private readonly SelectProductService _selectProductService;

		public SelectProduct(SelectProductService selectProductService)
		{
			_selectProductService = selectProductService;
		}

		public override void Process()
		{
			_selectProductService.Process(Context);
		}
    }
}

