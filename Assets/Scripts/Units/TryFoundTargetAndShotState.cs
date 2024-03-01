using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Units
{
	public class TryFoundTargetAndShotState : IUnitState
	{
		private UnitBase target;
		private float startAngleY = 0.0f;
		private float rootDirAndSpeed = 90.0f;
		private UnitBase unit;

		public void EnterState(UnitStateMachine stateMachine, UnitBase unit)
		{
			this.unit = unit;
			var enems = new List<UnitBase>();
			foreach (var army in unit.CombatManager.Armies)
				if (army.transform != unit.transform.parent)
				{
					var units = army.GetComponentsInChildren<UnitBase>();
					foreach (var enemyUnit in units)
						enems.Add(enemyUnit);
				}
			if (enems.Count>0)
				target = GameTools.GetRandomItem(enems);
			startAngleY = unit.transform.rotation.eulerAngles.y;
		}

		public void ExitState(UnitStateMachine stateMachine)
		{
			if (target)
			{
				Debug.Log(target.name + " hit by " + unit.name);
				target.TakeDamage(unit.AttackDamage);
			}
			var angles = unit.transform.rotation.eulerAngles;
			angles.y = startAngleY;
			unit.transform.rotation = Quaternion.Euler(angles);
		}

		public void UpdateState(UnitStateMachine stateMachine)
		{
			var angles = unit.transform.rotation.eulerAngles;
			angles.y += Time.deltaTime * rootDirAndSpeed;
			if (rootDirAndSpeed < 0 && (angles.y - startAngleY) < -30.0f)
				rootDirAndSpeed = -rootDirAndSpeed;
			else
			if (rootDirAndSpeed > 0 && (angles.y - startAngleY) >30.0f)
				rootDirAndSpeed = -rootDirAndSpeed;
			unit.transform.rotation = Quaternion.Euler(angles);
		}
	}
}