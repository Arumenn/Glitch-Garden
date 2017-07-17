using UnityEngine;
using System.Collections;

public class Shooter : MonoBehaviour {

	public GameObject projectile;
	public GameObject gun;
	
	private GameObject projectileParent;
	private Animator animator;
	private Spawner myLaneSpawner;
	
	void Start(){
		projectileParent = GameObject.Find("Projectiles");
		if (!projectileParent){
			projectileParent = new GameObject("Projectiles");
		}
		
		animator = GameObject.FindObjectOfType<Animator>();
		
		SetMyLaneSpawner();
	}
	
	void Update(){
		animator.SetBool("isAttacking", IsAttackerAheadInLane());
	}
	
	void SetMyLaneSpawner(){
		foreach (Spawner s in GameObject.FindObjectsOfType<Spawner>()){
			if (s.transform.position.y == transform.position.y) {
				myLaneSpawner = s;
				return;
			}
		}
		
		Debug.LogError(name + " can't find a spawner in lane");
	}
	
	bool IsAttackerAheadInLane(){
		if (myLaneSpawner.transform.childCount > 0) {
			foreach (Transform attacker in myLaneSpawner.transform){
				if (attacker.transform.position.x >= transform.position.x){
					return true;
				}
			}
		}
		
		
		return false;
	}
	
	private void Fire(){
		GameObject newProjectile = Instantiate (projectile) as GameObject;
		newProjectile.transform.parent = projectileParent.transform;
		newProjectile.transform.position = gun.transform.position;
		
	}
}
