namespace AFSInterview.Combat
{
	internal class GameOverState : ITureState
	{
		public void EnterState(TureStateMachine stateMachine, CombatManager combatManager)
		{
			combatManager.GameOverCanvas.SetActive(true);
		}

		public void ExitState(TureStateMachine stateMachine)
		{
		}

		public void UpdateState(TureStateMachine stateMachine)
		{
		}
	}
}