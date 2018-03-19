using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_polop : MonoBehaviour {

	public string urlducul = "http://192.168.43.35/SampleSQL/database_cs_SetProfil.php";
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
		setform.AddField ("set_Nom", "Dupont");
		setform.AddField ("set_Prenom", "Alfred");
		setform.AddField ("set_Identifiant", "xXx_D4RKS4ZUKE_xXx");
		setform.AddField ("set_Mdp", "0000");

		WWW database = new WWW (urlducul, setform);
		yield return database;
		lelabel.text = database.text;
	}
}
