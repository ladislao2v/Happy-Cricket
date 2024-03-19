using Code.Services.ShopService;
using Code.Services.StaticDataService.Configs;

namespace Code.Services.StaticDataService
{
    public interface IStaticDataService
    {
         IItemConfig[] GetShopItems();
    }
}