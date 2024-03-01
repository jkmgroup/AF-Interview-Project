namespace AFSInterview.Units
{
	public interface IUnitState
	{
		void EnterState(UnitStateMachine stateMachine, UnitBase unit);
		void UpdateState(UnitStateMachine stateMachine);
		void ExitState(UnitStateMachine stateMachine);
	}
}