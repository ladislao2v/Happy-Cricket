using System.Collections.Generic;
using UnityEngine;

namespace Code.Services.StaticDataService.Configs
{
    [CreateAssetMenu(menuName = "Create ChampionshipData", fileName = "ChampionshipData", order = 0)]
    public class ChampionshipData : ScriptableObject
    {
        [SerializeField] private int _level;
        [SerializeField] private string _name;
        [SerializeField] private Sprite _logo;
        [SerializeField] private Question[] _questions;

        public int Level => _level;
        public string Name => _name;
        public Sprite Logo => _logo;
        public Question[] Questions => _questions;
    }
}