using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace YACESTest
{
	public class GameObject
	{
		public Dictionary<Type, List<GameComponent>> GameComponents { get; private set; }

		public Aspect Aspect { get; private set; }

		public GameObject (Dictionary<Type, List<GameComponent>> gameComponents, Aspect aspect)
		{
			this.GameComponents = gameComponents;
			this.Aspect = aspect;
		}
	}
}

