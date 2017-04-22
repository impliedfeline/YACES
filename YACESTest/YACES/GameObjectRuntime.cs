using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YACESTest
{
	public class GameObjectRuntime
	{
		private GameScene currentScene;
		private GraphicsDeviceManager graphics;

		public RenderSystem Renderer { get; set; }

		public GameObjectRuntime (GraphicsDeviceManager graphics)
		{
			currentScene = new GameScene ();
			this.graphics = graphics;
		}

		public void ChangeScene (GameScene gs)
		{
			currentScene = gs;
			// TODO: Pass certain systems and gameObjects flagged DontDestroyOnLoad, Initialize
		}

		public void LoadContent ()
		{
			Renderer.SpriteBatch = new SpriteBatch (graphics.GraphicsDevice);
		}

		public void Initialize ()
		{
			currentScene.AddGameSystem (new CreationSystem ());
			currentScene.AddGameSystem (new DestroySystem ());
			currentScene.AddGameSystem (Renderer);
			currentScene.Initialize ();
		}

		public void Update (GameTime gameTime)
		{
			currentScene.RunSystems (gameTime);
		}

		public void Draw (GameTime gameTime)
		{
			currentScene.RunAdHocSystem (Renderer, gameTime);
		}
	}
}