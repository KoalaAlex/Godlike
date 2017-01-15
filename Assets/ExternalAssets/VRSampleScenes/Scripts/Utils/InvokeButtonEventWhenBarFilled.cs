using UnityEngine;
using System.Collections;
using VRStandardAssets.Utils;
using UnityEngine.UI;

public class InvokeButtonEventWhenBarFilled : MonoBehaviour {
	private SelectionSlider attachedSelectionSlider;
	private Button OnSliderFilledButton;

	void Awake(){
		attachedSelectionSlider = this.gameObject.GetComponent<SelectionSlider>();
		OnSliderFilledButton = this.gameObject.GetComponent<Button>();
	}

	// Use this for initialization
	void InvokeEvent () {
		if(OnSliderFilledButton != null){
			if(OnSliderFilledButton.onClick != null){
				OnSliderFilledButton.onClick.Invoke();
			}
		}
	}

	void OnEnable(){
		attachedSelectionSlider.OnBarFilled += InvokeEvent;
	}

	void OnDisable(){
		attachedSelectionSlider.OnBarFilled -= InvokeEvent;
	}
}
