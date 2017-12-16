using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong.Controllers;

public class GameManager : MonoBehaviour {
	PlayerPaddleController Ppc;
	PlayerPaddleController Ppc2;
	public GameObject RightWall;
	public GameObject LeftWall;
	public Paddle Pdl;
	public Paddle Pdl2;
	public int ScoreP1;
	public int ScoreP2;
	public int MaxScore;
	public Camera cam;
	public Ball BallObj;
	public bool GameOn=true;
	public delegate void EndOfGameDeleg(string VinerName);
	public event EndOfGameDeleg OnEndOfGame;
	// Use this for initialization
	public void StartGame(int scoreCount)
	{
		GameOn = true;
		BallObj.OnGoal += OnGoal;
		Ppc = new PlayerPaddleController ();
		Ppc2 = new PlayerPaddleController ();
		ScoreP1 = 0;
		ScoreP2 = 0;
		MaxScore = scoreCount;
		Ppc2.pPos = PaddlePos.Top;
		Ppc.pPos = PaddlePos.Down;
		Ppc2.cam = cam;
		Ppc.cam = cam;
		Ppc.SetControlled (Pdl);
		Ppc2.SetControlled (Pdl2);
		BallObj.RandomizeBall ();
		LeftWall.transform.position = new Vector2 (cam.orthographicSize * -cam.aspect,0);
		RightWall.transform.position = new Vector3 (cam.orthographicSize * cam.aspect,0);
		BallObj.RestartBall ();
	}
	void OnGoal (Vector2 pos)
	{
		Debug.Log ("Goal");
		if (pos.y > 0) {
			ScoreP1++;
		} else {
			ScoreP2++;
		}
		CheckScore ();
		if (!GameOn)
			return;
		
		BallObj.transform.position = Vector2.zero;
		BallObj.RestartBall ();

	}
	void CheckScore()
	{
		if (ScoreP1 >= MaxScore) {
			if (OnEndOfGame != null)
				OnEndOfGame.Invoke ("Player1");
			GameOn = false;
			BallObj.Off ();
		}
		if (ScoreP2 >= MaxScore) {
			if (OnEndOfGame != null)
				OnEndOfGame.Invoke ("Player2");
			GameOn = false;
			BallObj.Off ();
		}
	}

	void Start () {

		GameOn = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (!GameOn)
			return;
		Ppc.Update ();
		Ppc2.Update ();
	}
}
