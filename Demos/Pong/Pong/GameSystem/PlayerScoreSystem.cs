using System;
using YACES;
using Microsoft.Xna.Framework;

namespace Pong
{
	public class PlayerScoreSystem : GameSystem
	{
		private int player1Score = 0;
		private int player2Score = 0;

		public void PlayerOnePoint ()
		{
			player1Score++;
		}

		public void PlayerTwoPoint ()
		{
			player2Score++;
		}

		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			if (player1Score >= 3) {
				gameInstance.LoadScene (new TitleScene ());
			}

			if (player2Score >= 3) {
				gameInstance.LoadScene (new TitleScene ());
			}
		}
	}
}

