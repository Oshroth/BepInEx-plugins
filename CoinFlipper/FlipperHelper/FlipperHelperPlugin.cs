using BepInEx;
using HarmonyLib;
using TMPro;
using UnityEngine;

namespace FlipperHelper
{
	[BepInPlugin("oshroth.flipperhelper", PluginInfo.PLUGIN_NAME, PluginInfo.PLUGIN_VERSION)]
	[BepInProcess("Coin Flipper.exe")]
	public class FlipperHelperPlugin : BaseUnityPlugin
	{
		private void Awake()
		{
			// Plugin startup logic
			Harmony.CreateAndPatchAll(typeof(FlipperHelperPlugin));
			Logger.LogInfo($"Plugin oshroth.flipperhelper is loaded!");
		}

		// More Coins & Greater Coin
		[HarmonyPatch(typeof(MoreCoinsButton), "Update")]
		[HarmonyPostfix]
		static void MoreCoinsUpdate(MoreCoinsButton __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				__instance.strongerHandsCostText.text = __instance.fakeStrongerHandsCostText.text =
				MoreCoinsButton.FormatCoins(MoreCoinsButton.moreCoinClickValue / PurchaseLog.strongerHandsGetMoreCoins);
				if (MoreCoinsButton.moreCoinsUpgrades > 0)
				{
					__instance.greaterCoinsCostText.text = __instance.fakeGreaterCoinCostText.text =
						MoreCoinsButton.FormatCoins(MoreCoinsButton.greaterCoinsCost / PurchaseLog.greaterCoinsGetMoreCoins);
				}
			}
		}

