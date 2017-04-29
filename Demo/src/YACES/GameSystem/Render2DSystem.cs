using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YACES
{
	public class Render2DSystem : RenderSystem
	{
		private static Aspect containsSprite = new Aspect (typeof(Render2D));

		public Render2DSystem (GraphicsDeviceManager gdm) : base (gdm)
		{
		}

		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			spriteBatch.Begin (SpriteSortMode.BackToFront);
			foreach (GameObject go in gameInstance.GameObjects.GetGameObjectsByAspect (containsSprite)) {
				Render2D render = go.GetGameComponentsByType<Render2D> () [0];
				spriteBatch.Draw (render.Sprite, go.Transform.TruePosition2D, null, Color.White,
					go.Transform.TrueRotationZ,
					new Vector2 (render.Sprite.Width / 2, render.Sprite.Height / 2),
					go.Transform.Scaling2D, SpriteEffects.None, render.Layer / 255f);
			}
			spriteBatch.End ();
		}
	}
}

