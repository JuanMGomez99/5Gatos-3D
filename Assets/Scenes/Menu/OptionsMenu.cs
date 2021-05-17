using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

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