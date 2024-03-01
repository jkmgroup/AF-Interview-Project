namespace AFSInterview.Items
{
	using System;
	using System.Collections.Generic;
	using TMPro;
	using UnityEngine;

	public class InventoryController : MonoBehaviour
	{
		[System.Serializable]
		public class Consumable
		{
			public GameConfig.ConsumableDefinition consumableType;
			public int curValue;
			public TextMeshProUGUI uiText;

			public Consumable(GameConfig.ConsumableDefinition consumableType)
			{
				this.consumableType = consumableType;
				curValue = 0;
				uiText = null;
			}
			public void UpdateUI()
			{
				uiText.text = consumableType.name + " : " + curValue;
			}

		}

		[SerializeField] private List<Item> items;
		[SerializeField] private int MoneyAtStart = 280;

		private List<Consumable> consumables;
		private int moneyId = -1;

		public int Money => consumables[moneyId].curValue;			
		public int ItemsCount => items.Count;

		private void Awake()
		{
			InitConsumables();
			Validata();
		}

		private void InitConsumables()
		{
			moneyId = -1;
			var textObjects = GameTools.ArrayToList(FindObjectsOfType<TextMeshProUGUI>());
			var gameConfig = SceneGlobalData.Instance.gameConfig;
			consumables = new List<Consumable>();
			for (var i = 0; i < gameConfig.consumableDefinitions.Length; i++)
			{
				consumables.Add(new Consumable(gameConfig.consumableDefinitions[i]));
				var foundIndex = textObjects.FindIndex((a) => a.name == gameConfig.consumableDefinitions[i].name);
				if (foundIndex > -1)
				{
					consumables[i].uiText = textObjects[foundIndex];
					textObjects.RemoveAt(foundIndex);
				}
			}
			moneyId = consumables.FindIndex((a) => a.consumableType.name == "Money");
			if (moneyId > -1)
			{
				consumables[moneyId].curValue = MoneyAtStart;
				consumables[moneyId].UpdateUI();
			}
		}

		public void SellAllItemsUpToValue(int maxPrice)
		{
			for (var i = items.Count - 1; i >= 0; i--)
			{
				var itemPrice = items[i].Price;
				if (itemPrice > maxPrice)
					continue;

				consumables[moneyId].curValue += itemPrice;
				items.RemoveAt(i);
			}
			consumables[moneyId].UpdateUI();
		}

		public void AddItem(Item item)
		{
			items.Add(item);
		}

		public void AddConsumableValue(int consumableType, int value)
		{
			if (!GameTools.InRange(consumables, consumableType))
				return;
			consumables[consumableType].curValue = Mathf.Min(consumables[consumableType].curValue + value, consumables[consumableType].consumableType.maxValue);
			consumables[consumableType].UpdateUI();
		}

		public void UseAllConsumableItems()
		{
			for (var i = items.Count - 1; i >= 0; i--)
			{
				if (items[i] is ConsumableItem)
				{
					items[i].Use(this);
					items.RemoveAt(i);
				}
			}
		}

		#region Validata
		private void Validata()
		{
			if (moneyId == -1)
				GameTools.CriticalError("Please add Money to consumableTypes in " + SceneGlobalData.Instance.gameConfig.name);			
		}
		#endregion //Validata
	}
}