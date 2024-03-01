using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview
{
    public class SceneGlobalData : MonoBehaviour
    {
		public GameConfig gameConfig;
		private static SceneGlobalData instance;
		#region Singleton 
		public static SceneGlobalData Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<SceneGlobalData>();
					if (instance == null)
					{
						GameTools.CriticalError("You must add SceneGlobalData to scene.");
					}
				}
				return instance;
			}
		}

		private void Awake()
		{
			if (instance == null)
			{
				instance = this;
				instance.Validata();
			}
			else
			if (instance != this)
			{
				Destroy(gameObject);
			}
		}
		#endregion //Singleton 

		#region Validata
		private void Validata()
		{
			if (gameConfig == null)
				GameTools.CriticalError("Please set gameConfig in " + name);
		}
		#endregion //Validata
	}
}
