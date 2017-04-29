using System;
using System.Collections.Generic;

using Microsoft.Xna.Framework;

namespace YACES
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

		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			while (addQueue.Count > 0) {
				gameInstance.GameObjects.AddGameObject (addQueue.Dequeue ());
			}
		}

		/// <summary>
		/// Attachs a GameObject to a internal queue.
		/// Items in the queue are added to the current scene at the end of each Update.
		/// </summary>
		/// <param name="gameObject">Game object.</param>
		public void AttachGameObject (GameObject gameObject)
		{
			addQueue.Enqueue (gameObject);
		}
	}
}

