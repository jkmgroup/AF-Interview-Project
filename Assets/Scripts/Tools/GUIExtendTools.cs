using UnityEditor;
using UnityEngine;

namespace AFSInterview
{
	public class GUIExtendTools
	{
		static public string TextField(string lable, string text)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(lable);
			var rezult = GUILayout.TextField(text);
			GUILayout.EndHorizontal();
			return rezult;
		}

		static public int IntField(string lable, int value)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(lable);
			var rezult = EditorGUILayout.IntField(value);
			GUILayout.EndHorizontal();
			return rezult;
		}

		static public int PopupField(string lable, int selected, string[] values)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(lable);
			var rezult = EditorGUILayout.Popup(selected, values);
			GUILayout.EndHorizontal();
			return rezult;
		}
	}
}