using System;
using YACES;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
	public class HumanInputSystem : GameSystem
	{
		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			PaddleMovementSystem pms = gameInstance.GetGameSystem<PaddleMovementSystem> ();
			KeyboardState kb = Keyboard.GetState ();
			if (kb.IsKeyDown (Keys.Down) || kb.IsKeyDown (Keys.S)) {
				pms.MoveDownPlayerOne = true;
			}
			if (kb.IsKeyDown (Keys.Up) || kb.IsKeyDown (Keys.W)) {
				pms.MoveUpPlayerOne = true;
			}
		}
	}
}

