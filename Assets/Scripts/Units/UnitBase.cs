using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Units
{
    public class UnitBase : MonoBehaviour
    {
		[SerializeField]
		protected bool attributeLight = true;
		[SerializeField]
		protected bool attributeArmored;
		[SerializeField]
		protected bool attributeMechanical;
		[SerializeField]
		protected int health = 100;
		[SerializeField]
		protected int armor = 100;
		[SerializeField]
		protected int attackInterval = 2;
		[SerializeField]
		protected int attackDamage = 20;

		public void TakeDamage()
		{
			health -= Mathf.Max(attackDamage - armor, 1);
			if (health <= 0)
				DestroyUnit();
		}

		private void DestroyUnit()
		{
			GameObject.Destroy(gameObject);
		}
	}
}
