using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;
using TaleWorlds.Core;
using TaleWorlds.Library;

namespace ChangeClanTier
{
    public class MyClanManagementVM : ClanManagementVM
    {

        public string CurrentTierStr { get; init; }
        public string NextTierStr { get; init; }
        public string KindomLeaderStr { get; init; }
        //是否君主
        [DataSourceProperty]
        public bool IsKindomLeader { get; init; }

        public MyClanManagementVM(Action onClose, Action<Hero> showHeroOnMap, Action<Hero> openPartyAsManage, Action openBannerEditor) : base(onClose, showHeroOnMap, openPartyAsManage, openBannerEditor)
        {

            CurrentTierStr = GameTexts.FindText($"xczg_clan_tier_{CurrentTier}", null).ToString(); 
            NextTierStr = GameTexts.FindText($"xczg_clan_tier_{NextTier}", null).ToString();
            KindomLeaderStr = GameTexts.FindText($"xczg_clan_tier_7", null).ToString();
            IsKindomLeader = Hero.MainHero.IsKingdomLeader;

            GameTexts.SetVariable("TIER", CurrentTierStr);
            CurrentRenownText = GameTexts.FindText("str_clan_tier", null).ToString();
        }


    }
}
