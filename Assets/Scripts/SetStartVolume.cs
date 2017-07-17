using UnityEngine;
using System.Collections;

public class SetStartVolume : MonoBehaviour {

	private MusicPlayer musicManager;

	// Use this for initialization
	void Start () {
		musicManager = GameObject.FindObjectOfType<MusicPlayer>();
		musicManager.ChangeVolume(PlayerPrefsManager.GetMasterVolume());
	}
}
