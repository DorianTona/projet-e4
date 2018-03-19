using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menu_controler : MonoBehaviour {

	[HideInInspector] private GameObject root;
	[SerializeField] private GameObject currentScreen;
	[SerializeField] private GameObject nextScreen;

	// Use this for initialization
	void Start () {
		root = this.transform.parent.gameObject;
		//Debug.Log (root.name);
	}
	
	// Update is called once per frame
	void Update () {}

	//changement d'écran de l'interface
	public void changeScreen() {
		TweenAlpha TA = root.GetComponent<TweenAlpha> ();
		TweenPosition TP = root.GetComponent<TweenPosition> ();
		//Debug.Log (TA.name, TP.name);

		if (TA != null && TP != null) {
			TA.enabled = true;
			TP.enabled = true;
			TA.PlayReverse ();
			TP.PlayReverse ();
			//WaitForFixedUpdate;
			currentScreen.SetActive(false);

			nextScreen.SetActive(true);
			TA.PlayForward ();
			TP.PlayForward ();
			//WaitForFixedUpdate;
			TA.enabled = false;
			TP.enabled = false;
		} else {
			Debug.Log ("tweens non trouvés");
		}
	}
}