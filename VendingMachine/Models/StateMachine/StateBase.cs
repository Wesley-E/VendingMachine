namespace VendingMachine.Models.StateMachine
{
	public abstract class StateBase : IState
	{
        protected Context? Context;

        public void SetContext(Context context)
        {
            Context = context;
        }

        public abstract void Process();
    }
}

