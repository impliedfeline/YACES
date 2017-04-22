﻿using System;
using Microsoft.Xna.Framework;

namespace YACESTest
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
				Vector3 z = new Vector3 (0, 0, 0);
				Transform t = new Transform (new Vector3 (rng.Next (1200), 0, 0), z, z);
				Block b = new Block (t);
				CreationSystem cs = gs.GetGameSystem<CreationSystem> ();
				cs.AttachGameObject (b);
			}
		}
	}
}

