using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class OnEditorClickInvoke : MonoBehaviour {
	public UnityEvent OnButtonClick;

	public void InvokeEvent(){
		if(OnButtonClick != null){
			OnButtonClick.Invoke();
		}
	}
}
