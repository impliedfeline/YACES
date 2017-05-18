using System;
using YACES;
using Microsoft.Xna.Framework;

namespace Pong
{
	public class MainScene : GameScene
	{
		public MainScene ()
		{
			AddGameSystem (new BallHandlingSystem ());
			AddGameSystem (new BallMovementSystem ());
			AddGameSystem (new PlayerScoreSystem ());
			AddGameSystem (new PaddleMovementSystem ());
			AddGameSystem (new HumanInputSystem ());
			AddGameSystem (new AIInputSystem ());

			GameObjects.AddGameObject (new Paddle (new Transform (
				new Vector3 (32, Settings.ScreenHeight / 2, 0))));
			GameObjects.AddGameObject (new Paddle (new Transform (
				new Vector3 (Settings.ScreenWidth - 32, Settings.ScreenHeight / 2, 0))));
				
			GameObjects.AddGameObject (new Ball (new Transform (new Vector3 (
				Settings.ScreenWidth / 2, 
				Settings.ScreenHeight / 2,
				0))));
			
		}
	}
}

