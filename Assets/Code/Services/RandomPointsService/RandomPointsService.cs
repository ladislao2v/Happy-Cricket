using UnityEngine;

namespace Code.Services.RandomPointsService
{
    public class RandomPointsService : IRandomPointsService
    {
        private readonly int _min = 1;
        private readonly int _max = 3;
        
        public int Get() => 
            Random.Range(_min, _max);
    }
}