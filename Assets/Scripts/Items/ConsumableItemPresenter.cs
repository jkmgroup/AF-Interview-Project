namespace AFSInterview.Items
{
	using UnityEngine;

	public class ConsumableItemPresenter : MonoBehaviour, IItemHolder
	{
		[SerializeField] private ConsumableItem item;
        
		public Item GetItem(bool disposeHolder)
		{
			if (item ==null)
				item = new ConsumableItem("item", 10, 10, 10);
			if (disposeHolder)
			{
				ItemsPool.Instance.AddObject(gameObject);
				return item.Clone();
			}
			return item;
		}
	}
}