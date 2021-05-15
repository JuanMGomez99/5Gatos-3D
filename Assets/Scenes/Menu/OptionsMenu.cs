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
	
}
