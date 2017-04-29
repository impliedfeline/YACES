using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework.Graphics;

namespace YACESTest
{
	public class BlockCreationSystem : CreationSystem
	{
		public BlockCreationSystem (int priority) : base (priority)
		{
		}

		public void CreateBlock (Transform2D transform)
		{
			GameObject block = new GameObject ();
			block.AddGameComponent (transform);
			block.AddGameComponent (new Render2D (Block.Sprite));
			block.AddToAspect (typeof(Block));
			AttachGameObject (block);
		}
	}
}

