using UnityEngine;
using System.Collections;

public class DefenderSpawner : MonoBehaviour {

	public Camera myCamera;
	
	private GameObject defenderParent;
	private StarDisplay starDisplay;
	
	void Start(){
		defenderParent = GameObject.Find("Defenders");
		if (!defenderParent){
			defenderParent = new GameObject("Defenders");
		}
		starDisplay = GameObject.FindObjectOfType<StarDisplay>();
	}
	
	void OnMouseDown(){
		GameObject defender = DefenderButton.selectedDefender;
		if (defender) {
			int defenderCost = defender.GetComponent<Defender>().starCost;
			if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS){
				Vector2 spawnPosition = SnapToGrid(CalculateWorldPointOfMouseClick());
				GameObject spawn = Instantiate(defender, spawnPosition, Quaternion.identity) as GameObject;
				spawn.transform.parent = defenderParent.transform;
			} else {
				Debug.Log("Insufficient stars");
			}
		}
	}
	
	Vector2 CalculateWorldPointOfMouseClick(){
		float mouseX = Input.mousePosition.x;
		float mouseY = Input.mousePosition.y;
		
		Vector3 weirdTriplet = new Vector3(mouseX, mouseY, 10f);
		Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);
		
		return worldPos;
	}
	
	Vector2 SnapToGrid(Vector2 rawWorldPosition){
		float newX = Mathf.RoundToInt(rawWorldPosition.x);
		float newY = Mathf.RoundToInt(rawWorldPosition.y);
		return new Vector2(newX, newY);
	}
}
