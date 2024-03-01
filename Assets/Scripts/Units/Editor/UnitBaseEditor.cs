using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace AFSInterview.Units
{
	[CustomEditor(typeof(UnitBase))]
	public class UnitBaseEditor : Editor
	{
		public override void OnInspectorGUI()
		{
			var unit = target as UnitBase;

			var numPositive = 0;
			numPositive += unit.AttributeLight ? 1 : 0;
			numPositive += unit.AttributeArmored? 1 : 0;
			numPositive += unit.AttributeMechanical ? 1 : 0;

			unit.AttributeLight = GUIExtendTools.Toggle("AttributeLight", unit.AttributeLight, !unit.AttributeLight || numPositive != 1);
			unit.AttributeArmored = GUIExtendTools.Toggle("AttributeArmored", unit.AttributeArmored, !unit.AttributeArmored || numPositive != 1);
			unit.AttributeMechanical = GUIExtendTools.Toggle("AttributeMechanical", unit.AttributeMechanical, !unit.AttributeMechanical || numPositive != 1);

			unit.Health = GUIExtendTools.SliderInt("Health", unit.Health, 10, 200);
			unit.Armor = GUIExtendTools.SliderInt("Armor", unit.Armor, 0, 100);
			unit.AttackInterval = GUIExtendTools.SliderInt("AttackInterval", unit.AttackInterval, 1, 15);
			unit.AttackDamage = GUIExtendTools.SliderInt("AttackDamage", unit.AttackDamage, 1, 100);
		}
	}
}
