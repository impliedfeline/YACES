using System;
using YACES;
using Microsoft.Xna.Framework;

namespace Pong
{
	public class VelocityComponent : YACES.GameComponent
	{
		public Vector2 Velocity { get; set; }

		public VelocityComponent (Vector2 velocity)
		{
			Velocity = velocity;
		}
	}
}

