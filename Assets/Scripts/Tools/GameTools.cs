using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AFSInterview
{
    public class GameTools : MonoBehaviour
    {
		static public void CriticalError(string text)
		{
			Debug.LogError(text);
			Debug.Break();
		}

		internal static Vector3 CreateRandVectorXZ(Vector3 min, Vector3 max, float y = 0.0f)
		{
			return new Vector3(Random.Range(min.x, max.x), y, Random.Range(min.z, max.z));
		}
	}
}
