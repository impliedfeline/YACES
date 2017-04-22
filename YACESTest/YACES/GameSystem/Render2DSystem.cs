using System;
using Microsoft.Xna.Framework;

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
				Render2D render = go.GetGameComponentsByType<Render2D> () [0] as Render2D;
				SpriteBatch.Draw (render.Sprite, go.Transform.Position2D, Color.White);
			}
			SpriteBatch.End ();
		}
	}
}

