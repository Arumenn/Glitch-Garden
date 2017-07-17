using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public GameObject[] attackerPrefabArray;
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject thisAttacker in attackerPrefabArray){
			if (IsTimeToSpawn(thisAttacker)){
				Spawn (thisAttacker);
			}
		}
	}
	
	void OnDrawGizmos(){
		Gizmos.color = new Color(255f, 0, 0, 0.3f);
		Gizmos.DrawCube(transform.position, new Vector3(1,1,1));
	}
	
	bool IsTimeToSpawn(GameObject attackerGameObject){
		Attacker attacker = attackerGameObject.GetComponent<Attacker>();
		float meanSpawnDelay = attacker.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;
		
		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning("Spawn rate capped by frame rate");
		}
		
		float threshold = (spawnsPerSecond * Time.deltaTime) / 5;
		return (Random.value < threshold);
	}
	
	void Spawn(GameObject myGameObject){
		GameObject spawn = Instantiate(myGameObject) as GameObject;
		spawn.transform.parent = transform;
		spawn.transform.position = transform.position;
	}
}
