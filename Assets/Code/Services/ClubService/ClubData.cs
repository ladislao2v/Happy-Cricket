using System;
using UnityEngine;

namespace Code.Services.ClubService
{
    [Serializable]
    public class ClubData : IClubData
    {
        public Sprite Logo { get; }
        public string Name { get; }

        public ClubData(Sprite logo, string name)
        {
            Logo = logo;
            Name = name;
        }
    }
}