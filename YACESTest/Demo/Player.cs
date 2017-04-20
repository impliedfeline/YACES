using System;

using Microsoft.Xna.Framework.Graphics;

namespace YACESTest
{
	public class Player : GameObject
	{
		public static Texture2D Sprite { get; set; }

		public Player (Transform2D transform) : base (transform)
		{
			AddGameComponent<Render2D> (new Render2D (Sprite));
			AddToAspect (typeof(Player));
		}
	}
}

