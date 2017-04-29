using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YACES
{
	public class GameRuntime
	{
		private RenderSystem renderer;

		private GameSystemSortedSet defaultGameSystems;

		private GameInstance gameInstance;

		/// <summary>
		/// Instantiate new GameRuntime for 2D games.
		/// </summary>
		/// <returns>A 2D GameRuntime.</returns>
		/// <param name="graphicsDeviceManager">Graphics device manager.</param>
		public static GameRuntime GameRuntime2D (GraphicsDeviceManager graphicsDeviceManager)
		{
			return new GameRuntime (new Render2DSystem (graphicsDeviceManager));
		}

		/// <summary>
		/// Instantiate new GameRuntime for 3D games.
		/// </summary>
		/// <returns>A 3D GameRuntime.</returns>
		/// <param name="graphicsDeviceManager">Graphics device manager.</param>
		public static GameRuntime GameRuntime3D (GraphicsDeviceManager graphicsDeviceManager)
		{
			throw new NotImplementedException ();
		}

		private GameRuntime (RenderSystem renderer)
		{
			this.renderer = renderer;
			this.defaultGameSystems = new GameSystemSortedSet ();
			this.defaultGameSystems.AddGameSystem (new CreationSystem ());
			this.defaultGameSystems.AddGameSystem (new DestroySystem ());
		}

		/// <summary>
		/// Loads the initial scene of the game.
		/// </summary>
		/// <param name="gameScene">Game scene.</param>
		public void LoadScene (GameScene gameScene)
		{
			if (gameInstance == null) {
				gameInstance = new GameInstance (gameScene, defaultGameSystems);
				return;
			}

		}

		private void SwapScene ()
		{
			gameInstance.Initialize ();
		}

		/// <summary>
		/// Update phase of the game loop. Call this in the Game-class Update-method.
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public void Update (GameTime gameTime)
		{
			if (gameInstance.LoadNextScene) {
				SwapScene ();
			}
			foreach (GameSystem gs in gameInstance.GameSystems) {
				gs.Run (gameInstance, gameTime);
			}
			foreach (GameSystem gs in defaultGameSystems.GameSystemSortedList) {
				gs.Run (gameInstance, gameTime);
			}
		}

		/// <summary>
		/// Draw phase of the game loop. Call this in the Game-class Draw-method.
		/// </summary>
		/// <param name="gameTime">Game time.</param>
		public void Draw (GameTime gameTime)
		{
			renderer.Run (gameInstance, gameTime);
		}
	}
}