using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

public class script_account : MonoBehaviour {

	string photoPath = "";
	string nom = "";
	string prenom = "";
	string id = "";
	string mdp = "";

	UILabel filenameLabel;
	UILabel lb_nom, lb_prenom, lb_id, lb_mdp1, lb_mdp2;
	UILabel lb_error;

	// Use this for initialization
	void Start () {
		filenameLabel = GameObject.Find ("choose photo/filename").GetComponent<UILabel>();
		lb_nom = GameObject.Find ("input_nom/Label").GetComponent<UILabel>();
		lb_prenom = GameObject.Find ("input_prenom/Label").GetComponent<UILabel>();
		lb_id = GameObject.Find ("input_id/Label").GetComponent<UILabel>();
		lb_mdp1 = GameObject.Find ("input_mdp/Label").GetComponent<UILabel>();
		lb_mdp2 = GameObject.Find ("input_mdp_confirm/Label").GetComponent<UILabel>();
		lb_error = GameObject.Find ("lb_error").GetComponent<UILabel>();
	}
	
	// Update is called once per frame
	void Update () {
		if (photoPath == "")
			filenameLabel.text = "Choisissez une photo";
		else
			filenameLabel.text = photoPath;
	}

	public void getProfilePicture()
	{
		string path = EditorUtility.OpenFilePanel("Sélectionnez une image de profil", "", "png, jpg, jpeg, bmp");
		if (path.Length != 0)
		{
			photoPath = path;
			//var fileContent = File.ReadAllBytes(path);
			//texture.LoadImage(fileContent);
		}
	}

	public void confirm()
	{
		if (lb_nom.text != "Nom" && lb_prenom.text != "Prenom" && lb_id.text != "Identifiant" &&
			lb_mdp1.text.Length > 0 && lb_mdp2.text.Length > 0) {
			if (lb_mdp1.text == lb_mdp2.text) {
				if (lb_mdp1.text.Length >= 8) {
					//écran suivant
					lb_error.text = "Succès de la création du compte";

					nom = lb_nom.text;
					prenom = lb_prenom.text;
					id = lb_id.text;
					mdp = lb_mdp1.text;


				} else {
					lb_error.text = "Le mot de passe doit faire au moins 8 caractères";
				}
			} else {
				lb_error.text = "Mots de passe non identiques";
			}
		} else {
			lb_error.text = "Veuillez remplir tous les champs";
		}
	}

}