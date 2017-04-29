using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace YACES
{
	public class DestroySystem : GameSystem
	{
		private Queue<GameObject> delQueue;

		public DestroySystem () : base ()
		{
			delQueue = new Queue<GameObject> ();
		}

		public DestroySystem (int priority) : base (priority)
		{
			delQueue = new Queue<GameObject> ();
		}

		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			while (delQueue.Count > 0) {
				gameInstance.GameObjects.RemoveGameObject (delQueue.Dequeue ());
			}
		}

		protected void MarkGameObject (GameObject go)
		{
			delQueue.Enqueue (go);
		}
	}
}

