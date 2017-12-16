using System;
using UnityEngine;
namespace Pong.Controllers
{
	public interface IControlled
	{
		void MoveToPoint(Vector2 pos);
	}
}

