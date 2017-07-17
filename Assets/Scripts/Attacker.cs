using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class Attacker : MonoBehaviour {

	[Range (-1f, 1.5f)] public float currentSpeed;
	public bool directionReversed = false;	
	
	[Tooltip ("Average number of seconds between appearances")]
	public float seenEverySeconds;
	
	private GameObject currentTarget;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 direction;
		if (directionReversed) {
			direction = Vector3.right;
		}else{
			direction = Vector3.left;
		}
		transform.Translate(direction * currentSpeed * Time.deltaTime);
		if (!currentTarget) {
			GetComponent<Animator>().SetBool("isAttacking", false);
		}
	}
	
	void OnTriggerEnter2D (){
		Debug.Log(name + " trigger enter");
	}
	
	public void setSpeed(float speed){
		currentSpeed = speed;
	}
	
	//is called at the actual attack moment in animation
	public void StrikeCurrentTarget(float damage){
		if (currentTarget) {
			Health health = currentTarget.GetComponent<Health>();
			if (health) {
				Debug.Log(name + " deals " + damage + " damage to " + currentTarget);
				health.DealDamage(damage);
			}
		}
	}
	
	public void Attack(GameObject obj){
		currentTarget = obj;
		
	}
}
