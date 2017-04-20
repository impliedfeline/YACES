using System;

namespace YACESTest
{
	public class TestScene : GameScene
	{
		public TestScene ()
		{
			AddGameSystem (new CreationSystem (0));
			AddGameSystem (new BlockGeneratorSystem (2));
			AddGameSystem (new BlockDestroySystem (1));
			AddGameSystem (new GravitySystem (2));
		}
	}
}

