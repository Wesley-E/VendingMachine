using VendingMachine.Factories;

namespace VendingMachine.Models.StateMachine
{
	public class Context
	{
		private IState? _state;
		public VendingContext VendingContext { get; private set; }

		public Context(StateFactory stateFactory, VendingContext vendingContext)
		{
			VendingContext = vendingContext;
			TransitionTo(stateFactory.GetState(StateFactory.State.InitialState));
		}

		public void TransitionTo(IState state)
		{
			Console.WriteLine($"Context: Transition to {state.GetType().Name}");
			_state = state;
			_state.SetContext(this);
		}

		public void Process()
		{
			_state?.Process();
		}
	}
}

