using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class BallNet : NetworkBehaviour {
	Vector2 movedir;
	public float Spd;
	Rigidbody2D rb2d;
	bool On = false;
	SpriteRenderer sr;
	public delegate void OnGoalDeleg(Vector2 pos);
	public event OnGoalDeleg OnGoal;
	// Use this for initialization
	public void RandomizeBall()
	{

		if (!isServer)
			return;
		
		float size = Random.Range(0.3f,1f);
		Color color = Random.ColorHSV();
		float speed = Random.Range(5f,25f);
		Debug.Log (size);
		sr.color = color;
		Spd = speed;
		transform.localScale = new Vector3(size, size, size);

	}
	public void Off()
	{
		On = false;
	}
	IEnumerator RestartEnum()
	{
		Color c = sr.color;

		for (int i = 0; i < 10; i++) 
		{
		yield return new WaitForSeconds (0.1f);
		c.a = 0;
		sr.color = c;
		yield return new WaitForSeconds (0.1f);
		c.a = 1;
		sr.color = c;
		}

		On = true;	
	}
	public void RestartBall()
	{
		Debug.Log ("RestartBall");
		On = false;
		Vector2 randomMove;
		randomMove.x = Random.Range (-0.5f, 0.5f);
		randomMove.y = Random.Range (-1f, 1f);
		randomMove.Normalize ();
		movedir = randomMove;
		StartCoroutine(RestartEnum());
		
	}
	void Start () {
		sr = GetComponent<SpriteRenderer>();
		rb2d = GetComponent<Rigidbody2D> ();
	}

	void Update()
	{
		if (!isServer)
			return;
		if (!On)
			return;

	
		if (Mathf.Abs (transform.position.y) >= 6) {
			On = false;
			Debug.Log ("Goal");
			if (OnGoal != null) {
				OnGoal.Invoke (transform.position);
			}
		}
	}
	// Update is called once per frame
	void FixedUpdate () {

		if (!isServer) {
			return;
		}
		
		if (!On) {
			rb2d.velocity = Vector2.zero;
			return;
		}
		rb2d.velocity = movedir * Spd;
	}
	void  OnCollisionEnter2D(Collision2D coll)
	{

		if (!isServer)
			return;
		
		if (coll.collider.gameObject.tag == "Player") {
			float xparalax = Random.Range (-0.7f, 0.7f);
			movedir.x += xparalax;
			movedir.Normalize ();
		}
	}
	void OnCollisionStay2D(Collision2D coll)
	{

		if (!isServer)
			return;
		
		if ((Mathf.Abs (coll.contacts [0].normal.x) > 0.7f)&& Mathf.Sign(coll.contacts [0].normal.x *-1) == Mathf.Sign(movedir.x)) {
			movedir.x *= -1;
		}
		if ((Mathf.Abs (coll.contacts [0].normal.y) > 0.7f)&& Mathf.Sign(coll.contacts [0].normal.y *-1) == Mathf.Sign(movedir.y)) {
			movedir.y *= -1;
		}
	}
}
