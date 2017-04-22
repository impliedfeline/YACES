using System;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class BlockDestroySystem : GameSystem
	{
		private static Aspect isBlock = new Aspect (typeof(Block));

		public BlockDestroySystem () : base ()
		{
		}

		public BlockDestroySystem (int priority) : base (priority)
		{
		}

		public override void Run (GameScene gs, GameTime gt)
		{
			foreach (GameObject go in gs.GetGameObjectsByAspect(isBlock)) {
				if (go.Transform.Position2D.Y > 400) {
					gs.RemoveGameObject (go);
				}
			}
		}
	}
}

