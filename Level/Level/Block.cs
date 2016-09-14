using System;

namespace Level
{
	class Block
	{
		#region Поля

		private Point location;			// Координаты блока
		
		private int size;				// Размер блока
		
		private TypeBlock blockType;	// Тип блока
		
		private int integrality; 		// Целостность

		#endregion
		
		#region Свойства

		/// <summary>
		/// Координаты блока
		/// </summary>
		public Point Location {
			get {
				return location;
			}
			set {
				location = value;
			}
		}

		/// <summary>
		/// Размер блока
		/// </summary>
		public int Size {
			get {
				return size;
			}
			set {
				size = value;
			}
		}

		/// <summary>
		/// Тип блока
		/// </summary>
		public TypeBlock BlockType {
			get {
				return blockType;
			}
			set {
				blockType = value;
			}
		}

		/// <summary>
		/// Целостность блока
		/// </summary>
		public int Integrality {
			get {
				return integrality;
			}
			set {
				integrality = value;
			}
		}

		#endregion
		
		public Block(Point location, TypeBlock blockType, int integrality, int size = 4)
		{
			if (location == null)
				throw new ArgumentNullException("location", "Координаты блока должны быть заданы.");
			
			this.location 		= location;
			this.blockType 		= blockType;
			this.integrality 	= integrality;
			this.size 			= size;			
		}
	}
}
