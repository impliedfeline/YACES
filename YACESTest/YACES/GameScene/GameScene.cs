using System;
using System.Collections.Generic;

namespace YACESTest
{
	public class GameScene
	{
		public HashSet<GameObject> GameObjects { get; private set; }

		public GameScene () {
			GameObjects = new HashSet<GameObject> ();
		}

		public GameScene (HashSet<GameObject> gameObjects) {
			this.GameObjects = gameObjects;
		}

		public void AddGameObject (GameObject go) { GameObjects.Add (go); }
	}
}

