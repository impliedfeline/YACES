using System;
using System.Collections.Generic;

namespace YACESTest
{
	public class AspectMap
	{
		private Dictionary<Aspect, HashSet<GameObject>> gameObjectsByAspect;

		public AspectMap ()
		{
			gameObjectsByAspect = new Dictionary<Aspect,HashSet<GameObject>> ();
		}
		// This is painfully slow; one trivial way to make this O(1) would be to store references to
		// gameObjects in all the possible permutations of aspects. We'll see how this pans out
		public List<GameObject> GetGameObjectsByAspect (Aspect aspect)
		{
			List<GameObject> gameObjects = new List<GameObject> ();
			foreach (Aspect item in gameObjectsByAspect.Keys) {
				if (aspect.SubsetOf (item))
					gameObjects.AddRange (gameObjectsByAspect [item]);
			}
			return gameObjects;
		}
		// Consider above comment
		public void AddGameObject (GameObject go)
		{
			if (!gameObjectsByAspect.ContainsKey (go.Aspect)) {
				gameObjectsByAspect [go.Aspect] = new HashSet<GameObject> ();
			}
			gameObjectsByAspect [go.Aspect].Add (go);
		}
		// Would make this a lot slower then...
		public void RemoveGameObject (GameObject go)
		{
			if (!gameObjectsByAspect.ContainsKey (go.Aspect)) {
				return;
			}
			gameObjectsByAspect [go.Aspect].Remove (go);
		}
	}
}
