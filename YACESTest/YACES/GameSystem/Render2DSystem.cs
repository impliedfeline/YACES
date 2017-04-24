using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YACESTest
{
	public class Render2DSystem : RenderSystem
	{
		private static Aspect containsSprite = new Aspect (typeof(Render2D));

		public Render2DSystem () : base ()
		{
		}

		public override void Run (GameScene gs, GameTime gt)
		{
			SpriteBatch.Begin ();
			foreach (GameObject go in gs.GetGameObjectsByAspect(containsSprite)) {
				Render2D render = go.GetGameComponentsByType<Render2D> () [0];
				SpriteBatch.Draw (render.Sprite, go.Transform.Position2D, null, Color.White,
					go.Transform.RotationZ,
					new Vector2 (render.Sprite.Width / 2, render.Sprite.Height / 2),
					go.Transform.Scaling2D, SpriteEffects.None, 1);
			}
			SpriteBatch.End ();
		}
	}
}

