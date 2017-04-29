using System;
using Microsoft.Xna.Framework;

namespace YACES
{
	/// <summary>
	/// Transform component.
	/// <para>Stores position, scaling and rotation as 3D vectors.
	/// <para>Provides interface for utilization as 2D transform.
	/// </summary>
	public class Transform : GameComponent
	{
		/// <summary>
		/// Gets or sets the position.
		/// For child gameObjects, this stores the offset to the parent.
		/// </summary>
		/// <value>The position.</value>
		public Vector3 Position { get; set; }

		/// <summary>
		/// Gets the true position. (if the gameObject is a child, returns the offset + parent position)
		/// </summary>
		/// <value>The true position.</value>
		public Vector3 TruePosition {
			get {
				if (GameObject.Parent == null) {
					return Position;
				} else {
					Vector3 pRotation = GameObject.Parent.Transform.Rotation;
					Matrix rotationMatrix = Matrix.CreateRotationZ (pRotation.Z)
					                        * Matrix.CreateRotationY (pRotation.Y)
					                        * Matrix.CreateRotationX (pRotation.X);
					return Vector3.Transform (Position, rotationMatrix) + GameObject.Parent.Transform.Position;
				}
			}
		}

		private Vector3 rotation;

		/// <summary>
		/// Gets or sets the rotation in radians.
		/// </summary>
		/// <value>The rotation.</value>
		public Vector3 Rotation {
			get { return rotation; }
			set {
				rotation = new Vector3 (value.X, value.Y, value.Z);
				float twoPi = 2 * MathHelper.Pi;
				rotation = new Vector3 (Rotation.X % twoPi, Rotation.Y % twoPi, Rotation.Z % twoPi);
			}
		}

		/// <summary>
		/// Gets the true rotation. (if the gameObject is a child, returns the rotation + parent rotation)
		/// </summary>
		/// <value>The true rotation.</value>
		public Vector3 TrueRotation {
			get {
				if (GameObject.Parent == null) {
					return Rotation;
				} else {
					return Rotation + GameObject.Parent.Transform.Rotation;
				}
			}
		}

		/// <summary>
		/// Gets or sets the scaling.
		/// </summary>
		/// <value>The scaling.</value>
		public Vector3 Scaling { get; set; }

		/// <summary>
		/// Gets or sets the position as a 2D vector.
		/// </summary>
		/// <value>The position2 d.</value>
		public Vector2 Position2D {
			get { return new Vector2 (Position.X, Position.Y); }
			set { Position = new Vector3 (value.X, value.Y, Position.Z); }
		}

		/// <summary>
		/// Gets the true position as a 2D vector.
		/// </summary>
		/// <value>The true position2 d.</value>
		public Vector2 TruePosition2D {
			get { return new Vector2 (TruePosition.X, TruePosition.Y); }
		}

		/// <summary>
		/// Gets or sets the rotation along the z axis as a float.
		/// </summary>
		/// <value>The rotation z.</value>
		public float RotationZ {
			get { return Rotation.Z; }
			set { Rotation = new Vector3 (0, 0, value); }
		}

		/// <summary>
		/// Gets the true rotation along the z axis.
		/// </summary>
		/// <value>The true rotation z.</value>
		public float TrueRotationZ {
			get { return TrueRotation.Z; }
		}

		/// <summary>
		/// Gets or sets the scaling as a 2D vector.
		/// </summary>
		/// <value>The scaling2 d.</value>
		public Vector2 Scaling2D {
			get { return new Vector2 (Scaling.X, Scaling.Y); }
			set { Scaling = new Vector3 (value.X, value.Y, Scaling.Z); }
		}

		public Transform (Vector3 position)
		{
			this.Position = position;
			this.rotation = Vector3.Zero;
			this.Scaling = Vector3.One;
		}

		public Transform (Vector3 position, Vector3 rotation)
		{
			this.Position = position;
			this.rotation = rotation;
			this.Scaling = Vector3.One;
		}

		public Transform (Vector3 position, Vector3 rotation, Vector3 scaling)
		{
			this.Position = position;
			this.rotation = rotation;
			this.Scaling = scaling;
		}
	}
}

