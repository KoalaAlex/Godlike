#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(OnEditorClickInvoke))]
public class OnEditorClickInvokeEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		OnEditorClickInvoke myTarget = (OnEditorClickInvoke)target;

		if(GUILayout.Button("Click to Invoke Events"))
		{
			myTarget.InvokeEvent();
		}
	}
}
#endif