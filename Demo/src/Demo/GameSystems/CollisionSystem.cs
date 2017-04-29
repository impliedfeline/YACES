using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace YACES
{
	public class CollisionSystem : GameSystem
	{
		public CollisionSystem () : base ()
		{
		}

		public override void Run (GameInstance gameInstance, GameTime gameTime)
		{
			IReadOnlyList<GameObject> collideables = gameInstance.GameObjects.GetGameObjectsByComponent<Hitbox2D> ();
			foreach (GameObject go in collideables) {
				foreach (GameObject other in collideables) {
					if (go != other) {
						Rectangle r1 = go.GetGameComponentsByType<Hitbox2D> () [0].Collider;
						Rectangle r2 = other.GetGameComponentsByType<Hitbox2D> () [0].Collider;
						if (r1.Intersects (r2)) {
							if (go is Block && (other is Player || other is ChildTest)) {
								gameInstance.GameObjects.RemoveGameObject (go);
							} else if (other is Block && (go is Player || go is ChildTest)) {
								gameInstance.GameObjects.RemoveGameObject (other);
							}
						}
					}
				}
			}
		}
	}
}

