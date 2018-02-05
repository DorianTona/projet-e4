using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_test_polop : MonoBehaviour {

	public string urlducul = "http://192.168.43.35/SampleSQL/database_cs_SetProfil.php";
	public UILabel lelabel;

	// Use this for initialization
	void Start () {
		lelabel = GameObject.Find ("treslelabel").GetComponent<UILabel>();;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void test_polop(){
		StartCoroutine (leEnum ());
	}

	private IEnumerator leEnum(){
		WWWForm setform = new WWWForm();
		setform.AddField ("set_Nom", "benis");
		setform.AddField ("set_Prenom", "benis");
		setform.AddField ("set_Identifiant", "benis");
		setform.AddField ("set_Mdp", "benis");

		WWW database = new WWW (urlducul, setform);
		yield return database;
		lelabel.text = database.text;
	}
}
