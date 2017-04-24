using System;
using Microsoft.Xna.Framework;

namespace YACESTest
{
	public class TestScene : GameScene
	{
		public TestScene ()
		{
			AddGameSystem (new CreationSystem ());
			AddGameSystem (new BlockGeneratorSystem ());
			AddGameSystem (new BlockDestroySystem ());
			AddGameSystem (new GravitySystem ());

			Vector3 z = Vector3.Zero;
			Vector3 s = Vector3.One;
			Player p = new Player (new Transform (new Vector3 (600, 500, 0), s, z));
			AddGameObject (p);

			ChildTest c1 = new ChildTest (new Transform (new Vector3 (128, 0, 0), s, z));
			ChildTest c2 = new ChildTest (new Transform (new Vector3 (-128, 0, 0), s, z));
			p.Attach (c1);
			p.Attach (c2);
			AddGameObject (c1);
			AddGameObject (c2);


			AddGameSystem (new PlayerScriptSystem ());
			AddGameSystem (new PlayerControllerSystem ());
		}
	}
}

