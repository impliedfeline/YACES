using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class GameObjectRuntime
	{
		private LinkedList<GameScene> sceneList;
		private GameScene currentScene;

		public GameObjectRuntime ()
		{
			sceneList = new LinkedList<GameScene> ();
			currentScene = new GameScene ();
		}

		public void AddGameObject (GameObject go)
		{
			currentScene.AddGameObject (go);
		}

		public void ChangeScene (GameScene gs)
		{
			// Problematic, think this through
		}

		public void Initialize ()
		{

		}
		//TODO: Provide framework for chaining systems, as in the output events of one system
		// work as the input of another.
		public void Update (GameTime gameTime)
		{

		}
	}
}
