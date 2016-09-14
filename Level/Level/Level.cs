using System;
using System.Collections.Generic;

namespace Level
{
	/// <summary>
	/// Description of Level.
	/// </summary>
	public class Level
	{
		private static long seed = 14148654L;
		
		private IDictionary<Point, Block> level = new Dictionary<Point, Block>();		
		private PerlinNoise perlinNoise = new PerlinNoise( seed );

		Column column;
		Columns columns = new Columns();

		
		public long Seed {
			get {
				return seed;
			}
			set {
				seed = value;
			}
		}
		
		public static void Main()
		{
			ConsoleLocal c = new ConsoleLocal(80, 25);
			
			Level Level = new Level();
			
			Level.Draw( new Point(40,5) );
			
			Console.ReadLine();
		}
		
		public Level()
		{
			int y1;
			
			Point coordinate;
			Block block;
			
			for (int x = 0; x < 200; x++) 
			{
				column = new Column();

				y1 = perlinNoise.getNoise(x, 20);
				
				for (int y = y1; y < 15; y++) 
				{
					coordinate = new Point(x, 10 + y);
					
					block = new Block( coordinate, TypeBlock.Dirt, 100, 1);
			
					column.BlockList.Add(y, block);
				}
				columns.ColumnsList.Add(x, column);
			}
		}
		
		void Draw( Point position )
		{
			Column c;
         	int widht = 24 / 2 - 1; //ToDo: Добавить параметр
         	int heigh = 80 / 2 - 1; //ToDo: Добавить параметр
		    
			for (int x = 0; x < position.X; x++) 
			{
				c = columns.GetColumn(x);
				
				foreach (var block in c.BlockList) 
				{
					block.Value.Location.Draw();
				}
			}
		}
	}	
	
	class Columns
	{
		public Dictionary< int, Column > ColumnsList = new Dictionary<int, Column>();
		
		public Column GetColumn(int x)
		{
			return ColumnsList[x];
		}
		public Block GetBlock(int x, int y)
		{
			return ColumnsList[x].BlockList[y];
		}
	};
		
	class Column
	{
		public Dictionary< int, Block > BlockList = new Dictionary<int, Block>();
	}	
	
	
	enum TypeBlock
	{
		Dirt,
		Grass,
		Stone,
		Ore,
		Oil			
	}
	
	

}
