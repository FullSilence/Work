/*
 * Создано в SharpDevelop.
 * Пользователь: khromov
 * Дата: 14.09.2016
 * Время: 10:10
 * 
 * Для изменения этого шаблона используйте меню "Инструменты | Параметры | Кодирование | Стандартные заголовки".
 */
using System;

namespace Wanderer
{
	/// <summary>
	/// Description of PerlinNoise.
	/// </summary>
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
