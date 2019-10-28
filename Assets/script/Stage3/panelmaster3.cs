using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panelmaster3 : MonoBehaviour
{
		
	public GameObject panel;
  public GameObject timer;
  public GameObject Cleartext;
  private Timer time;
	private bool nowturn;
	private GameObject[,] panels = new GameObject[4, 4];
	private bool[,] States = new bool[4, 4];
	private panel_kaiten2[,] pk = new panel_kaiten2[4, 4];
	Answer3 ans;


	int a, b;
	// Use this for initialization
	void Start ()
	{
		ans = gameObject.AddComponent<Answer3>();
    time = timer.GetComponent<Timer>();
		for (a = 0; a < 4; a++) {
			for (b = 0; b < 4; b++) {
				var aaa = Instantiate (panel);
				    
				aaa.transform.position = new Vector3 (a * 10 - 55, b * 10 - 40, 82);
				panels [a, b] = aaa;
				pk [a, b] = aaa.GetComponent<panel_kaiten2> ();
				pk [a, b].x = a;
				pk [a, b].y = b;
				States [a, b] = false;
				//Debug.Log (States [0, 0]);
			}
		}

	}

	public void turnpanels (int x, int y)
	{
		if (nowturn) {
			return;
		}
		pk [y, x].turning = true;
		if (y + 1 < 4)
			pk [y + 1, x].turning = true;
		if (y - 1 >= 0)
			pk [y - 1, x].turning = true;
		if (x + 1 < 4)
			pk [y, x + 1].turning = true;
		if (x - 1 >= 0)
			pk [y, x - 1].turning = true;

		States [y, x] = !States [y, x];
		if (y + 1 < 4)
			States [y + 1, x] = !States [y + 1, x];
		if (y - 1 >= 0)
			States [y - 1, x] = !States [y - 1, x];
		if (x + 1 < 4)
			States [y, x + 1] = !States [y, x + 1];
		if (x - 1 >= 0)
			States [y, x - 1] = !States [y, x - 1];
		Debug.Log (ans.check (States));
		if (ans.check (States)) {
      Cleartext.SetActive(true);
      time.timestop = true;
      Invoke("DelayMethod", 3.5f);
		}
	}

  void DelayMethod()
  {
    SceneManager.LoadScene("StageSelect");
  }

	// Update is called once per frame
	void Update ()
	{
		int x = 0;
		int y = 0;
		for (x = 0; x < 4; x++) {
			for (y = 0; y < 4; y++) {
				if (pk [y, x].turning) {
					nowturn = true;
					break;
				}
			}
			if (y != 4) {
				break;
			}
		}

		if (x == 4&& y == 4) {
			nowturn = false;
		}
	}
}