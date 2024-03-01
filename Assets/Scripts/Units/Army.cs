using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Units
{
    public class Army : MonoBehaviour
    {
		[System.Serializable]
		public class UnitAtStart
		{
			public UnitBase prefab;
			public int numUnits = 1;
		}

		[SerializeField]
		UnitAtStart[] unitsAtStart;

		[SerializeField]
		float armySpawnFieldSize = 1.0f;
		[SerializeField]
		float forwardAngle = 0.0f;

		private void Start()
		{
			var min = transform.position - Vector3.one * armySpawnFieldSize*0.5f;
			var max = transform.position + Vector3.one * armySpawnFieldSize*0.5f;
			foreach (var unit in unitsAtStart)
			{
				for (var i = 0; i < unit.numUnits; i++)
					Instantiate(unit.prefab, GameTools.CreateRandVectorXZ(min, max), Quaternion.Euler(0.0f, forwardAngle, 0.0f), transform);
			}
		}
		private void OnDrawGizmosSelected()
		{
			var forwardVector = Quaternion.Euler(0, forwardAngle, 0) * Vector3.forward * 5.0f;
			Gizmos.DrawLine(transform.position, transform.position + forwardVector);
		}
	}
}
