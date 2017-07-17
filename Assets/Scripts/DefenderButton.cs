using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DefenderButton : MonoBehaviour {

	public GameObject defenderPrefab;
	public static GameObject selectedDefender;

	private DefenderButton[] buttonArray;
	private Text costText;

	// Use this for initialization
	void Start () {
		buttonArray = GameObject.FindObjectsOfType<DefenderButton>();
		costText = GetComponentInChildren<Text>();
		if (!costText){ Debug.LogWarning(name + " has no cost text"); }
		
		costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnMouseDown(){
		foreach (DefenderButton b in buttonArray){
			b.GetComponent<SpriteRenderer>().color = Color.black;
		}
		GetComponent<SpriteRenderer>().color = Color.white;
		selectedDefender = defenderPrefab;
	}
}
