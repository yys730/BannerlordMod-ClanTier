using System;
using HarmonyLib;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using TaleWorlds.Core;
using TaleWorlds.Core.ViewModelCollection.Generic;
using TaleWorlds.Localization;
using TaleWorlds.MountAndBlade;


namespace ChangeClanTier
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnSubModuleLoad()
        {
            base.OnSubModuleLoad();
            new Harmony("cct").PatchAll();
        }

        protected override void OnSubModuleUnloaded()
        {
            base.OnSubModuleUnloaded();
        }

        protected override void OnBeforeInitialModuleScreenSetAsRoot()
        {
            base.OnBeforeInitialModuleScreenSetAsRoot();
        }

        //[HarmonyPostfix, HarmonyPatch(typeof(CampaignUIHelper), nameof(CampaignUIHelper.GetCharacterTierData), new Type[] { typeof(CharacterObject), typeof(bool) })]
        //public static void CampaignUIHelper_GetCharacterTierData_Postfix()
        //{
        //    Console.WriteLine("aaa");
        //}

        //[HarmonyPrefix, HarmonyPatch(typeof(CampaignUIHelper), nameof(CampaignUIHelper.GetCharacterTierData))]
        //public static bool CampaignUIHelper_GetCharacterTierData_Prefix(ref StringItemWithHintVM __result, CharacterObject character, bool isBig)
        //{
        //    var tier = character.Tier;
        //    if (tier is <= 0 or > 7)
        //    {
        //        __result = new StringItemWithHintVM("", TextObject.Empty);
        //    }
        //    else
        //    {
        //        var text = (isBig ? (tier.ToString() + "_big") : tier.ToString());
        //        var text2 = "General\\TroopTierIcons\\icon_tier_" + text;
        //        GameTexts.SetVariable("TIER_LEVEL", tier);
        //        var textObject =
        //            new TextObject("{=!}" + GameTexts.FindText("str_party_troop_tier", null).ToString(), null);
        //        __result = new StringItemWithHintVM(text2, textObject);
        //    }
        //    return false;

        //}
    }
}