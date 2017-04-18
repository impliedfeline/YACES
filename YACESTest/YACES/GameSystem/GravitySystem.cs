using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class GravitySystem : GameSystem
	{
		private Aspect containsTransform;

		public GravitySystem (int priority) : base(priority)
		{
			containsTransform = new Aspect (typeof(Transform2D));
		}

		public override void Run (AspectMap am, GameTime gt)
		{
			foreach (GameObject go in am.GetGameObjectsByAspect(containsTransform)) {
				Transform2D transform = go.GameComponents [typeof(Transform2D)] [0] as Transform2D;
				transform.Position += new Vector2 (0, 1 * gt.ElapsedGameTime.Seconds);
			}
		}
	}
}

