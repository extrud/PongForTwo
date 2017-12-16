using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pong.Controllers;
public class Paddle : MonoBehaviour,IControlled  {
	public float Spd;
	#region IControlled implementation
	public void MoveToPoint (Vector2 pos)
	{
		Vector2 curpos = transform.position;
		float move = Mathf.Sign (pos.x -curpos.x);
		if (Mathf.Abs (pos.x - curpos.x) < Spd * Time.deltaTime) {
			transform.position = new Vector2(pos.x,transform.position.y);
		}
		else
		transform.Translate (new Vector3 (move * (Spd * Time.deltaTime), 0, 0));

	}
	#endregion

	}
