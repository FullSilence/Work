
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
	
			Console.ReadKey(true);
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
		
		public Column()
		{
			for (int y = 4; y <= 100; y++) 
			{
				this.blockList.Add(y, new Block('#') );
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
			
			for (int x = 0; x < chunkSize; x++) 
			{
				columnList.Add(x, new Column());
			}
		}
		
		public void Draw()
		{
			int firstKey = this.GetFirstKey();
			int fromX = firstKey + WidthScreen / 2 - PositionHeroX;
			int toX = firstKey + columnList.Count < PositionHeroX * 2 ? columnList.Count : PositionHeroX * 2;

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
