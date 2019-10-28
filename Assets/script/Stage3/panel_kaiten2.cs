using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel_kaiten2 : MonoBehaviour {
   
    [SerializeField]
	public bool turning = false;
    [SerializeField]
    private bool startzero = false;
    [SerializeField]
    private bool startmax = false;
    private float nowtime = 0;
	public int x, y;
	private panelmaster3 pm;
    public void turn()
    {
		pm.turnpanels (y, x);
    }
	// Use this for initialization
	void Start () {
        
		pm = GameObject.FindGameObjectWithTag ("master").GetComponent<panelmaster3> ();

    }

    // Update is called once per frame
    void Update () {
        float minAngle = 0.0F;
        float maxAngle = 180.0F;
        float minAngle2 = 180.0F;
        float maxAngle2 = 0.1F;

       
        if (turning)
        {
            nowtime += Time.deltaTime;
            if (transform.eulerAngles.y == 0 || startzero)
            {
                startzero = true;
                float angle = Mathf.LerpAngle(minAngle, maxAngle, nowtime);
                transform.eulerAngles = new Vector3(0, angle, 0);
                if (transform.eulerAngles.y == 180)
                {
                    turning = false;
                    startzero = false;
                    nowtime = 0;
                }
            }
            else if (transform.eulerAngles.y == 180 || startmax)
            {
                startmax = true;
                float angle = Mathf.LerpAngle(minAngle2, maxAngle2, nowtime);
                transform.eulerAngles = new Vector3(0, angle, 0);
                
                if (transform.eulerAngles.y <= 5)
                {
                    transform.eulerAngles = new Vector3(0, 0, 0);
                }
                if (transform.eulerAngles.y == 0)
                {
                    turning = false;
                    startmax = false;
                    nowtime = 0;
                }
            }
        }
    }
}



