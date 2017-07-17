using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarDisplay : MonoBehaviour {

	public enum Status {SUCCESS, FAILURE};

	private Text starText;
	private int stars;

	// Use this for initialization
	void Start () {
		starText = GetComponent<Text>();
		stars = 500;
		UpdateText();
	}
	
	void UpdateText () {
		starText.text = stars.ToString();
	}
	
	
	public void AddStars(int amount){
		stars += amount;
		UpdateText ();
	}
	
	public Status UseStars(int amount) {
		if (stars >= amount) {
			stars -= amount;
			UpdateText ();
			return Status.SUCCESS;
		}
		return Status.FAILURE;
	}
}
