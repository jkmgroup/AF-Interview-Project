using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

namespace AFSInterview.Items
{
	[CustomEditor(typeof(ConsumableItemPresenter))]
	public class ConsumableItemPresenterEditor : Editor
	{
		private string[] consumableNames;

		public override void OnInspectorGUI()
		{
			var itemPresenter = target as ConsumableItemPresenter;
			ShowItem(itemPresenter);
		}

		private void ShowItem(ConsumableItemPresenter itemPresenter)
		{
			if (consumableNames == null)
				consumableNames = GameTools.CreateConvertedArray(SceneGlobalData.Instance.gameConfig.consumableDefinitions, (a) => a.name);

			var item = itemPresenter.GetItem(false) as ConsumableItem;
			if (item != null)
			{
				item.Name = GUIExtendTools.TextField("Name", item.Name);
				item.Price = GUIExtendTools.IntField("Price", item.Price);
				item.ConsumableDefinition = GUIExtendTools.PopupField("Consumable", item.ConsumableDefinition, consumableNames);
				item.Value = GUIExtendTools.IntField("Value", item.Value);
			}
			else
				Debug.LogError("ConsumableItemPresenter must have item as ConsumableItem!");
		}
	}
}
