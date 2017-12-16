using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
public class MoveSync : NetworkBehaviour {
	[SyncVar]
	public Vector2 syncPos;
	[SerializeField] Transform myTransform;
	[SerializeField] float lerpRate = 15;
	void FixedUpdate()
	{
		if(isServer)
			syncPos = transform.position;
		if(isLocalPlayer)
		LerpPosition ();

	}
	void LerpPosition()
	{
		if (isLocalPlayer) {
			myTransform.position = Vector2.Lerp (myTransform.position, syncPos, Time.deltaTime * lerpRate);
		}
	}
}

