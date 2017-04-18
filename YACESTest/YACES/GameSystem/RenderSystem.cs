using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YACESTest
{
	public class RenderSystem : GameSystem
	{
		private Aspect containsSprite;
		private SpriteBatch spriteBatch;

		public RenderSystem (int priority, SpriteBatch spriteBatch) : base(priority)
		{
			containsSprite = new Aspect (typeof(Render2D));
			this.spriteBatch = spriteBatch;
		}

		public override void Run (AspectMap am, GameTime gt)
		{
			spriteBatch.Begin ();
			foreach (GameObject go in am.GetGameObjectsByAspect(containsSprite)) {
				Transform2D transform = go.GameComponents [typeof(Transform2D)] [0] as Transform2D;
				Render2D render = go.GameComponents [typeof(Render2D)] [0] as Render2D;
				spriteBatch.Draw (render.Sprite, transform.Position, Color.White);
			}
			spriteBatch.End ();
		}
	}
}

