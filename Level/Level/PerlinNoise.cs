using System;

namespace Level
{
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
