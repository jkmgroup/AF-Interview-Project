using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AFSInterview.Units
{
    public class UnitBase : MonoBehaviour
    {
		public enum Stage { Wait, TryFoundTargetAndShoot };

		[SerializeField] private bool attributeLight = true;
		[SerializeField] private bool attributeArmored;
		[SerializeField] private bool attributeMechanical;
		[SerializeField] private int health = 100;
		[SerializeField] private int armor = 100;
		[SerializeField] private int attackInterval = 2;
		[SerializeField] private int attackDamage = 20;
		public int AttackDamage => attackDamage;

		private UnitStateMachine unitStateMachine;

		private bool isDead;
		public bool IsDead => isDead;

		private int waitTures;

		public Combat.CombatManager CombatManager
		{
			get;set;
		}

		public void Start()
		{
			unitStateMachine = new UnitStateMachine(this);
			waitTures = attackInterval;
		}

		public bool IsActiveInThisTure()
		{
			if (isDead)
				return false;
			waitTures--;
			if (waitTures<=0)
			{
				waitTures = attackInterval;
				return true;
			}
			return false;
		}

		public void TakeDamage(int damage)
		{
			health -= Mathf.Max(damage - armor, 1);
			if (health <= 0)
			{
				isDead = true;
				unitStateMachine.ChangeState(new DestroyUnitState());
				Debug.Log(name + " was destroy!");
			}
			else
				unitStateMachine.ChangeState(new HitUnitState()); 
		}

		private void DestroyUnit()
		{
			GameObject.Destroy(gameObject);
		}

		public void ChangeStage(Stage stage)
		{
			switch (stage)
			{
				case Stage.TryFoundTargetAndShoot:
					unitStateMachine.ChangeState(new TryFoundTargetAndShotState()); break;
				case Stage.Wait:
					unitStateMachine.ChangeState(new WaitState()); break;
			}
		}

		private void Update()
		{
			unitStateMachine.Update();
		}
	}
}
