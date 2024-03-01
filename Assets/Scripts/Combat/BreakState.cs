using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Combat
{
	public class BreakState : ITureState
	{
		private bool isGameOver = false;
		private GameObject nextTureButton;

		public void EnterState(TureStateMachine stateMachine, CombatManager combatManager)
		{
			new BreakState();
			var units = combatManager.Units;
			var armys = new Dictionary<Transform, int>();
			for (var i = units.Count-1; i >= 0; i--)
			{
				if (units[i] == null)
					units.RemoveAt(i);
				else
				{
					if (armys.ContainsKey(units[i].transform.parent))
						armys[units[i].transform.parent]++;
					else
						armys[units[i].transform.parent] = 0;
				}
			}
			isGameOver = armys.Count < 2;
			nextTureButton = combatManager.NextTureButton;
			if (!isGameOver)
				nextTureButton.SetActive(true);
			else
				stateMachine.ChangeState(new GameOverState());
		}

		public void UpdateState(TureStateMachine stateMachine)
		{
		}

		public void ExitState(TureStateMachine stateMachine)
		{
			nextTureButton.SetActive(false);
		}
	}
}