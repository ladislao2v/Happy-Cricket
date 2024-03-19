using UnityEngine;

namespace Code.Services.StaticDataService.Configs
{
    [CreateAssetMenu(fileName = "new Item", menuName = "Shop", order = 0)]
    public class ItemConfig : ScriptableObject, IItemConfig
    {
        [field:SerializeField] public Sprite Sprite { get; private set; }
        [field:SerializeField] public string Name { get; private set; }
        [field:SerializeField] public int Price { get; private set; }
        [field:SerializeField] public GameObject Prefab { get; private set; }
    }
}