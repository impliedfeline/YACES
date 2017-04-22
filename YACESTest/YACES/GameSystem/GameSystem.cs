using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public abstract class GameSystem : IComparable<GameSystem>
	{
		public static readonly int LAST = Int32.MaxValue;
		public static readonly int FIRST = Int32.MinValue;

		public int Priority { get; protected set; }

		public GameSystem ()
		{
			this.Priority = FIRST;
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

