using System;

using Microsoft.Xna.Framework.Graphics;

namespace YACES
{
	public class Block : GameObject
	{
		public static Texture2D Sprite { get; set; }

		public Block (Transform transform) : base (transform)
		{
			AddGameComponent (new Hitbox2D (transform.Position2D));
			AddGameComponent (new Render2D (Sprite, 0));
		}
	}
}

