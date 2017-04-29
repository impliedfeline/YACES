using System;
using Microsoft.Xna.Framework;

namespace YACES
{
	public class BlockDestroySystem : GameSystem
	{

		public BlockDestroySystem () : base ()
		{
		}

		public BlockDestroySystem (int priority) : base (priority)
		{
		}

		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			foreach (GameObject go in gameInstance.GameObjects.GetGameObjectsByType<Block>()) {
				if (go.Transform.Position2D.Y > 400) {
					gameInstance.GameObjects.RemoveGameObject (go);
				}
			}
		}
	}
}

