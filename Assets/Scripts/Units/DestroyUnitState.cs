using UnityEngine;

namespace AFSInterview.Units
{
	public class DestroyUnitState : IUnitState
	{
		private UnitBase unit;
		private float timeToDestroy;

		public void EnterState(UnitStateMachine stateMachine, UnitBase unit)
		{
			this.unit = unit;
			timeToDestroy = 2.0f;
		}

		public void ExitState(UnitStateMachine stateMachine)
		{
		}

		public void UpdateState(UnitStateMachine stateMachine)
		{
			timeToDestroy -= Time.deltaTime;
			if (timeToDestroy < 0)
				GameObject.Destroy(unit.gameObject);
			var pos = unit.transform.position;
			pos.y -= Time.deltaTime;
			unit.transform.position = pos;
		}
	}
}