using System;

namespace Pong.Controllers
{
	public interface IController
	{
		void Update();
		void SetControlled (IControlled cntrld);
		void RemoveControlled (IControlled cntrld);
	}
}

