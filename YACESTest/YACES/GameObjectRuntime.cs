using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class GameObjectRuntime
	{
		private List<GameSystem> gameSystems;
		private GameScene currentScene;

		public GameObjectRuntime () {
			gameSystems = new List<GameSystem> ();
			currentScene = new GameScene ();
		}

		public void AddSystem (GameSystem gs) { gameSystems.Add (gs); }
		public void AddGameObject (GameObject go) { currentScene.AddGameObject (go); }

		public void ChangeScene (GameScene gs) {
			// Problematic, think this through
		}

		public void Initialize () {
			gameSystems.Sort ();
		}

		//TODO: Provide framework for chaining systems, as in the output events of one system
		// work as the input of another.
		public void Update (GameTime gameTime) {
			List<GameEvent> thing;
			gameSystems.ForEach (gs => thing.Add (gs.PerformTransaction (currentScene, gameTime)));
		}
	}
}
