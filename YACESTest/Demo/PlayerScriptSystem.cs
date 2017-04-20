using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace YACESTest
{
	public class PlayerScriptSystem : GameSystem
	{
		private static Aspect isPlayer = new Aspect (typeof(Player));

		public bool MoveLeft { get; set; }

		public bool MoveRight { get; set; }

		public bool MoveUp { get; set; }

		public bool MoveDown { get; set; }

		public PlayerScriptSystem () : base ()
		{
		}

		public PlayerScriptSystem (int priority) : base (priority)
		{
		}

		public override void Run (GameScene gs, GameTime gt)
		{
			KeyboardState state = Keyboard.GetState ();
			Player p = gs.GetGameObjectsByAspect (isPlayer) [0] as Player;
			Transform2D t = p.Transform as Transform2D;
			float move = 0.5f * gt.ElapsedGameTime.Milliseconds;

			if (MoveUp) {
				t.Position -= new Vector2 (0, move);
				MoveUp = false;
			}
			if (MoveDown) {
				t.Position -= new Vector2 (0, -move);
				MoveDown = false;
			}
			if (MoveLeft) {
				t.Position -= new Vector2 (move, 0);
				MoveLeft = false;
			}
			if (MoveRight) {
				t.Position -= new Vector2 (-move, 0);
				MoveRight = false;
			}
		}
	}
}

