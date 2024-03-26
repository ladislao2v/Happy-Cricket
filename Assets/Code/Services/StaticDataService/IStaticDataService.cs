using System.Collections.Generic;
using Code.Services.AchievementsService;
using Code.Services.ShopService;
using Code.Services.StaticDataService.Configs;

namespace Code.Services.StaticDataService
{
    public interface IStaticDataService
    {
         ItemConfig[] GetShopItems();
         AchievementConfig[] GetAchievements();
    }
}