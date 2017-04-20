using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace YACESTest
{
	public abstract class DestroySystem : GameSystem
	{
		private Queue<GameObject> delQueue;

		public DestroySystem (int priority) : base (priority)
		{
			delQueue = new Queue<GameObject> ();
		}

		public override void Run (GameScene gs, GameTime gt)
		{
			while (delQueue.Count > 0) {
				gs.RemoveGameObject (delQueue.Dequeue ());
			}
		}

		protected void MarkGameObject (GameObject go)
		{
			delQueue.Enqueue (go);
		}
	}
}

