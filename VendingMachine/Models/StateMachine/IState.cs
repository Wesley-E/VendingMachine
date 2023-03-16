using System;
using VendingMachine.Models.StateMachine;

namespace VendingMachine.Models
{
	public interface IState
	{
		public void SetContext(Context context);
		public void Process();
	}
}

