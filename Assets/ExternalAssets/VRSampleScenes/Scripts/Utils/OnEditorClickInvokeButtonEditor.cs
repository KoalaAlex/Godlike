#if UNITY_EDITOR
using UnityEngine;
using System.Collections;
using UnityEditor;

[CustomEditor(typeof(OnEditorClickInvokeButton))]
public class OnEditorClickInvokeButtonEditor : Editor {

	public override void OnInspectorGUI() {
		DrawDefaultInspector();

		OnEditorClickInvokeButton myTarget = (OnEditorClickInvokeButton)target;

		if(GUILayout.Button("Click to Invoke Button-Event"))
		{
			myTarget.InvokeEvent();
		}
	}
}
#endif