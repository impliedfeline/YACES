using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace YACES
{
	public class PlayerScriptSystem : GameSystem
	{
		public bool MoveUp { get; set; }

		public bool MoveDown { get; set; }

		public bool MoveLeft { get; set; }

		public bool MoveRight { get; set; }

		public PlayerScriptSystem () : base ()
		{
		}

		public PlayerScriptSystem (int priority) : base (priority)
		{
		}

		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			Player p = gameInstance.GameObjects.GetGameObjectsByType<Player> () [0];
			Transform t = p.Transform;
			float rotSpeed = (1f / 256) * gameTime.ElapsedGameTime.Milliseconds;
			float moveSpeed = 1f * gameTime.ElapsedGameTime.Milliseconds;

			if (MoveLeft) {
				t.RotationZ -= rotSpeed;
				//p.Transform.Position2D -= new Vector2 (move, 0);
				MoveLeft = false;
			}
			if (MoveRight) {
				t.RotationZ += rotSpeed;
				//p.Transform.Position2D += new Vector2 (move, 0);
				MoveRight = false;
			}
			if (MoveUp) {
				t.Position2D -= new Vector2 (moveSpeed * -(float)Math.Sin (t.RotationZ),
					moveSpeed * (float)Math.Cos (t.RotationZ));
				//p.Transform.Position2D -= new Vector2 (0, move);
				MoveUp = false;
			}
			if (MoveDown) {
				t.Position2D += new Vector2 (moveSpeed * -(float)Math.Sin (t.RotationZ),
					moveSpeed * (float)Math.Cos (t.RotationZ));
				//p.Transform.Position2D += new Vector2 (0, move);
				MoveDown = false;
			}
			HashSet<GameObject> cts = p.Children;
			foreach (GameObject ct in cts) {
				ct.Transform.RotationZ += rotSpeed;
			}
		}
	}
}

