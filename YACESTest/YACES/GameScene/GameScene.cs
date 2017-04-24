using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class GameScene
	{
		public GameObjectMap GameObjects { get; private set; }

		private List<GameSystem> gameSystems;
		private Dictionary<Type,GameSystem> gameSystemsDict;

		public GameScene ()
		{
			GameObjects = new GameObjectMap ();
			gameSystems = new List<GameSystem> ();
			gameSystemsDict = new Dictionary<Type, GameSystem> ();
		}

		public void AddGameObject<T> (T go) where T : GameObject
		{
			GameObjects.AddGameObject<T> (go);
		}

		public void RemoveGameObject<T> (T go) where T : GameObject
		{
			GameObjects.RemoveGameObject<T> (go);
		}

		public List<GameObject> GetGameObjectsByAspect (Aspect aspect)
		{
			return GameObjects.GetGameObjectsByAspect (aspect);
		}

		public void AddGameSystem<T> (T gs) where T : GameSystem
		{
			gameSystems.Add (gs);
			gameSystemsDict [typeof(T)] = gs;
		}

		public void RemoveGameSystem<T> (T gs) where T : GameSystem
		{
			
			gameSystems.Remove (gs);
			gameSystemsDict [typeof(T)] = null;
		}

		public T GetGameSystem<T> () where T : GameSystem
		{
			return gameSystemsDict [typeof(T)] as T;
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

