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
		[SerializeField] private GameObject[] itemPrefabs;
		[SerializeField] private BoxCollider itemSpawnArea;
		[SerializeField] private float itemSpawnInterval;

		private float nextItemSpawnTime;
		
		private void Start()
		{
			StartCoroutine(SpawnNewItem());
		}

		private void Update()
		{
			UpdateInputs();
		}

		private void UpdateInputs()
		{
			if (Input.GetMouseButtonDown(0))
				TryPickUpItem();

			if (Input.GetKeyDown(KeyCode.Space))
				inventoryController.SellAllItemsUpToValue(itemSellMaxValue);

			if (Input.GetKeyDown(KeyCode.U))
				inventoryController.UseAllConsumableItems();
		}

		private IEnumerator SpawnNewItem()
		{
			while (true)
			{
				yield return new WaitForSeconds(itemSpawnInterval);
				var spawnAreaBounds = itemSpawnArea.bounds;
				var obj = ItemsPool.Instance.GetObject(GameTools.GetRandomItem(itemPrefabs), (gameObject) =>
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
			Debug.Log("Picked up " + item.Name + " with price of " + item.Price + " and now have " + inventoryController.ItemsCount + " items");
		}
	}
}