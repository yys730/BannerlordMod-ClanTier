using HarmonyLib;
using TaleWorlds.Core;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.ViewModelCollection.ClanManagement;
using TaleWorlds.Core.ViewModelCollection.Tutorial;
using SandBox.GauntletUI;
using System.Reflection;
using System;
using TaleWorlds.CampaignSystem.ViewModelCollection;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace ChangeClanTier;

[HarmonyPatch]
[HarmonyDebug]
public class ClanTierPatch
{

    // VM 类构造函数的参数类型列表
    private static readonly Type[] _vmCtorParamTypes = new Type[]
    {
        typeof(Action), typeof(Action<Hero>),typeof(Action<Hero>),typeof(Action)
    };

    // 获取原版VM和新VM的构造函数信息
    private static readonly ConstructorInfo _clanManagementVMCtor = typeof(ClanManagementVM).GetConstructor(_vmCtorParamTypes);
    private static readonly ConstructorInfo _myClanManagementVMCtor = typeof(MyClanManagementVM).GetConstructor(_vmCtorParamTypes);

    [HarmonyPatch(typeof(GauntletClanScreen), "TaleWorlds.Core.IGameStateListener.OnActivate")]
    static IEnumerable<CodeInstruction> Transpiler(IEnumerable<CodeInstruction> instructions)
    {
        foreach (CodeInstruction instruction in instructions)
        {
            OpCode opcode = instruction.opcode;
            var operand = instruction.operand;
            if (opcode == OpCodes.Newobj && (operand as ConstructorInfo) == _clanManagementVMCtor)
            {
                Console.WriteLine("111");
                yield return new CodeInstruction(OpCodes.Newobj, _myClanManagementVMCtor);
            }
            else
            {
                yield return instruction;
            }


        }
    }


    /**
     * 改变家族页面右上角进度条上面的 " 家族名称:" 后面的字段
     */
    [HarmonyPostfix, HarmonyPatch(typeof(ClanManagementVM), nameof(ClanManagementVM.RefreshValues))]
    public static void ClanManagementVM_RefreshValues_Postfix(MyClanManagementVM __instance)
    {
        GameTexts.SetVariable("TIER", __instance.CurrentTierStr);
        __instance.CurrentRenownText = GameTexts.FindText("str_clan_tier", null).ToString();
        ElementNotificationVM tutorialNotification = __instance.TutorialNotification;

    }

    /**
     * 替换ClanManagementVM到GauntletClanScreen里进行初始化
     */
    //[HarmonyPostfix, HarmonyPatch(typeof(GauntletClanScreen), nameof(IGameStateListener.OnActivate))]
    //public static void GauntletClanScreen_OnActivate_Postfix(GauntletClanScreen __instance, ClanManagementVM ____dataSource)
    //{
    //    //____dataSource = new ClanManagementVM(new Action(__instance.CloseClanScreen), new Action<Hero>(this.ShowHeroOnMap), new Action<Hero>(this.OpenPartyScreenForNewClanParty), new Action(this.OpenBannerEditorWithPlayerClan));
    //}


    /**
    // * 进度条及两旁的字段
    // */
    //[HarmonyPostfix, HarmonyPatch(typeof(ClanScreen__TaleWorlds_CampaignSystem_ViewModelCollection_ClanManagement_ClanManagementVM), "CreateWidgets")]
    //public static void ClanManagementVM_HandleViewModelPropertys_Postfix(TextWidget ____widget_4_0_7_1_0, AutoHideZeroTextWidget ____widget_4_0_7_1_2, ListPanel ____widget_4_0_7_1)
    //{
    //    ____widget_4_0_7_1.RemoveAllChildren();

    //    //var leftWidget = new TextWidget(base.Context);
    //    //leftWidget.Text = strArray[____widget_4_0_7_1_2.IntText];


    //    //____widget_4_0_7_1.AddChild(leftWidget);
    //    ____widget_4_0_7_1.AddChild(____widget_4_0_7_1_0);
    //    ____widget_4_0_7_1.AddChild(____widget_4_0_7_1_2);

    //}


    /*
     * 家族升级弹出的通知
     */
    //[HarmonyPrefix, HarmonyPatch(typeof(DefaultNotificationsCampaignBehavior), "OnClanTierIncreased")]
    //public static bool Prefix(Clan clan, bool shouldNotify = true)
    //{
    //    Console.WriteLine("1111");
    //    if (shouldNotify && clan == Clan.PlayerClan)
    //    {
    //        MBTextManager.SetTextVariable("CLAN", clan.Name, false);
    //        MBTextManager.SetTextVariable("TIER_LEVEL", clan.Tier);
    //        MBInformationManager.AddQuickInformation(
    //            new TextObject("1111111111111", null), 0, null, "");
    //    }
    //    return false;

    //}

}
