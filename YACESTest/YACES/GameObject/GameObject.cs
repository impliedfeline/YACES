using System;
using System.Linq;
using System.Collections.Generic;

namespace YACESTest
{
	public abstract class GameObject
	{
		// May need to add some handle releases
		public GameObject Parent { get; set; }

		public List<GameObject> Children { get; private set; }

		private Dictionary<Type, List<GameComponent>> gameComponents;

		public Aspect Aspect { get; private set; }

		public Transform Transform { get; private set; }

		public uint ID { get; private set; }
		// ID of newest GameObject
		public static uint IDCounter { get; private set; }

		public GameObject (Transform transform)
		{
			this.Children = new List<GameObject> ();
			this.gameComponents = new Dictionary<Type, List<GameComponent>> ();
			this.Aspect = new Aspect ();
			this.Transform = transform;
			this.Transform.Parent = this;
			ID = ++IDCounter;
		}

		public void AddGameComponent<T> (T gameComponent) where T : GameComponent
		{
			if (!gameComponents.ContainsKey (typeof(T))) {
				gameComponents [typeof(T)] = new List<GameComponent> ();
			}
			gameComponent.Parent = this;
			gameComponents [typeof(T)].Add (gameComponent);
			Aspect.AddType<T> ();
		}

		public void RemoveGameComponent<T> (T gameComponent) where T : GameComponent
		{
			if (!gameComponents.ContainsKey (typeof(T)) || !gameComponents [typeof(T)].Contains (gameComponent)) {
				return;
			}
			gameComponents [typeof(T)].Remove (gameComponent);
			if (!gameComponents [typeof(T)].Any ()) {
				Aspect.RemoveType<T> ();
			}
		}

		public void AddToAspect<T> ()
		{
			Aspect.AddType<T> ();
		}

		public List<T> GetGameComponentsByType<T> () where T : GameComponent
		{
			return gameComponents [typeof(T)].Cast<T> ().ToList ();
		}
	}
}

