using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACES
{
	/// <summary>
	/// An abstract base class for GameScenes.
	/// When defining their own GameScenes, the end user should derive from this class.
	/// </summary>
	public abstract class GameScene
	{
		/// <summary>
		/// The GameObjectMap containent the GameObjects in the scene.
		/// When adding new GameObjects in the constructor, add them through this.
		/// </summary>
		/// <value>The game objects.</value>
		public GameObjectMap GameObjects { get; private set; }

		private GameSystemSortedSet gameSystems;

		public IReadOnlyList<GameSystem> GameSystems {
			get { return gameSystems.GameSystemSortedList; }
		}

		public IReadOnlyDictionary<Type,GameSystem> GameSystemsDict {
			get { return gameSystems.GameSystemsDict; }
		}

		/// <summary>
		/// Initializes a new GameScene.
		/// Any scene specific systems or gameObjects to be added should be defined here.
		/// </summary>
		public GameScene ()
		{
			GameObjects = new GameObjectMap ();
			gameSystems = new GameSystemSortedSet ();
		}

		/// <summary>
		/// Adds a new GameSystem to the GameScene.
		/// Main use is to be called from the constructors of derived classes.
		/// </summary>
		/// <param name="gameSystem">Game system.</param>
		protected void AddGameSystem (GameSystem gameSystem)
		{
			gameSystems.AddGameSystem (gameSystem);
		}
	}
}

