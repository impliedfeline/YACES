using System;
using YACES;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Pong
{
	public class EnterListenerSystem : GameSystem
	{
		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			KeyboardState kb = Keyboard.GetState ();
			if (kb.IsKeyDown (Keys.Enter)) {
				gameInstance.LoadScene (new MainScene ());
			}
		}
	}
}