		//Knowledge
		[HarmonyPatch(typeof(KnowledgeUpgrade), "Update")]
		[HarmonyPostfix]
		static void KnowledgeUpgradeUpdate(KnowledgeUpgrade __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (MoreCoinsButton.greaterCoinsCount > 0)
				{
					__instance.knowledgeCostText.text = __instance.fakeKnowledgeHandsCostText.text =
						KnowledgeUpgrade.FormatCoins(KnowledgeUpgrade.knowledgeClickValue / PurchaseLog.knowledgePlussAmount);
				}
			}
		}

		//Stronger Fist
		[HarmonyPatch(typeof(StrongerFist), "Update")]
		[HarmonyPostfix]
		static void StrongerFistUpdate(StrongerFist __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (KnowledgeUpgrade.knowledgeUpgradeCount > 0)
				{
					__instance.fistCostText.text = __instance.fakeFistCostText.text =
						StrongerFist.FormatCoins(StrongerFist.fistCost / PurchaseLog.fistPlussAmount);
				}
			}
		}

		// Hand Injection
		[HarmonyPatch(typeof(HandInecjtion), "Update")]
		[HarmonyPostfix]
		static void HandInecjtionUpdate(HandInecjtion __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (StrongerFist.fistUpgradeCount > 0)
				{
					__instance.injectionButtonCost.text = __instance.fakeInjectionButtonCost.text =
						HandInecjtion.FormatCoins(HandInecjtion.injectionCost / PurchaseLog.injectionPlussAmount);
				}
			}
		}

		//Brain Power
		[HarmonyPatch(typeof(BrainPower), "Update")]
		[HarmonyPostfix]
		static void BrainPowerUpdate(BrainPower __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (HandInecjtion.injectionUpgradeCount > 0)
				{
					__instance.brainPowerButtonCost.text = __instance.fakeBrainPowerButtonCost.text =
						BrainPower.FormatCoins(BrainPower.brainPowerCost / PurchaseLog.brainPowerPlussAmount);
				}
			}
		}

		//Explosive Flips
		[HarmonyPatch(typeof(ExplosiveFlips), "Update")]
		[HarmonyPostfix]
		static void ExplosiveFlipsUpdate(ExplosiveFlips __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (BrainPower.brainPowerUpgradeCount > 0)
				{
					__instance.ExplosiveButtonCost.text = __instance.fakeExplosiveButtonCost.text =
						ExplosiveFlips.FormatCoins(ExplosiveFlips.explosiveCost / PurchaseLog.explosiveFlipsPlussAmount);
				}
			}
		}

		//Hydration
		[HarmonyPatch(typeof(HydrationButton), "Update")]
		[HarmonyPostfix]
		static void HydrationButtonUpdate(HydrationButton __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (ExplosiveFlips.explosiveUpgradeCount > 0)
				{
					__instance.hydrationCostText.text = __instance.fakeHydrationCostText.text =
						HydrationButton.FormatCoins(HydrationButton.hydrationVost / PurchaseLog.hydrationFlipsPlussAmount);
				}
			}
		}

		//Strange Potion
		[HarmonyPatch(typeof(StrangePotion), "Update")]
		[HarmonyPostfix]
		static void StrangePotionUpdate(StrangePotion __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (HydrationButton.hydrationUpgradeCount > 0)
				{

					__instance.potionCostText.text = __instance.fakePotionCostText.text =
						StrangePotion.FormatCoins(StrangePotion.potionCost / PurchaseLog.strangePotiongPlussAmount);
				}
			}
		}

		//Master Flipper
		[HarmonyPatch(typeof(MasterFlipper), "Update")]
		[HarmonyPostfix]
		static void MasterFlipperUpdate(MasterFlipper __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (StrangePotion.potionUpgradeCount > 0)
				{
					__instance.realMasterFlipsCostText.text = __instance.fakeMasterFlipsCostText.text =
						MasterFlipper.FormatCoins(MasterFlipper.MasterFlipsCost / PurchaseLog.masterFlipsPlussAmount);
				}
			}
		}

		//Handshake
		[HarmonyPatch(typeof(HandShake), "Update")]
		[HarmonyPostfix]
		static void HandShakeUpdate(HandShake __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (MasterFlipper.MasterFlipsUpgradeCount > 0)
				{
					__instance.handShakeCostText.text = __instance.fakeHandShakeCostText.text =
						HandShake.FormatCoins(HandShake.handshakeCost / PurchaseLog.handShakePlussAmount);
				}
			}
		}

		//High Five
		[HarmonyPatch(typeof(Upgrade12), "Update")]
		[HarmonyPostfix]
		static void Upgrade12Update(Upgrade12 __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (HandShake.handShakeUpgradeCount > 0)
				{
					__instance.upgrade12CostText.text = __instance.fakeUpgrade12CostText.text =
						Upgrade12.FormatCoins(Upgrade12.upgrade12Cost / PurchaseLog.upgrade12Pluss);
				}
			}
		}

		//Magic Flips
		[HarmonyPatch(typeof(MagicFlipsUpgrade), "Update")]
		[HarmonyPostfix]
		static void MagicFlipsUpgradeUpdate(MagicFlipsUpgrade __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (Upgrade12.upgrade12Count > 0)
				{
					__instance.magicUpgradeText.text = __instance.fakeMagicUpgradeText.text =
						MagicFlipsUpgrade.FormatCoins(MagicFlipsUpgrade.magicUpgradeCost / PurchaseLog.magicFlipsPluss);
				}
			}
		}

		//Treasure Chest
		[HarmonyPatch(typeof(TreasureChest), "Update")]
		[HarmonyPostfix]
		static void TreasureChestUpdate(TreasureChest __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (MagicFlipsUpgrade.magicUpgradeCount > 0)
				{
					__instance.treausreCostText.text = __instance.fakeTreausreCostText.text =
						TreasureChest.FormatCoins(TreasureChest.treasureCost / PurchaseLog.treasureChestPluss);
				}
			}
		}

		//Coin Flipping Ritual
		[HarmonyPatch(typeof(RitualUpgrade), "Update")]
		[HarmonyPostfix]
		static void RitualUpgradeUpdate(RitualUpgrade __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (TreasureChest.treasureCount > 0)
				{
					__instance.ritualCostText.text = __instance.fakeRitualCostText.text =
						RitualUpgrade.FormatCoins(RitualUpgrade.ritualCost / PurchaseLog.ritualPluss);
				}
			}
		}
	}
}
