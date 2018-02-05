using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class script_spider : MonoBehaviour {

	public int nbpoints;
	private float angle;
	private LineRenderer star;

	// Use this for initialization
	void Start () {
		if(nbpoints < 3)
			nbpoints = 3;
		angle = 2 * Mathf.PI/nbpoints;

		star = GetComponent<LineRenderer>();
		star.startWidth = 0.01f;
		star.endWidth = 0.01f;
		star.positionCount = 3 * nbpoints;
		//star.materials [0] = new Material ("Default-Line");

		for (int i = 0; i < 3*nbpoints ; i = i+3) {
			star.SetPosition (i, new Vector3 (0, 0, 0));
			star.SetPosition (i + 1, new Vector3 (Mathf.Cos (angle * i / 3 + Mathf.PI / 2), 
				Mathf.Sin (angle * i / 3 + Mathf.PI / 2), 0));
			star.SetPosition (i+2, new Vector3 (0, 0, 0));
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}