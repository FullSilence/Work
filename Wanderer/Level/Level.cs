using System;
using System.Collections.Generic;

namespace Level
{
	public class Level
	{
		#region WinAPI

		static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
		static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
		static readonly IntPtr HWND_TOP = new IntPtr(0);
		const UInt32 SWP_NOSIZE = 0x0001;
		const UInt32 SWP_NOMOVE = 0x0002;
		const UInt32 SWP_NOZORDER = 0x0004;
		const UInt32 SWP_NOREDRAW = 0x0008;
		const UInt32 SWP_NOACTIVATE = 0x0010;
		const UInt32 SWP_FRAMECHANGED = 0x0020;
		const UInt32 SWP_SHOWWINDOW = 0x0040;
		const UInt32 SWP_HIDEWINDOW = 0x0080;
		const UInt32 SWP_NOCOPYBITS = 0x0100;
		const UInt32 SWP_NOOWNERZORDER = 0x0200;
		const UInt32 SWP_NOSENDCHANGING = 0x0400;
		
		[System.Runtime.InteropServices.DllImport("user32.dll")]
		 static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);		

		 #endregion
		
		[STAThread]		
		public static void Main(string[] args)
		{
			IntPtr ConsoleHandle = System.Diagnostics.Process.GetCurrentProcess().MainWindowHandle;
			const UInt32 WINDOW_FLAGS = SWP_SHOWWINDOW;
			SetWindowPos(ConsoleHandle, HWND_NOTOPMOST, 2000, 100, 700, 350, WINDOW_FLAGS);

 			Console.SetBufferSize(80, 25);
 			var perlin2d = new Perlin2d( 23424234 );

 			List<Point> pointList = new List<Point>(); 			
 			
 			PerlinNoise perlinNoise = new PerlinNoise( 11223456L );
 									
 			for (int x = 1; x < 80; x++) 
 			{
 				pointList.Add( new Point( x, perlinNoise.getNoise(x, 24 ) ) );
 				
 			}
 			
			foreach (var point in pointList) 
			{
				point.Draw();
			}
			
 			Console.ReadLine();
		}
	}
	
	class Point
	{
		public int x;
		public int y;
		
		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;			
		}
		
		public void Draw()
		{
			Console.SetCursorPosition(x,y);
			Console.Write('*');
 		}
	}
		
 	public class PerlinNoise
    {
        public long Seed;

        public PerlinNoise(long seed)
        {
            this.Seed = seed;
        }

        public int getNoise(int x, int range)
        {
            int chunkSize = 16;

            float noise = 0;

            if (x == 0)
            	x++;
            
            range /= 2;

            while (chunkSize > 0)
            {
                int chunkIndex = x / chunkSize;

                float progress = (x % chunkSize) / (chunkSize * 1f);

                float left_random = random(chunkIndex, range);
                float right_random = random(chunkIndex + 1, range);

                noise += (1 - progress) * left_random + progress * right_random;

                chunkSize /= 2;
                range /= 2;

                range = Math.Max(1, range);
            }
            return (int)Math.Round(noise);
        }

        private int random(int x, int range)
        {
            return (int)((x + Seed) ^ 5) % range;
        }
    }	
}
