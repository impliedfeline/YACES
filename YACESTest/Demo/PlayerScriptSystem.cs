using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace YACESTest
{
	public class PlayerScriptSystem : GameSystem
	{
		private static Aspect isPlayer = new Aspect (typeof(Player));

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

		public override void Run (GameScene gs, GameTime gt)
		{
			Player p = gs.GetGameObjectsByAspect (isPlayer) [0] as Player;
			float move = 0.5f * gt.ElapsedGameTime.Milliseconds;

			if (MoveUp) {
				p.Transform.Position2D -= new Vector2 (0, move);
				MoveUp = false;
			}
			if (MoveDown) {
				p.Transform.Position2D -= new Vector2 (0, -move);
				MoveDown = false;
			}
			if (MoveLeft) {
				p.Transform.Position2D -= new Vector2 (move, 0);
				MoveLeft = false;
			}
			if (MoveRight) {
				p.Transform.Position2D -= new Vector2 (-move, 0);
				MoveRight = false;
			}
		}
	}
}

