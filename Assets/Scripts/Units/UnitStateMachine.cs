namespace AFSInterview.Units
{
	public class UnitStateMachine
	{
		private IUnitState currentState;
		private UnitBase unit;
		public UnitStateMachine(UnitBase unit)
		{
			this.unit = unit;
			ChangeState(new WaitState());
		}

		public void ChangeState(IUnitState newState)
		{
			currentState?.ExitState(this);
			currentState = newState;
			currentState.EnterState(this, unit);
		}

		public void Update()
		{
			currentState.UpdateState(this);
		}
	}
}