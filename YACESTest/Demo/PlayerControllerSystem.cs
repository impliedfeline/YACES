using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace YACESTest
{
	public class PlayerControllerSystem : GameSystem
	{
		public PlayerControllerSystem () : base ()
		{
		}

		public override void Run (GameScene gs, GameTime gt)
		{
			KeyboardState state = Keyboard.GetState ();
			PlayerScriptSystem pcs = gs.GetGameSystem<PlayerScriptSystem> ();
			if (state.IsKeyDown (Keys.W) || state.IsKeyDown (Keys.Up)) {
				pcs.MoveUp = true;
			}
			if (state.IsKeyDown (Keys.A) || state.IsKeyDown (Keys.Left)) {
				pcs.MoveLeft = true;
			}
			if (state.IsKeyDown (Keys.S) || state.IsKeyDown (Keys.Down)) {	
				pcs.MoveDown = true;
			}
			if (state.IsKeyDown (Keys.D) || state.IsKeyDown (Keys.Right)) {
				pcs.MoveRight = true;
			}
		}
	}
}

