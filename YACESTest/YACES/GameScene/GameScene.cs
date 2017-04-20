using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class GameScene
	{
		private AspectMap gameObjects;

		private List<GameSystem> gameSystems;
		private Dictionary<Type,GameSystem> gameSystemsDict;

		public GameScene ()
		{
			gameObjects = new AspectMap ();
			gameSystems = new List<GameSystem> ();
			gameSystemsDict = new Dictionary<Type, GameSystem> ();
		}

		public void AddGameObject (GameObject go)
		{
			gameObjects.AddGameObject (go);
		}

		public void RemoveGameObject (GameObject go)
		{
			gameObjects.RemoveGameObject (go);
		}

		public List<GameObject> GetGameObjectsByAspect (Aspect aspect)
		{
			return gameObjects.GetGameObjectsByAspect (aspect);
		}

		// TODO: add checks
		public void AddGameSystem<T> (T gs)
		{
			gameSystems.Add (gs as GameSystem);
			gameSystemsDict [typeof(T)] = gs as GameSystem;
		}

		// TODO: here aswell
		public void RemoveGameSystem<T> (T gs)
		{
			gameSystems.Remove (gs as GameSystem);
			gameSystemsDict [typeof(T)] = null;
		}

		public GameSystem GetGameSystem (Type t)
		{
			return gameSystemsDict [t];
		}

		public void Initialize ()
		{
			gameSystems.Sort ();
		}

		public void RunSystems (GameTime gameTime)
		{
			gameSystems.ForEach (gs => gs.Run (this, gameTime));
		}

		public void RunAdHocSystem (GameSystem gs, GameTime gameTime)
		{
			gs.Run (this, gameTime);
		}
	}
}

