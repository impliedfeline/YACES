using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YACESTest
{
	public abstract class RenderSystem : GameSystem
	{
		public SpriteBatch SpriteBatch { get; set; }

		public RenderSystem () : base ()
		{
			Priority = GameSystem.LAST;
		}
	}
}

