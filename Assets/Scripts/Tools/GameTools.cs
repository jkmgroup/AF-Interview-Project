using System;
using System.Collections.Generic;
using AFSInterview.Units;
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

		static public Vector3 CreateRandVectorXZ(Vector3 min, Vector3 max, float y = 0.0f)
		{
			return new Vector3(Random.Range(min.x, max.x), y, Random.Range(min.z, max.z));
		}

		static public List<T> ArrayToList<T>(T[] items)
		{
			var rezult = new List<T>();
			foreach (var item in items)
				rezult.Add(item);
			return rezult;
		}

		static public T1[] CreateConvertedArray<T1,T2>(T2[] values, Func<T2, T1> createNew)
		{
			var rezult = new T1[values.Length];
			for (var i = 0; i < rezult.Length; i++)
				rezult[i] = createNew(values[i]);
			return rezult;
		}

		static public List<T> MakeRandom<T>(List<T> values)
		{
			var randomList = new List<T>();
			foreach (var value in values)
				randomList.Add(value);
			for (var i = 0; i < randomList.Count - 1; i++)
			{
				var index = Random.Range(i, randomList.Count);
				FlipIndexes(randomList, i, index);
			}
			return randomList;
		}

		static public void FlipIndexes<T>(List<T> values, int a, int b)
		{
			var tmp = values[a];
			values[a] = values[b];
			values[b] = tmp;
		}

		static public bool InRange<T>(List<T> items, int index)
		{
			return index > -1 && index < items.Count;
		}

		static public T GetRandomItem<T>(T[] items)
		{
			var index = Random.Range(0, items.Length);
			return items[index];
		}

		static public T GetRandomItem<T>(List<T> items)
		{
			var index = Random.Range(0, items.Count);
			return items[index];
		}
	}
}
