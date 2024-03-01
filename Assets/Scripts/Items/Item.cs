namespace AFSInterview.Items
{
	using System;
	using UnityEngine;

	[Serializable]
	public class Item
	{
		[SerializeField] protected string name;
		[SerializeField] protected int price;

		public string Name
		{
			get => name;
			set => name = value;
		}

		public int Price
		{
			get => price;
			set => price = value;
		}

		public Item(string name, int price)
		{
			this.name = name;
			this.price = price;
		}

		public virtual Item Clone()
		{
			return new Item(name, price);
		}

		public virtual void Use(InventoryController inventoryController)
		{
			Debug.Log("Using" + Name);
		}		
	}
}