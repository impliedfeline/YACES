using System;
using Microsoft.Xna.Framework;

namespace YACES
{
	public class TestScene : GameScene
	{
		public TestScene ()
		{
			AddGameSystem (new BlockGeneratorSystem ());
			AddGameSystem (new BlockDestroySystem ());
			AddGameSystem (new GravitySystem ());
			AddGameSystem (new CollisionSystem ());

			Vector3 z = Vector3.Zero;
			Vector3 s = Vector3.One;
			Player p = new Player (new Transform (new Vector3 (600, 500, 0), z, s));
			GameObjects.AddGameObject (p);

			ChildTest c1 = new ChildTest (new Transform (new Vector3 (128, 0, 0), z, s));
			ChildTest c2 = new ChildTest (new Transform (new Vector3 (-128, 0, 0), z, s));
			c1.AttachTo (p);
			c2.AttachTo (p);
			GameObjects.AddGameObject (c1);
			GameObjects.AddGameObject (c2);


			AddGameSystem (new PlayerScriptSystem ());
			AddGameSystem (new PlayerControllerSystem ());
		}
	}
}

