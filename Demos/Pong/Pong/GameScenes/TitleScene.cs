using System;
using YACES;
using Microsoft.Xna.Framework;

namespace Pong
{
	public class TitleScene : GameScene
	{
		public TitleScene ()
		{
			AddGameSystem (new EnterListenerSystem ());
			GameObjects.AddGameObject (new TitleBanner (new Transform (
				new Vector3 (Settings.ScreenWidth / 2, Settings.ScreenHeight / 2, 0))));
		}
	}
}

