using System;

using Microsoft.Xna.Framework.Graphics;

namespace YACESTest
{
	public class Block : GameObject
	{
		public static Texture2D Sprite { get; set; }

		public Block (Transform transform) : base (transform)
		{
			AddGameComponent<Hitbox2D> (new Hitbox2D (transform.Position2D));
			AddGameComponent<Render2D> (new Render2D (Sprite));
			AddToAspect<Block> ();
		}
	}
}

