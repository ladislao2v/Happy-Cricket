using Code.Services.SkinService;
using UnityEngine;

namespace Code.Services.StaticDataService.Configs
{
    public interface IItemConfig
    {
        Sprite Sprite { get; }
        string Name { get; }
        Skin Prefab { get; }
        int Price { get; }
        Sprite Background { get; }
    }
}