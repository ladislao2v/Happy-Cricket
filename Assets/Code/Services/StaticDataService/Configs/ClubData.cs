using System;
using UnityEngine;

namespace Code.Services.StaticDataService.Configs
{
    [CreateAssetMenu(menuName = "Create ClubData", fileName = "ClubData", order = 0)]
    public class ClubData : ScriptableObject
    {
        [SerializeField] private string _name;
        [SerializeField] private Sprite _logo;

        public string Name => _name;
        public Sprite Logo => _logo;
    }
}