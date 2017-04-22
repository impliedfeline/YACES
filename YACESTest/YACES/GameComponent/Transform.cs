using System;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class Transform : GameComponent
	{
		public Vector3 Position { get; set; }

		public Vector3 Scaling { get; set; }

		public Vector3 Rotation { get; set; }

		public Vector2 Position2D {
			get { return new Vector2 (Position.X, Position.Y); }
			set { Position = new Vector3 (value.X, value.Y, Position.Z); }
		}

		public Vector2 Scaling2D {
			get { return new Vector2 (Scaling.X, Scaling.Y); }
			set { Scaling = new Vector3 (value.X, value.Y, Scaling.Z); }
		}

		public Vector2 Rotation2D {
			get { return new Vector2 (Rotation.X, Rotation.Y); }
			set { Rotation = new Vector3 (value.X, value.Y, Rotation.Z); }
		}

		public Transform (Vector3 position, Vector3 scaling, Vector3 rotation)
		{
			this.Position = position;
			this.Scaling = scaling;
			this.Rotation = rotation;
		}
	}
}

