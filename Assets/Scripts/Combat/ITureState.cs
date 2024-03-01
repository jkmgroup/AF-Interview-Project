
namespace AFSInterview.Combat
{
	public interface ITureState
	{
		void EnterState(TureStateMachine stateMachine, CombatManager combatManager);
		void UpdateState(TureStateMachine stateMachine);
		void ExitState(TureStateMachine stateMachine);
	}
}