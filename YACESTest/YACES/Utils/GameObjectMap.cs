using System;
using System.Collections.Generic;

namespace YACESTest
{
	public class GameObjectMap
	{
		private Dictionary<uint, GameObject> gameObjectsByID;
		private Dictionary<Aspect, HashSet<GameObject>> gameObjectsByAspect;

		public GameObjectMap ()
		{
			gameObjectsByID = new Dictionary<uint,GameObject> ();
			gameObjectsByAspect = new Dictionary<Aspect,HashSet<GameObject>> ();
		}

		public List<GameObject> GetGameObjectsByAspect (Aspect aspect)
		{
			List<GameObject> gameObjects = new List<GameObject> ();
			foreach (Aspect item in gameObjectsByAspect.Keys) {
				if (aspect.SubsetOf (item))
					gameObjects.AddRange (gameObjectsByAspect [item]);
			}
			return gameObjects;
		}

		public GameObject GetGameObjectByID (uint id)
		{
			return gameObjectsByID [id];
		}

		public void AddGameObject (GameObject go)
		{
			if (!gameObjectsByAspect.ContainsKey (go.Aspect)) {
				gameObjectsByAspect.Add (go.Aspect, new HashSet<GameObject> ());
			}
			gameObjectsByID.Add (go.ID, go);
			gameObjectsByAspect [go.Aspect].Add (go);
		}

		public void RemoveGameObject (GameObject go)
		{
			if (!gameObjectsByAspect.ContainsKey (go.Aspect)) {
				return;
			}
			gameObjectsByID.Remove (go.ID);
			gameObjectsByAspect [go.Aspect].Remove (go);
		}
	}
}
