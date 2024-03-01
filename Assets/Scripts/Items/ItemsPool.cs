using UnityEngine;
using AFSInterview.Base;
namespace AFSInterview
{
	public class ItemsPool : ObjectPoolBase
	{
		private static ItemsPool instance;

		public static ItemsPool Instance
		{
			get
			{
				if (instance == null)
				{
					instance = FindObjectOfType<ItemsPool>();
					if (instance == null)
					{
						GameObject obj = new GameObject("ItemsPool");
						instance = obj.AddComponent<ItemsPool>();
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
			}
			else if (instance != this)
			{
				Destroy(gameObject);
			}
		}
	}
}
