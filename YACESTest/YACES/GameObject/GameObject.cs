using System;
using System.Collections.Generic;

namespace YACESTest
{
	public abstract class GameObject
	{
		private Dictionary<string, List<GameComponent>> eventComponentMap;

		public GameObject (List<GameComponent> gameComponents) {
			foreach (GameComponent gc in gameComponents) {
				foreach (string hashID in gc.EventHashIDs) {
					if (!eventComponentMap.ContainsKey (hashID)) {
						eventComponentMap.Add(hashID, new List<GameComponent>());
					}
					eventComponentMap [hashID].Add (gc);
				}
			}
		}

		public void OnEvent(GameEvent e) {
			if (eventComponentMap.ContainsKey(e.HashID)) {
				eventComponentMap [e.HashID].ForEach (g => g.OnEvent (e));
			}
		}
	}
}

