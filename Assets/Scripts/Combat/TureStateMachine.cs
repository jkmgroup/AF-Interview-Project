namespace AFSInterview.Combat
{
	public class TureStateMachine
	{
		private ITureState currentState;
		private CombatManager combatManager;

		public TureStateMachine(CombatManager combatManager)
		{
			this.combatManager = combatManager;
			ChangeState(new ShootingState());
		}

		public void ChangeState(ITureState newState)
		{
			currentState?.ExitState(this);
			currentState = newState;
			currentState.EnterState(this, combatManager);
		}

		public void Update()
		{
			currentState.UpdateState(this);
		}
	}
}