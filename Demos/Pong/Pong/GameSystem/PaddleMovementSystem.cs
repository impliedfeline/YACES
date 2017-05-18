using System;
using System.Collections.Generic;
using YACES;
using Microsoft.Xna.Framework;

namespace Pong
{
	public class PaddleMovementSystem : GameSystem
	{
		public bool MoveUpPlayerOne { get; set; }

		public bool MoveDownPlayerOne { get; set; }

		public bool MoveUpPlayerTwo { get; set; }

		public bool MoveDownPlayerTwo { get; set; }

		private float paddleSpeed = 0.5f;

		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			IReadOnlyList<Paddle> paddles = gameInstance.GameObjects.GetGameObjectsByType<Paddle> ();
			Paddle playerOne = paddles [0];
			Paddle playerTwo = paddles [1];
			float truePaddleSpeed = paddleSpeed * (float)gameTime.ElapsedGameTime.TotalMilliseconds;
			if (MoveUpPlayerOne)
				playerOne.Transform.Position2D -= new Vector2 (0, truePaddleSpeed);
			if (MoveDownPlayerOne)
				playerOne.Transform.Position2D += new Vector2 (0, truePaddleSpeed);
			if (MoveUpPlayerTwo)
				playerTwo.Transform.Position2D -= new Vector2 (0, truePaddleSpeed);
			if (MoveDownPlayerTwo)
				playerTwo.Transform.Position2D += new Vector2 (0, truePaddleSpeed);
			ResetMoves ();

			if (playerOne.Transform.Position2D.Y - Settings.PaddleHeight / 2 < 0) {
				playerOne.Transform.Position2D = new Vector2 (playerOne.Transform.Position2D.X, Settings.PaddleHeight / 2);
			}
			if (playerOne.Transform.Position2D.Y + Settings.PaddleHeight / 2 > Settings.ScreenHeight) {
				playerOne.Transform.Position2D = new Vector2 (
					playerOne.Transform.Position2D.X, Settings.ScreenHeight - Settings.PaddleHeight / 2);
			}

			if (playerTwo.Transform.Position2D.Y - Settings.PaddleHeight / 2 < 0) {
				playerTwo.Transform.Position2D = new Vector2 (playerTwo.Transform.Position2D.X, Settings.PaddleHeight / 2);
			}
			if (playerTwo.Transform.Position2D.Y + Settings.PaddleHeight / 2 > Settings.ScreenHeight) {
				playerTwo.Transform.Position2D = new Vector2 (
					playerTwo.Transform.Position2D.X, Settings.ScreenHeight - Settings.PaddleHeight / 2);
			}
		}

		private void ResetMoves ()
		{
			MoveUpPlayerOne = false;
			MoveDownPlayerOne = false;
			MoveUpPlayerTwo = false;
			MoveDownPlayerTwo = false;
		}
	}
}

