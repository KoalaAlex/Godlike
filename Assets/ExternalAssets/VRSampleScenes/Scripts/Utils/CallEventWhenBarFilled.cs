using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.Events;

public class CallEventWhenBarFilled : MonoBehaviour {
	private SelectionSlider attachedSelectionSlider;
	public UnityEvent OnSliderFilled;

	void Awake(){
		attachedSelectionSlider = this.gameObject.GetComponent<SelectionSlider>();
	}

	// Use this for initialization
	void InvokeEvent () {
		if(OnSliderFilled != null){
			OnSliderFilled.Invoke();
		}
	}

	void OnEnable(){
		attachedSelectionSlider.OnBarFilled += InvokeEvent;
	}

	void OnDisable(){
		attachedSelectionSlider.OnBarFilled -= InvokeEvent;
	}
}
