using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelmaster : MonoBehaviour {
		
		public GameObject panel;
	    private bool nowturn;
		private GameObject[,] panels = new GameObject[3, 3];
		private panel_kaiten[,] pk = new panel_kaiten[3, 3];

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
				pk [a - 1, b - 1]= aaa.GetComponent<panel_kaiten>();
				pk [a-1,b-1].x = a - 1;
				pk [a-1,b-1].y = b - 1;
				}
			}
		}

	public void turnpanels(int x,int y)
	{
		if (nowturn) {
			return;
		}
		pk [y, x].turning = true;
		if (y + 1 < 3)pk [y + 1, x].turning = true;
		if (y - 1 >= 0)pk [y - 1, x].turning = true;
		if (x + 1 < 3)pk [y, x + 1].turning = true;
		if (x - 1 >= 0)pk [y, x - 1].turning = true;
	}
		// Update is called once per frame
		void Update () {
		int x=0;
		int y = 0;
		for(x=0;x<3;x++){
			for (y = 0; y < 3; y++) {
				if (pk [y, x].turning) {
					nowturn = true;
					break;
				}
			}
			if (y != 3) {
				break;
			}
		}

		if (x == 3 && y == 3) {
			nowturn = false;
		}

	}
}