using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public abstract class GameSystem : IComparable<GameSystem>
	{
		public int Priority { get; protected set; }

		public GameSystem ()
		{
			this.Priority = Int32.MaxValue;
		}

		public GameSystem (int priority)
		{
			this.Priority = priority;
		}

		public int CompareTo (GameSystem that)
		{
			return this.Priority - that.Priority;
		}

		public abstract void Run (GameScene gs, GameTime gt);
	}
}

