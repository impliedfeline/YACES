using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using YACES;

namespace Pong
{
	public class BallMovementSystem : GameSystem
	{
		public BallMovementSystem () : base ()
		{
		}

		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			Ball ball = gameInstance.GameObjects.GetGameObjectsByType<Ball> () [0];
			Vector2 ballSpeed = ball.GetGameComponentsByType<VelocityComponent> () [0].Velocity;
			float gameTimeMs = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
			ballSpeed *= new Vector2 (gameTimeMs, gameTimeMs);
			ball.Transform.Position2D += ballSpeed;
		}
	}
}

