using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class GameScene
	{
		private AspectMap gameObjects;
		private List<GameSystem> gameSystems;

		public GameScene ()
		{
			gameObjects = new AspectMap ();
			gameSystems = new List<GameSystem> ();
		}

		public void AddGameObject (GameObject go)
		{
			gameObjects.AddGameObject (go);
		}

		public void RemoveGameObject (GameObject go)
		{
			gameObjects.RemoveGameObject (go);
		}

		public void AddGameSystem (GameSystem gs)
		{
			gameSystems.Add (gs);
		}

		public void RemoveGameSystem (GameSystem gs)
		{
			gameSystems.Remove (gs);
		}

		public void Initialize ()
		{
			gameSystems.Sort ();
		}

		public void RunSystems (GameTime gameTime)
		{
			gameSystems.ForEach (gs => gs.Run (gameObjects, gameTime));
		}
	}
}

