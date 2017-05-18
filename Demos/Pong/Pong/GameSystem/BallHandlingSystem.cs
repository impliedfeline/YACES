using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using YACES;

namespace Pong
{
	public class BallHandlingSystem : GameSystem
	{

		private bool touchedLastFrame = false;

		public BallHandlingSystem () : base ()
		{
		}

		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			IReadOnlyList<Paddle> paddles = gameInstance.GameObjects.GetGameObjectsByType<Paddle> ();
			Ball ball = gameInstance.GameObjects.GetGameObjectsByType<Ball> () [0];
			bool touching = false;
			foreach (Paddle paddle in paddles) {
				Rectangle ballRect = ball.GetGameComponentsByType<Hitbox2D> () [0].Collider;
				Rectangle paddleRect = paddle.GetGameComponentsByType<Hitbox2D> () [0].Collider;
				if (ballRect.Intersects (paddleRect)) {
					touching = true;
					if (!touchedLastFrame) {
						ball.GetGameComponentsByType<VelocityComponent> () [0].Velocity *= new Vector2 (-1.5f, 1.5f);
					}
				}
			}
			if (touching != touchedLastFrame)
				touchedLastFrame = touching;
			
			float ballY = ball.Transform.TruePosition2D.Y + 128;
			if (ballY < 0 || ballY > Settings.ScreenHeight) {
				ball.GetGameComponentsByType<VelocityComponent> () [0].Velocity *= new Vector2 (1, -1);
				return;
			}
			PlayerScoreSystem pss = gameInstance.GetGameSystem<PlayerScoreSystem> ();
			float ballX = ball.Transform.TruePosition2D.X + 32;
			if (ballX < 0) {
				pss.PlayerTwoPoint ();
				resetBall (ball);
			} else if (ballX > Settings.ScreenWidth) {
				pss.PlayerOnePoint ();
				resetBall (ball);
			}
		}

		private void resetBall (Ball ball)
		{
			ball.Transform.Position2D = new Vector2 (Settings.ScreenWidth / 2, Settings.ScreenHeight / 2);
			ball.GetGameComponentsByType<VelocityComponent> () [0].Velocity = Settings.BallDefaultSpeed;
		}
	}
}

