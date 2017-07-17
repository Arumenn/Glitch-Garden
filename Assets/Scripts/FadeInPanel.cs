using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInPanel : MonoBehaviour {

	public float fadeInTime;
	private Image fadePanel;
	private Color currentColor = Color.black;

	// Use this for initialization
	void Start () {
		fadePanel = this.gameObject.GetComponent<Image>();
	}
	
	void Update(){
		if (Time.timeSinceLevelLoad < fadeInTime) {
			float alphaChange = Time.deltaTime / fadeInTime;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;
		}else {
			gameObject.SetActive(false);
		}
	}
}
