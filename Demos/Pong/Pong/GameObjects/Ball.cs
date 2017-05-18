using System;
using YACES;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong
{
	public class Ball : GameObject
	{
		public static Texture2D Sprite { get; set; }

		public Ball (Transform transform) : base (transform)
		{
			AddGameComponent (new VelocityComponent (Settings.BallDefaultSpeed));
			AddGameComponent (new Hitbox2D (new Vector2 (64, 64)));
			AddGameComponent (new Render2D (Sprite, 0));
		}
	}
}

