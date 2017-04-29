using System;
using Microsoft.Xna.Framework;

namespace YACES
{
	public class Hitbox2D : GameComponent
	{
		public Vector2 Size { get; set; }

		public Hitbox2D (Vector2 size)
		{
			this.Size = size;
		}
	}
}

