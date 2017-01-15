using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class OnEditorClickInvokeButton : MonoBehaviour {
	private Button OnClickButton;

	void Awake(){
		OnClickButton = this.gameObject.GetComponent<Button>();
	}

	public void InvokeEvent(){
		if(OnClickButton != null){
			if(OnClickButton.onClick != null){
				OnClickButton.onClick.Invoke();
			}
		}
	}
}
