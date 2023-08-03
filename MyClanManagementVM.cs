using System;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;
using TaleWorlds.Core;

namespace ChangeClanTier
{
    public class MyClanManagementVM : ClanManagementVM
    {
        public MyClanManagementVM(Action onClose, Action<Hero> showHeroOnMap, Action<Hero> openPartyAsManage, Action openBannerEditor) : base(onClose, showHeroOnMap, openPartyAsManage, openBannerEditor)
        {
            Console.WriteLine("yys MyClanManagementVM used");
        }

        //是否君主
        public bool isKindomLeader
        {
            get
            {
                return !Hero.MainHero.IsKingdomLeader;
            }
        }

        public string CurrentTierStr
        {
            get
            {
                return GameTexts.FindText($"yys_clan_tier_{CurrentTier}", null).ToString();
            }

        }
        public string NextTierStr
        {
            get
            {
                return GameTexts.FindText($"yys_clan_tier_{NextTier}", null).ToString();
            }
        }
        public string KindomLeaderStr
        {
            get
            {
                return GameTexts.FindText($"yys_clan_tier_6", null).ToString();
            }

        }
    }
}
