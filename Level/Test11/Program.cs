
using System;
using System.Collections.Generic;

namespace Test11
{
	/// <summary>
	/// Description of Program.
	/// </summary>
	public class Program
	{		
		public static void Main()
		{
			new ConsoleLocal(80, 25);
			
			Chunk chunk = new Chunk(200);
			
			chunk.Draw();
	
			
			while (true) 
			{
				switch (Console.ReadKey(true).Key) 
				{
					case ConsoleKey.LeftArrow:
						chunk.PositionHeroX--;
						chunk.Draw();
						break;
					case ConsoleKey.RightArrow:
						chunk.PositionHeroX++;
						chunk.Draw();
						break;
					case ConsoleKey.UpArrow:
						chunk.PositionHeroY--;
						chunk.Draw();
						break;
					case ConsoleKey.DownArrow:
						chunk.PositionHeroY++;
						chunk.Draw();
						break;
					case ConsoleKey.Escape:
						Environment.Exit(0);
						break;
				}
			}
		}
	}	
	
	class Block
	{
		char symbol = '#';

		public Block(char symbol)
		{
			this.symbol = symbol;			
		}
		
		public void Draw()		
		{
			Console.Write(symbol);
		}
	}
	
	class Column : BaseParam
	{
		public Dictionary<int, Block> blockList = new Dictionary<int, Block>();

		public void Draw( int x = 0)
		{
			int firstKey = this.GetFirstKey();
			int fromY = firstKey + HeightScreen / 2 - PositionHeroY;
			int toY = firstKey + blockList.Count < PositionHeroY * 2 ? blockList.Count : PositionHeroY * 2;		
			
			for (int y = fromY; y <= toY; y++)
			{
				Console.SetCursorPosition(x, y);
				
				blockList[y].Draw();
			}
		}
		
		private int GetFirstKey()
		{
			var enumerator = blockList.GetEnumerator();
			
			enumerator.MoveNext();
			
			return enumerator.Current.Key;
		}
		
		public Column( int y )
		{
			for (int i = y; i <= 100; i++) 
			{
				this.blockList.Add(i, new Block('#') );
			}
		}
	}
	
	class Chunk : BaseParam
	{
		int ChunkSize = 200;
		
		public Dictionary<int, Column> columnList = new Dictionary<int, Column>();
		
		public Chunk(int chunkSize)
		{
			this.ChunkSize = chunkSize;
			
			PerlinNoise perlinNoise = new PerlinNoise(Seed);

			for (int x = 0; x <= chunkSize; x++)
			{
			
				var y = perlinNoise.getNoise(x, 20);				
				
				columnList.Add(x, new Column( y ));
			}
		}
		
		public void Draw()
		{
			Console.Clear();
			int firstKey = this.GetFirstKey();
			int fromX = firstKey + WidthScreen / 2 - PositionHeroX;
			int toX = firstKey + columnList.Count < PositionHeroX * 2 ? columnList.Count : PositionHeroX * 2;
			
			int sad = (WidthScreen / 2 - PositionHeroX) + WidthScreen;
			//toX = sad;				
			for (int x = fromX; x < toX; x++)
			{
				columnList[x].Draw(x);
			}
		}

		private int GetFirstKey()
		{
			var enumerator = columnList.GetEnumerator();
			
			enumerator.MoveNext();
			
			return enumerator.Current.Key;
		}
	}
}
