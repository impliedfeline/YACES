using System;
using System.Collections.Generic;

namespace YACES
{
	public class GameInstance
	{
		private GameScene currentScene;
		private GameSystemSortedSet defaultGameSystems;

		/// <summary>
		/// Returns the GameObjectMap of the current scene.
		/// </summary>
		/// <value>The game objects.</value>
		public GameObjectMap GameObjects { get; private set; }

		/// <summary>
		/// Returns the GameSystems of the current scene in a readonly-sorted list.
		/// Instead of using this for fetching specific GameSystems, use GetGameSystem.
		/// </summary>
		/// <value>The game systems.</value>
		public IReadOnlyList<GameSystem> GameSystems {
			get { return currentScene.GameSystems; }
		}

		private GameScene nextScene;

		/// <summary>
		/// Returns a value indicating whether the scene will be changed on the next Update.
		/// </summary>
		/// <value><c>true</c> if load next scene; otherwise, <c>false</c>.</value>
		public bool LoadNextScene { get; private set; }

		public GameInstance (GameScene gameScene, GameSystemSortedSet defaultGameSystems)
		{
			this.currentScene = gameScene;
			this.GameObjects = currentScene.GameObjects;
			this.defaultGameSystems = defaultGameSystems;
			this.LoadNextScene = false;
		}

		public void LoadScene (GameScene gameScene)
		{
			nextScene = gameScene;
			LoadNextScene = true;
		}

		public void Initialize ()
		{
			currentScene = nextScene;
			GameObjects = currentScene.GameObjects;
			nextScene = null;
			LoadNextScene = false;
		}

		/// <summary>
		/// Returns a GameSystem of type T.
		/// </summary>
		/// <returns>The game system.</returns>
		/// <typeparam name="T">The 1st type parameter.</typeparam>
		public T GetGameSystem<T> () where T : GameSystem
		{
			if (currentScene.GameSystemsDict.ContainsKey (typeof(T))) {
				return currentScene.GameSystemsDict [typeof(T)] as T;
			}
			if (defaultGameSystems.GameSystemsDict.ContainsKey (typeof(T))) {
				return defaultGameSystems.GameSystemsDict [typeof(T)] as T;
			}
			return null;
		}
	}
}

