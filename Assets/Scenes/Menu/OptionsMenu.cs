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
	private Resolution[] resolutions;
	private int w;
	private int h;
	public void VolumeChanged() {
		GameObject go = transform.Find("VolumeSlider").gameObject;
	   	float volume = go.GetComponent<Slider>().value;
	    	mixer.SetFloat("MusicVolume", Mathf.Log10(volume) * 20);
	}

	public Dropdown resSelector;
	void Start () {
		GameObject go = transform.Find("VolumeSlider").gameObject;
		go.GetComponent<Slider>().value = 1F;
		mixer.SetFloat("MusicVolume", Mathf.Log10(1F) * 20);
		resolutions = Screen.resolutions;
		resSelector.options.Clear();
		resSelector.options.Add(new Dropdown.OptionData("FullScreen"));
		foreach (var res in resolutions) {
			string option = res.width + "x" + res.height;
			resSelector.options.Add(new Dropdown.OptionData(option));
		}
		
		resSelector.value = 0;
		w = Screen.width;
		h = Screen.height;

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
			Screen.SetResolution(w, h, true);
		} else {
			var resolution = resolutions[option - 1];
			Screen.SetResolution(resolution.width, resolution.height, false);
		}
	}
	
}
