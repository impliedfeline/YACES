using System;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class Transform2D : GameComponent
	{
		public Vector2 Position { get; set; }

		public Vector2 Scaling { get; set; }

		public Vector2 Rotation { get; set; }

		public Transform2D (Vector2 position, Vector2 scaling, Vector2 rotation)
		{
			this.Position = position;
			this.Scaling = scaling;
			this.Rotation = rotation;
		}
	}
}

