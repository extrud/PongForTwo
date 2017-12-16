using System;
using UnityEngine;
namespace Pong.Controllers
{
	public enum PaddlePos
	{
		Top,
		Down
	}
	public class PlayerPaddleController:IController
	{
		IControlled cntrld;
		public Camera cam ;
		public PaddlePos pPos;
		int curTouch =-1;
		#region IController implementation

		public void Update ()
		{
			
			if (Input.touchCount == 0)
				return;
			
				
				foreach (Touch t in Input.touches) {
					if (t.phase == TouchPhase.Moved) {
						if (t.position.y > Screen.height / 2 && pPos == PaddlePos.Top) {
							cntrld.MoveToPoint (cam.ScreenToWorldPoint (t.position));
						return;
						}
						if (t.position.y < Screen.height / 2 && pPos == PaddlePos.Down) {
						cntrld.MoveToPoint (cam.ScreenToWorldPoint (t.position));
						return;
						}
					}
				}
		}

		public void SetControlled (IControlled cntrld)
		{
			this.cntrld = cntrld;
		}

		public void RemoveControlled (IControlled cntrld)
		{
			if (this.cntrld == cntrld)
				this.cntrld = null;
		}

		#endregion

		public PlayerPaddleController ()
		{
		}
	}
}

