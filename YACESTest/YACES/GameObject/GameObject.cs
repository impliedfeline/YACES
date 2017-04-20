using System;
using System.Collections.Generic;
using System.Collections.Concurrent;

namespace YACESTest
{
	public abstract class GameObject
	{
		private Dictionary<Type, List<GameComponent>> gameComponents;

		public Aspect Aspect { get; private set; }

		public Transform Transform { get; private set; }

		public GameObject (Transform transform)
		{
			this.gameComponents = new Dictionary<Type, List<GameComponent>> ();
			this.Aspect = new Aspect ();
			this.Transform = transform;
		}

		public void AddGameComponent<T> (T gameComponent) where T : GameComponent
		{
			if (!gameComponents.ContainsKey (typeof(T))) {
				gameComponents [typeof(T)] = new List<GameComponent> ();
			}
			//TODO: CHEECKS!
			gameComponents [typeof(T)].Add (gameComponent as GameComponent);
			Aspect.AddType (typeof(T));
		}

		public void AddToAspect (Type t)
		{
			Aspect.AddType (t);
		}

		public List<GameComponent> GetGameComponentsByType<T> ()
		{
			return gameComponents [typeof(T)];
		}
	}
}

