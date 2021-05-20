using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

/*
    MainMenu class that contains the behaivour for the options menu
*/
public class OptionsMenu : MonoBehaviour
{
	public AudioMixer mixer;

	public void VolumeChanged() {
		GameObject go = transform.Find("VolumeSlider").gameObject;
	   	float volume = go.GetComponent<Slider>().value;
	    	mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
	}

	public Dropdown resSelector;
	void Start () {
		GameObject go = transform.Find("VolumeSlider").gameObject;
		go.GetComponent<Slider>().value = 0.5F;
		mixer.SetFloat("MusicVolume", Mathf.Log10(0.5F) * 20);
		
		if (Screen.fullScreen == false)
		{
			resSelector.value = 1;
		}

		resSelector.onValueChanged.AddListener(delegate {
			ResSelected(resSelector);
		});
	}
	private void ResSelected(Dropdown selector) {
		ScreenResolution(selector.value);
	}
	
	public void ScreenResolution(int option) {
		Debug.Log(option);
		if (option == 0) {
			Screen.fullScreen = true;
		} else if (option == 1) {
			Screen.SetResolution(720, 480, false);
		}
	}
	
}
