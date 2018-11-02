﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndButton : MonoBehaviour
{

//　ゲーム終了ボタンを押したら実行する
	public void GameEnd() {
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
		}
}