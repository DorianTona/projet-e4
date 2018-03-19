using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

public class test_polop_3 : MonoBehaviour {

	public string urlquestion = "http://192.168.43.35/SampleSQL/database_cs_GetQuestion.php";
	public string urlreponse = "http://192.168.43.35/SampleSQL/database_cs_GetReponse.php";
	private GameObject question_container, text_container;
	private UILabel texte, question, testlabel;
	private UILabel[] choix;
	private string textBuffer;

	// Use this for initialization
	void Start () {
		textBuffer = "";
		question_container = GameObject.Find ("question-container");
		text_container = GameObject.Find ("text-container");

		texte = GameObject.Find ("texte").GetComponent<UILabel>();
		question = GameObject.Find ("question").GetComponent<UILabel>();
		choix = new UILabel[4];
		choix[0] = GameObject.Find ("choix1").GetComponentInChildren<UILabel>();
		choix[1] = GameObject.Find ("choix2").GetComponentInChildren<UILabel>();
		choix[2] = GameObject.Find ("choix3").GetComponentInChildren<UILabel>();
		choix[3] = GameObject.Find ("choix4").GetComponentInChildren<UILabel>();

		testlabel = GameObject.Find ("testlabel").GetComponent<UILabel>();

		question_container.SetActive(false);
		text_container.SetActive(false);
	}

	// Update is called once per frame
	void Update () {}

	public void tresLeTest(){
		StartCoroutine (questionEnum ("1a"));
		testlabel.text = textBuffer;
		string[] lesplit = textBuffer.Split("/:/".ToCharArray());

		if (lesplit [0] == "P") {
			question_container.SetActive(false);
			text_container.SetActive(true);
			testlabel.text =  testlabel.text + "\n" + lesplit.Length;
			texte.text = lesplit [1];
		} else if (lesplit [0] == "Q") {
			question_container.SetActive(true);
			text_container.SetActive(false);

			question.text = lesplit [1];
			for (int i=1; i < lesplit.Length; i+=2) {
				choix [i/2].text = lesplit [1 + i];
			}
		}
	}

	private IEnumerator questionEnum(string idquestion){
		WWWForm setform = new WWWForm();
		setform.AddField ("IdQuestion", idquestion);
		WWW database = new WWW (urlquestion, setform);
		yield return database;
		textBuffer = database.text;
	}

	private IEnumerator reponseEnum(string idreponse){
		WWWForm setform = new WWWForm();
		setform.AddField ("IdQuestion", idreponse);
		WWW database = new WWW (urlreponse, setform);
		yield return database;
		textBuffer = database.text;
	}
}
