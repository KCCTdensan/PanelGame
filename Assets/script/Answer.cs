using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Answer : MonoBehaviour {
	private bool[,] AnswerStates = new bool [3, 3];
	private bool[,] CurrentStates = new bool [3, 3];

	public string[] textMessage; //テキストの加工前の一行を入れる変数
	private int rowLength; //テキスト内の行数を取得する変数
	private int columnLength; //テキスト内の列数を取得する変数

	// Use this for initialization
	void Start () {
		TextAsset textasset = new TextAsset(); //テキストファイルのデータを取得するインスタンスを作成
		textasset = Resources.Load("test", typeof(TextAsset) )as TextAsset; //Resourcesフォルダから対象テキストを取得
		string TextLines = textasset.text; //テキスト全体をstring型で入れる変数を用意して入れる

		//Splitで一行づつを代入した1次配列を作成
		textMessage = TextLines.Replace("\r\n", "\n").Split('\n'); //

		//行数と列数を取得
		columnLength = textMessage[0].Split(',').Length;
		rowLength = textMessage.Length;

		for(int i = 0; i < rowLength; i++)
		{
			string[] tempWords = textMessage[i].Split(','); //textMessageをカンマごとに分けたものを一時的にtempWordsに代入

			for (int n = 0; n < columnLength; n++)
			{
				Debug.Log (tempWords [n]);
				if (tempWords [n] == "0")
					AnswerStates [i, n] = false;
				else if (tempWords [n] == "1")
					AnswerStates [i, n] = true;
				Debug.Log(AnswerStates[i, n]);
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
