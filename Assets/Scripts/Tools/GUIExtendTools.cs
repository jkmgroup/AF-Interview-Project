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

		static public int SliderInt(string lable, int value, int min, int max)
		{
			GUILayout.BeginHorizontal();
			GUILayout.Label(lable);
			var rezult = (int)EditorGUILayout.Slider((float)value, (float)min, (float)max);
			GUILayout.EndHorizontal();
			return rezult;
		}

		public static bool Toggle(string lable, bool value, bool enable)
		{
			var oldEnabled = GUI.enabled;
			GUI.enabled = enable;
			GUILayout.BeginHorizontal();
			GUILayout.Label(lable);
			var rezult = GUILayout.Toggle(value, "");
			GUILayout.EndHorizontal();
			GUI.enabled = oldEnabled;
			return rezult;
		}
	}
}