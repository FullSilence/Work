
using System;

namespace Test11
{	
	/// <summary>
	/// Базовые параметры.
	/// </summary>
	abstract class BaseParam
	{
		#region Поля
		
		private int positionHeroY = 12;
		private int positionHeroX = 40;
		
		private int heightScreen = 24;
		private int widthScreen = 80;
		
		private	long seed	= 186135498L;

		#endregion
		
		#region	Свойства
		
		/// <summary>
		/// Координата Y персонажа
		/// </summary>
		public int PositionHeroY 
		{
			get 
			{
				return positionHeroY;
			}
			set 
			{
				positionHeroY = value;
			}
		}

		/// <summary>
		/// Координата X персонажа
		/// </summary>
		public int PositionHeroX 
		{
			get 
			{
				return positionHeroX;
			}
			set 
			{
				positionHeroX = value;
			}
		}

		/// <summary>
		/// Высота экрана
		/// </summary>
		public int HeightScreen 
		{
			get 
			{
				return heightScreen;
			}
			set 
			{
				heightScreen = value;
			}
		}

		/// <summary>
		/// Ширина экрана
		/// </summary>
		public int WidthScreen 
		{
			get 
			{
				return widthScreen;
			}
			set 
			{
				widthScreen = value;
			}
		}
		
		public long Seed 
		{
			get 
			{
				return seed;
			}
			set 
			{
				seed = value;
			}
		}

		#endregion
	}
}
