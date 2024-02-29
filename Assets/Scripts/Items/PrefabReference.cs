using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    public class PrefabReference : MonoBehaviour
    {
		[SerializeField]
		private PrefabReference prefab;
		public PrefabReference Prefab => prefab;
	}
}
