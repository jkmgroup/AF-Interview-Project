using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AFSInterview.Units;
using System;
using TMPro;

namespace AFSInterview.Combat
{
    public class CombatManager : MonoBehaviour
    {
		[SerializeField]
		private GameObject nextTureButton;
		public GameObject NextTureButton => nextTureButton;

		[SerializeField]
		private GameObject gameOverCanvas;
		public GameObject GameOverCanvas => gameOverCanvas;

		[SerializeField]
		private TextMeshProUGUI tureText;

		[SerializeField]
		private List<Army> armies;
		[SerializeField]
		private List<UnitBase> units;

		private int curTure = 1;
		private TureStateMachine tureStateMachine;

		public List<UnitBase> Units => units;


		void Start()
        {
			Validata();
			BulidRandomUnitList();
			tureStateMachine = new TureStateMachine(this);
		}
		
		private void BulidRandomUnitList()
		{
			units = new List<UnitBase>();
			foreach (var army in armies)
			{
				var armyUnits = army.GetComponentsInChildren<UnitBase>();
				foreach (var unit in armyUnits)
					units.Add(unit);
			}
			units = GameTools.MakeRandom(units);
		}

		private void Update()
		{
			tureStateMachine.Update();
		}

		public void NextRound()
		{
			tureStateMachine.ChangeState(new ShootingState());
			curTure++;
			tureText.text = "Ture : " + curTure;
		}

		#region Validata
		private void Validata()
		{
			if (tureText == null)
				GameTools.CriticalError("TureText can be null!");

			if (nextTureButton == null)
				GameTools.CriticalError("NextTureButton can be null!");

			if (gameOverCanvas == null)
				GameTools.CriticalError("GameOverCanvas can be null!");

			if (armies.Count < 2)
				GameTools.CriticalError("You must add at lest 2 armys!");

			for (var i = 0; i < armies.Count; i++)
				if (armies[i] == null)
					GameTools.CriticalError("Armies in index " + i + " are null!");
		}
		#endregion //Validata

	}
}
