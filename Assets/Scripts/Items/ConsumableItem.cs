using System;
using UnityEngine;

namespace AFSInterview.Items
{
	[Serializable]
	public class ConsumableItem : Item
	{
		[SerializeField] private int consumableType;
		[SerializeField] private int value;

		public int ConsumableDefinition
		{
			get => consumableType;
			set => consumableType = value;
		}
		public int Value
		{
			get => value;
			set => this.value = value;
		}

		public ConsumableItem(string name, int price, int consumableType, int value)
			: base(name, price)
		{
			this.consumableType = consumableType;
			this.value = value;
		}

		public override void Use(InventoryController inventoryController)
		{
			inventoryController.AddConsumableValue(consumableType, value);
		}
		public override Item Clone()
		{
			return new ConsumableItem(name, price, consumableType, value);
		}
	}
}