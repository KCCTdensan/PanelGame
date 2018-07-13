using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI; 

public class scoreScript : MonoBehaviour {

	//点数を格納する変数
	public int score = 0;

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text = "１位" + score.ToString() + "点";
	}
}