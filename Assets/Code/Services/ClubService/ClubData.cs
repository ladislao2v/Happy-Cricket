using System;
using UnityEngine;

namespace Code.Services.ClubService
{
    [Serializable]
    public class ClubData
    {
        public int IndexLogo { get; }
        public string Name { get; }

        public ClubData(int indexLogo, string name)
        {
            IndexLogo = indexLogo;
            Name = name;
        }
    }
}