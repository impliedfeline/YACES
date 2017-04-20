using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class GravitySystem : GameSystem
	{
		private static Aspect isBlock = new Aspect (typeof(Block));

		public GravitySystem (int priority) : base (priority)
		{
		}

		public override void Run (GameScene gs, GameTime gt)
		{
			foreach (GameObject go in gs.GetGameObjectsByAspect(isBlock)) {
				Transform2D transform = go.Transform as Transform2D;
				transform.Position += new Vector2 (0, 0.5f * (gt.ElapsedGameTime.Milliseconds));
			}
		}
	}
}

