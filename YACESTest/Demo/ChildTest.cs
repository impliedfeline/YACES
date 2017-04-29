using System;
using Microsoft.Xna.Framework.Graphics;

namespace YACES
{
	public class ChildTest : GameObject
	{
		public static Texture2D Sprite { get; set; }

		public ChildTest (Transform transform) : base (transform)
		{
			AddGameComponent (new Render2D (Sprite, 0));
		}
	}
}

