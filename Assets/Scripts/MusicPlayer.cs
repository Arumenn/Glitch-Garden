using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

		
	public AudioClip[] levelMusicChangeArray;
	
	private AudioSource audioSource;
	
	void Awake(){
		DontDestroyOnLoad(gameObject);
	}
	
	void Start(){
		audioSource = GetComponent<AudioSource>();
		OnLevelWasLoaded(0);
	}
	
	void OnLevelWasLoaded(int level){
		AudioClip thisLevelMusic = levelMusicChangeArray[level];
		Debug.Log ("Play on level " + level);
		
		if (thisLevelMusic) {
			audioSource.clip = thisLevelMusic;
			audioSource.loop = (level > 0);
			audioSource.Play();
		}else{ 
			audioSource.Pause();
		}
	}
	
	public void ChangeVolume(float volume){
		audioSource.volume = volume;
	}
}
