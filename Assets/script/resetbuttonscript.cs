using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class resetbuttonscript : MonoBehaviour {

	public void OnClick() {
		SceneManager.LoadScene("Stage1");
	}
}