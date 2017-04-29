﻿using System;
using Microsoft.Xna.Framework;

namespace YACES
{
	public class Hitbox2D : GameComponent
	{
		public Vector2 Size { get; set; }

		public Rectangle Collider {
			get {
				return new Rectangle (
					(int)(GameObject.Transform.TruePosition2D.X - Size.X / 2),
					(int)(GameObject.Transform.TruePosition2D.Y - Size.Y / 2),
					(int)Size.X, (int)Size.Y);
			}
		}

		public Hitbox2D (Vector2 size)
		{
			this.Size = size;
		}
	}
}

