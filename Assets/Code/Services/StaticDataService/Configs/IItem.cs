using UnityEngine;

namespace Code.Services.StaticDataService.Configs
{
    public interface IItemConfig
    {
        Sprite Sprite { get; }
        string Name { get; }
        GameObject Prefab { get; }
        int Price { get; }
    }
}