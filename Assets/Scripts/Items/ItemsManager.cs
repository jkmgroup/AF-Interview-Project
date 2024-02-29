namespace AFSInterview.Items
{
	using System;
	using System.Collections;
	using TMPro;
	using UnityEngine;

	public class ItemsManager : MonoBehaviour
	{
		[SerializeField] private InventoryController inventoryController;
		[SerializeField] private int itemSellMaxValue;
		[SerializeField] private Transform itemSpawnParent;
		[SerializeField] private GameObject itemPrefab;
		[SerializeField] private BoxCollider itemSpawnArea;
		[SerializeField] private float itemSpawnInterval;

		private float nextItemSpawnTime;
		private TextMeshProUGUI moneyText;
		
		#region Validata
		private void Validata()
		{
			if (!moneyText)
				GameTools.CriticalError("No object TextMeshProUGUI in scene. To show money info! ");
		}
		#endregion //validata

		private void Start()
		{
			moneyText = FindObjectOfType<TextMeshProUGUI>();
			Validata();
			StartCoroutine(SpawnNewItem());
		}

		private void Update()
		{
			
			if (Input.GetMouseButtonDown(0))
				TryPickUpItem();
			
			if (Input.GetKeyDown(KeyCode.Space))
				inventoryController.SellAllItemsUpToValue(itemSellMaxValue);

			moneyText.text = "Money: " + inventoryController.Money;
		}

		private IEnumerator SpawnNewItem()
		{
			while (true)
			{
				yield return new WaitForSeconds(itemSpawnInterval);
				var spawnAreaBounds = itemSpawnArea.bounds;
				var obj = ItemsPool.Instance.GetObject(itemPrefab, (gameObject) =>
				{
					gameObject.transform.position = GameTools.CreateRandVectorXZ(spawnAreaBounds.min, spawnAreaBounds.max, 0.0f);
					gameObject.transform.rotation = Quaternion.identity;
					gameObject.transform.parent = itemSpawnParent;
				});
			}
		}

		private void TryPickUpItem()
		{
			var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			var layerMask = LayerMask.GetMask("Item");
			if (!Physics.Raycast(ray, out var hit, 100f, layerMask) || !hit.collider.TryGetComponent<IItemHolder>(out var itemHolder))
				return;
			
			var item = itemHolder.GetItem(true);
            inventoryController.AddItem(item);
            Debug.Log("Picked up " + item.Name + " with value of " + item.Value + " and now have " + inventoryController.ItemsCount + " items");
		}
	}
}