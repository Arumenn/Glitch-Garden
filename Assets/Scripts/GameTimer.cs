using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameTimer : MonoBehaviour {

	public static bool isEndOfLevel = false;

	public float levelSeconds = 100;
	
	private Slider slider;
	private AudioSource audioSource;
	private LevelManager levelManager;
	private GameObject winLabel;

	// Use this for initialization
	void Start () {
		
		slider = GetComponent<Slider>();
		audioSource = GetComponent<AudioSource>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		winLabel = GameObject.Find ("WinText");
		winLabel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {	
		slider.value = (Time.timeSinceLevelLoad  / levelSeconds);
		
		if (Time.timeSinceLevelLoad >= levelSeconds && !isEndOfLevel){
			isEndOfLevel = true;
			audioSource.Play();
			winLabel.SetActive(true);
			Invoke ("Win", audioSource.clip.length);
		}
	}
	
	void Win(){
		levelManager.LoadNextLevel();
	}
	
}
