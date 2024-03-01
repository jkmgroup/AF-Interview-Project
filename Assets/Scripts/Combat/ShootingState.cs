using System.Collections;
using UnityEngine;

namespace AFSInterview.Combat
{
	public class ShootingState : ITureState
	{
		private bool allUnitsUpdated = false;
		public void EnterState(TureStateMachine stateMachine, CombatManager combatManager)
		{
			allUnitsUpdated = false;
			combatManager.StartCoroutine(UnitsUpdate(combatManager));
		}

		private IEnumerator UnitsUpdate(CombatManager combatManager)
		{
			yield return new WaitForSeconds(1.0f);
			foreach (var unit in combatManager.Units)
				if (unit != null && unit.IsActiveInThisTure())
				{
					unit.ChangeStage(Units.UnitBase.Stage.TryFoundTargetAndShoot);
					yield return new WaitForSeconds(2.0f);
					unit.ChangeStage(Units.UnitBase.Stage.Wait);
					yield return new WaitForSeconds(1.0f);
				}
			allUnitsUpdated = true;
		}

		public void UpdateState(TureStateMachine stateMachine)
		{
			if (allUnitsUpdated)
				stateMachine.ChangeState(new BreakState());
		}

		public void ExitState(TureStateMachine stateMachine)
		{
		}
	}
}