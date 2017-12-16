using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIManager : MonoBehaviour {
	public GameManager Gm;
	public GameObject MainButtonStack;
	public GameObject ScoreStack;
	public Text VictoryLable;

	public void OnEndGame(string name)
	{
		VictoryLable.gameObject.SetActive (true);
		MainButtonStack.SetActive (true);
		VictoryLable.text = name+" Victory";		
	}
	public void StartLocalGame(int Scorecount)
	{
		Gm.StartGame (Scorecount);
		MainButtonStack.SetActive (false);
		ScoreStack.SetActive (false);
		VictoryLable.gameObject.SetActive (false);
	}
	void Start()
	{
		Gm.OnEndOfGame += OnEndGame;
		MainButtonStack.SetActive (true);
		ScoreStack.SetActive (false);
		VictoryLable.gameObject.SetActive (false);
	}
	public void SelectScore()
	{
		MainButtonStack.SetActive (false);
		ScoreStack.SetActive (true);
	}
}
