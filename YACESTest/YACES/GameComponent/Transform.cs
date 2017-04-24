using System;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class Transform : GameComponent
	{
		// stores offset for children
		private Vector3 position;

		public Vector3 Position {
			get {
				if (GameObject.Parent == null) {
					return position;
				} else {
					Vector3 pRotation = GameObject.Parent.Transform.Rotation;
					Matrix rotationMatrix = Matrix.CreateRotationZ (pRotation.Z)
					                        * Matrix.CreateRotationY (pRotation.Y)
					                        * Matrix.CreateRotationX (pRotation.X);
					return Vector3.Transform (position, rotationMatrix) + GameObject.Parent.Transform.Position;
				}
			}
			set { position = value; }
		}

		public Vector3 Scaling { get; set; }

		private Vector3 rotation;

		public Vector3 Rotation {
			get {
				if (GameObject.Parent == null) {
					return rotation;
				} else {
					return rotation + GameObject.Parent.Transform.Rotation;
				}
			}
			set {
				rotation = new Vector3 (value.X, value.Y, value.Z);
			}
		}

		public Vector2 Position2D {
			get { return new Vector2 (Position.X, Position.Y); }
			set { Position = new Vector3 (value.X, value.Y, Position.Z); }
		}

		public Vector2 Scaling2D {
			get { return new Vector2 (Scaling.X, Scaling.Y); }
			set { Scaling = new Vector3 (value.X, value.Y, Scaling.Z); }
		}

		public float RotationZ {
			get { return Rotation.Z; }
			set { Rotation = new Vector3 (0, 0, value); }
		}

		public Transform (Vector3 position, Vector3 scaling, Vector3 rotation)
		{
			this.position = position;
			this.Scaling = scaling;
			this.rotation = rotation;
		}
	}
}

