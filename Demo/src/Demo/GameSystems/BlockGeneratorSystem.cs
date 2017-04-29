using System;
using Microsoft.Xna.Framework;

namespace YACES
{
	public class BlockGeneratorSystem : GameSystem
	{
		private Random rng;
		private double counter;

		public BlockGeneratorSystem () : base ()
		{
			rng = new Random ();
			counter = 0;
		}

		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			counter += gameTime.ElapsedGameTime.TotalSeconds;
			if (counter > 0.125) {
				counter = 0;
				Transform t = new Transform (new Vector3 (rng.Next (1200), 0, 0), Vector3.Zero, Vector3.One);
				Block b = new Block (t);
				gameInstance.GetGameSystem<CreationSystem> ().AttachGameObject (b);
			}
		}
	}
}

