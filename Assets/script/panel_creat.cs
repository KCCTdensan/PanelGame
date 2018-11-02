using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel_creat : MonoBehaviour {
    public GameObject panel;

    private GameObject[,] panels = new GameObject[3, 3];

    int a,b;
	// Use this for initialization
	void Start () {
        for (a = 1; a < 4; a++)
        {
            for (b = 1; b < 4; b++)
            {
                var aaa = Instantiate(panel);

                aaa.transform.position = new Vector3(a * 10 - 40, b*10-40, 81);
                panels[a - 1, b - 1] = aaa;

            }
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
