using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class panelmaster6 : MonoBehaviour
{



    public GameObject panel;
    public GameObject timer;
    public GameObject Cleartext;
    private Timer time;
    private bool nowturn;
    private GameObject[,] panels = new GameObject[5, 5];
    private bool[,] States = new bool[5, 5];
    private panel_kaiten5[,] pk = new panel_kaiten5[5, 5];
    Answer6 ans;


    int a, b;
    // Use this for initialization
    void Start()
    {
        ans = gameObject.AddComponent<Answer6>();
        time = timer.GetComponent<Timer>();
        for (a = 0; a < 5; a++)
        {
            for (b = 0; b < 5; b++)
            {
                var aaa = Instantiate(panel);

                aaa.transform.position = new Vector3(a * 10 - 55, b * 10 - 45, 82);
                panels[a, b] = aaa;
                pk[a, b] = aaa.GetComponent<panel_kaiten5>();
                pk[a, b].x = a;
                pk[a, b].y = b;
                States[a, b] = false;
                //Debug.Log (States [0, 0]);
            }
        }

    }

    public void turnpanels(int x, int y)
    {
        if (nowturn)
        {
            return;
        }
        pk[y, x].turning = true;
        if (y + 1 < 5)
            pk[y + 1, x].turning = true;
        if (y - 1 >= 0)
            pk[y - 1, x].turning = true;
        if (x + 1 < 5)
            pk[y, x + 1].turning = true;
        if (x - 1 >= 0)
            pk[y, x - 1].turning = true;

        States[y, x] = !States[y, x];
        if (y + 1 < 5)
            States[y + 1, x] = !States[y + 1, x];
        if (y - 1 >= 0)
            States[y - 1, x] = !States[y - 1, x];
        if (x + 1 < 5)
            States[y, x + 1] = !States[y, x + 1];
        if (x - 1 >= 0)
            States[y, x - 1] = !States[y, x - 1];
        Debug.Log(ans.check(States));
        if (ans.check(States))
        {
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
    void Update()
    {
        int x = 0;
        int y = 0;
        for (x = 0; x < 5; x++)
        {
            for (y = 0; y < 5; y++)
            {
                if (pk[y, x].turning)
                {
                    nowturn = true;
                    break;
                }
            }
            if (y != 5)
            {
                break;
            }
        }

        if (x == 5 && y == 5)
        {
            nowturn = false;
        }
    }
}