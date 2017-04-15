using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public abstract class GameSystem : IComparable<GameSystem>
	{
		public int Priority { get; set; }

		public int CompareTo(GameSystem that) {
			return this.Priority - that.Priority;
		}

		public abstract List<GameEvent> PerformTransaction (GameScene gs, GameTime gt);
	}
}

