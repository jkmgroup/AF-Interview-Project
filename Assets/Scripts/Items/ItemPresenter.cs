namespace AFSInterview.Items
{
	using UnityEngine;

	public class ItemPresenter : MonoBehaviour, IItemHolder
	{
		[SerializeField] private Item item;
        
		public Item GetItem(bool disposeHolder)
		{
			if (disposeHolder)
				ItemsPool.Instance.AddObject(gameObject);

			return item.Clone();
		}
	}
}