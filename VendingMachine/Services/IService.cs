using System;
using VendingMachine.Models.StateMachine;

namespace VendingMachine.Services
{
	public interface IService
	{
		public Context? Process(Context? context);
	}
}

