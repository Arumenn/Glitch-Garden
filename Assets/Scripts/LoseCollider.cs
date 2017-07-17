using UnityEngine;
using System.Collections;

public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;
	
	void Start(){
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		if (!levelManager){
			Debug.LogError("We need a LevelManager");
		}
	}

	void OnTriggerEnter2D(Collider2D collider){
		if (!GameTimer.isEndOfLevel) {
			if (collider.GetComponent<Attacker>()){
				levelManager.LoadLevel("03b Lose");
			}
		}
	}
}
