using System;

namespace Level
{
	class Point
	{
		#region Поля
		
		private int x;
		private int y;
		
		#endregion
		
		#region Свойства
		
		public int X 
		{
			get 
			{
				return x;
			}
			set 
			{
				x = value;
			}
		}

 		public int Y
		{
			get 
			{
				return y;
			}
			set 
			{
				y = value;
			}
		}

		#endregion
 		
		public Point()
		{
			
		}
		
		public Point(int x, int y)
		{
			this.X = x;
			this.Y = y;			
		}
		
		public void Draw()
		{
			Console.SetCursorPosition(x,y);
			Console.Write('#');
 		}		
	}
}
