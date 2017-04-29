using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACES
{
	public class GravitySystem : GameSystem
	{
		public GravitySystem () : base ()
		{
		}

		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			IReadOnlyList<Block> bs = gameInstance.GameObjects.GetGameObjectsByType<Block> ();

			if (bs != null) {
				foreach (Block go in bs) {
					go.Transform.Position2D += new Vector2 (0, 0.5f * gameTime.ElapsedGameTime.Milliseconds);
				}
			}
		}
	}
}

