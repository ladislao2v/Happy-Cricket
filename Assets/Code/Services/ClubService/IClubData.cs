using UnityEngine;

namespace Code.Services.ClubService
{
    public interface IClubData
    {
        Sprite Logo { get; }
        string Name { get; }
    }
}