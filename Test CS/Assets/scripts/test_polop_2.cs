using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_polop_2 : MonoBehaviour {

	public string urlducul = "http://192.168.43.35/SampleSQL/database_cs_CheckProfil.php";
	public UILabel lelabel;

	// Use this for initialization
	void Start () {
		lelabel = GameObject.Find ("treslelabel").GetComponent<UILabel>();;
	}

	// Update is called once per frame
	void Update () {

	}

	public void tresLeTest(){
		StartCoroutine (leEnum ());
	}

	private IEnumerator leEnum(){
		WWWForm setform = new WWWForm();
		setform.AddField ("set_Identifiant", "");
		setform.AddField ("set_Mdp", "");

		WWW database = new WWW (urlducul, setform);
		yield return database;
		lelabel.text = database.text;
	}
}
