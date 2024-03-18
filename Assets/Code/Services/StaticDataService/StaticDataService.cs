using System;
using System.Collections.Generic;
using System.Linq;
using Code.Services.StaticDataService.Configs;
using UnityEngine;

namespace Code.Services.StaticDataService
{
    public class StaticDataService : IStaticDataService
    {
        private const string ChampionshipsPath = "Championships";
        
        private readonly Dictionary<int, ChampionshipData> _configs;

        public StaticDataService() =>
            _configs = Resources
                .LoadAll<ChampionshipData>(ChampionshipsPath)
                .ToDictionary(x => x.Level, x => x);

        public ChampionshipData GetChampionship(int level)
        {
            if (_configs.ContainsKey(level) == false)
                throw new ArgumentException(nameof(level));
            
            return _configs[level];
        }
    }
}