using System;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class BlockGeneratorSystem : GameSystem
	{
		private Random rng;
		private double counter;

		public BlockGeneratorSystem (int priority) : base (priority)
		{
			rng = new Random ();
			counter = 0;
		}

		public override void Run (GameScene gs, GameTime gt)
		{
			counter += gt.ElapsedGameTime.TotalSeconds;
			if (counter > 0.125) {
				counter = 0;
				Transform2D t = new Transform2D (new Vector2 (rng.Next (1200), 0), new Vector2 (0, 0), new Vector2 (0, 0));
				Block b = new Block (t);
				CreationSystem cs = gs.GetGameSystem (typeof(CreationSystem)) as CreationSystem;
				cs.AttachGameObject (b);
			}
		}
	}
}

