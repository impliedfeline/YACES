using System;
using YACES;
using Microsoft.Xna.Framework;

namespace Pong
{
	public class AIInputSystem : GameSystem
	{
		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			PaddleMovementSystem pms = gameInstance.GetGameSystem<PaddleMovementSystem> ();
			Paddle paddle = gameInstance.GameObjects.GetGameObjectsByType<Paddle> () [1];
			Ball ball = gameInstance.GameObjects.GetGameObjectsByType<Ball> () [0];
			if (ball.Transform.Position2D.Y < paddle.Transform.Position2D.Y) {
				pms.MoveUpPlayerTwo = true;
			}

			if (ball.Transform.Position2D.Y > paddle.Transform.Position2D.Y) {
				pms.MoveDownPlayerTwo = true;
			}

		}
	}
}

