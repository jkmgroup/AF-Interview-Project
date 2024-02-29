using System;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Base
{
	public class ObjectPoolBase : MonoBehaviour
	{
		public delegate void SetObjectParams(GameObject gameObject);
		[System.Serializable]
		public class PoolObject
		{
			public GameObject prefab;
			public int maxInstances = 10;
		}

		private class QueueObject
		{
			public int maxInstances;
			public Queue<GameObject> objects;
			public QueueObject(int maxInstances)
			{
				this.maxInstances = maxInstances;
				this.objects = new Queue<GameObject>();
			}
		}

		[SerializeField]
		private Transform objectsHolder;
		[SerializeField]
		private List<PoolObject> poolObjects;
		private Dictionary<string, QueueObject> pools = new Dictionary<string, QueueObject>();	

		private void Start()
		{
			foreach (var poolObject in poolObjects)
			{
				if (poolObject.prefab.GetComponent<PrefabReference>() == null)
					poolObject.prefab.AddComponent<PrefabReference>();
				pools[poolObject.prefab.name] = new QueueObject(poolObject.maxInstances);
			}
		}

		public GameObject GetObject(GameObject prefab, SetObjectParams setObjectParams) 
		{
			GameObject rezult = null;
			if (IsObjectInPool(prefab))
				rezult = pools[prefab.name].objects.Dequeue();
			else
			{
				rezult = Instantiate(prefab);
				rezult.name = prefab.name;
			}
			setObjectParams(rezult);
			return rezult;
		}

		private bool IsObjectInPool(GameObject prefab)
		{
			return (pools.ContainsKey(prefab.name) && pools[prefab.name].objects.Count > 0);
		}

		public void AddObject(GameObject gameObject)
		{
			var prefab = gameObject.GetComponent<PrefabReference>();
			if (!prefab || !pools.ContainsKey(prefab.Prefab.name))
			{
				GameTools.CriticalError("Type of this object (" + gameObject.name + ") didn't found in pool!");
				return;
			}
			if (pools[gameObject.name].objects.Count >= pools[gameObject.name].maxInstances)
			{
				GameObject.Destroy(gameObject);
				return;
			}
			gameObject.transform.parent = objectsHolder;
			pools[gameObject.name].objects.Enqueue(gameObject);
		}
	}
}
