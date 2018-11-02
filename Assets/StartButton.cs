using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{

    //　スタートボタンを押したら実行する
    public void GameStart()
    {
        SceneManager.LoadScene("StageSelect");
    }
}