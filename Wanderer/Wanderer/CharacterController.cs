using System;
using System.Collections.Generic;

namespace Wanderer
{
	/// <summary>
	/// Контроллер персонажа.
	/// </summary>
	public class CharacterController
	{
		private readonly Character character = new Hero(10, 10);
		
		public CharacterController(List<Point> pointList)
		{
			character.pointList = pointList;
		}
		
		public void Move( ConsoleKey key)
		{
			switch (key) 
			{
				case ConsoleKey.LeftArrow:
					character.Move(Direction.Left);
					break;
				case ConsoleKey.RightArrow:
					character.Move(Direction.Right);
					break;
				case ConsoleKey.UpArrow:
					character.Move(Direction.Up);
					break;
				case ConsoleKey.DownArrow:
					character.Move(Direction.Down);
					break;
				case ConsoleKey.Escape:
					Environment.Exit(0);
					break;
				default:
					character.Move(Direction.Stop);
					break;
			}
		}

		public void Move()
		{
			this.Move( Console.ReadKey(true).Key );
		}
	}
}
