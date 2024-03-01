using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
	[CreateAssetMenu(fileName = "GameConfig", menuName = "Game/GameConfig", order = 0)]
	public class GameConfig : ScriptableObject
    {
		[System.Serializable]
		public class ConsumableDefinition 
		{
			public string name;
			public int maxValue;
		}
		public ConsumableDefinition[] consumableDefinitions = new ConsumableDefinition[] { new ConsumableDefinition { name = "Money", maxValue = int.MaxValue } };
	}
}
