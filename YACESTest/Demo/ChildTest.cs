using System;
using Microsoft.Xna.Framework.Graphics;

namespace YACESTest
{
	public class ChildTest : GameObject
	{
		public static Texture2D Sprite { get; set; }

		public ChildTest (Transform transform) : base (transform)
		{
			AddGameComponent<Render2D> (new Render2D (Sprite));
		}
	}
}

