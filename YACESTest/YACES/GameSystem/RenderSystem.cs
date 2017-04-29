using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YACES
{
	public abstract class RenderSystem : GameSystem
	{
		protected SpriteBatch spriteBatch;
		protected GraphicsDeviceManager graphicsDeviceManager;

		public RenderSystem (GraphicsDeviceManager graphicsDeviceManager) : base ()
		{
			this.graphicsDeviceManager = graphicsDeviceManager;
			this.spriteBatch = new SpriteBatch (graphicsDeviceManager.GraphicsDevice);
			Priority = GameSystem.LAST;
		}
	}
}

