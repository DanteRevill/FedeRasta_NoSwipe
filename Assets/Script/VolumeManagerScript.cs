using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using System;


public class VolumeManagerScript : MonoBehaviour {

	public static readonly float exponent = Mathf.Log (25, 4);

	public static float volumeMusic = 100;
	public static float volumeSound = 100;

	public AudioMixer mixer;
	public Slider sliderVolumeMusic = null;
	public Slider sliderVolumeSound = null;

	void OnEnable () {
		sliderVolumeMusic.value = volumeMusic;
	}

	public float VolumeMusic {
		get { return volumeMusic; }
		set {
			if (value != volumeMusic) {
				volumeMusic = value;
				float v = getDBVolume (value * 0.01f);
				mixer.SetFloat ("VolumeMusic", v );
			}
		}
	}

	public float VolumeSound
	{
		get { return volumeSound; }
		set
		{
			if (value != volumeSound)
			{
				volumeSound = value;
				float v = getDBVolume(value * 0.01f);
				mixer.SetFloat("VolumeSound", v);
			}
		}
	}

	public static float getDBVolume (float percVolume) {
		if (percVolume < 1)
			return -80f * Mathf.Pow (1 - percVolume, exponent);
		return 0;
	}
}

