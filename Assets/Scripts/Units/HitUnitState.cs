using UnityEngine;

namespace AFSInterview.Units
{
	public class HitUnitState : IUnitState
	{
		private UnitBase unit;
		private float jumpTime ;
		private Vector3 startPos;

		public void EnterState(UnitStateMachine stateMachine, UnitBase unit)
		{
			this.unit = unit;
			jumpTime = 1;
			startPos = unit.transform.position;
		}

		public void ExitState(UnitStateMachine stateMachine)
		{
			unit.transform.position = startPos;
		}

		public void UpdateState(UnitStateMachine stateMachine)
		{
			jumpTime -= Time.deltaTime;
			if (jumpTime < 0)
			{
				stateMachine.ChangeState(new WaitState());
				return;
			}
			else
			if (jumpTime > 0.5)
			{
				var pos = unit.transform.position;
				pos.y += Time.deltaTime * 3.0f;
				unit.transform.position = pos;
			}
			else
			{
				var pos = unit.transform.position;
				pos.y -= Time.deltaTime * 3.0f;
				unit.transform.position = pos;
			}
		}
	}
}
