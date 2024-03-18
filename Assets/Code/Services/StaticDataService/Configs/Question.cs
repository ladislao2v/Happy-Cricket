using System;
using UnityEngine;

namespace Code.Services.StaticDataService.Configs
{
    [Serializable]
    public class Question
    {
        [SerializeField] private ClubData _answer;
        [SerializeField] private ClubData[] _otherVariants;

        public ClubData Answer => _answer;
        public ClubData[] Other => _otherVariants;
    }
}