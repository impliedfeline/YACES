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

			Vector3 z = new Vector3 (0, 0, 0);
			AddGameObject (new Player (new Transform (z, z, z)));
			AddGameSystem (new PlayerScriptSystem ());
			AddGameSystem (new PlayerControllerSystem ());
		}
	}
}

