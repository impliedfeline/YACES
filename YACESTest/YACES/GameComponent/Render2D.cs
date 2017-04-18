using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace YACESTest
{
	public class Render2D : GameComponent
	{
		public Texture2D Sprite { get; set; }

		public Render2D (Texture2D sprite)
		{
			this.Sprite = sprite;
		}
	}
}

