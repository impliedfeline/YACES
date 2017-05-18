using System;
using YACES;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
	public class Paddle : GameObject
	{
		public static Texture2D Sprite { get; set; }

		public Paddle (Transform transform) : base (transform)
		{
			AddGameComponent (new Hitbox2D (new Vector2 (64, 192)));
			AddGameComponent (new Render2D (Sprite, 0));
		}
	}
}

