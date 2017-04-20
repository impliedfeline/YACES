using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class CreationSystem : GameSystem
	{
		private Queue<GameObject> addQueue;

		public CreationSystem () : base ()
		{
			addQueue = new Queue<GameObject> ();
		}

		public CreationSystem (int priority) : base (priority)
		{
			addQueue = new Queue<GameObject> ();
		}

		public override void Run (GameScene gs, GameTime gt)
		{
			while (addQueue.Count > 0) {
				gs.AddGameObject (addQueue.Dequeue ());
			}
		}

		public void AttachGameObject (GameObject go)
		{
			addQueue.Enqueue (go);
		}
	}
}

