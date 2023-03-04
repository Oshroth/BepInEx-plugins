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
				__instance.strongerHandsCostText.GetComponent<TextMeshProUGUI>().text = __instance.fakeStrongerHandsCostText.GetComponent<TextMeshProUGUI>().text =
				CoinHelper.FormatCoins(MoreCoinsButton.moreCoinClickValue / PurchaseLog.strongerHandsGetMoreCoins);
				if (MoreCoinsButton.moreCoinsUpgrades > 0)
				{
					__instance.greaterCoinsCostText.GetComponent<TextMeshProUGUI>().text = __instance.fakeGreaterCoinCostText.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(MoreCoinsButton.greaterCoinsCost / PurchaseLog.greaterCoinsGetMoreCoins);
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
					__instance.knowledgeCostText.GetComponent<TextMeshProUGUI>().text = __instance.fakeKnowledgeHandsCostText.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(KnowledgeUpgrade.knowledgeClickValue / PurchaseLog.knowledgePlussAmount);
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
					__instance.fistCostText.GetComponent<TextMeshProUGUI>().text = __instance.fakeFistCostText.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(StrongerFist.fistCost / PurchaseLog.fistPlussAmount);
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
					__instance.injectionButtonCost.GetComponent<TextMeshProUGUI>().text = __instance.fakeInjectionButtonCost.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(HandInecjtion.injectionCost / PurchaseLog.injectionPlussAmount);
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
					__instance.brainPowerButtonCost.GetComponent<TextMeshProUGUI>().text = __instance.fakeBrainPowerButtonCost.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(BrainPower.brainPowerCost / PurchaseLog.brainPowerPlussAmount);
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
					__instance.ExplosiveButtonCost.GetComponent<TextMeshProUGUI>().text = __instance.fakeExplosiveButtonCost.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(ExplosiveFlips.explosiveCost / PurchaseLog.explosiveFlipsPlussAmount);
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
					__instance.hydrationCostText.GetComponent<TextMeshProUGUI>().text = __instance.fakeHydrationCostText.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(HydrationButton.hydrationVost / PurchaseLog.hydrationFlipsPlussAmount);
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

					__instance.potionCostText.GetComponent<TextMeshProUGUI>().text = __instance.fakePotionCostText.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(StrangePotion.potionCost / PurchaseLog.strangePotiongPlussAmount);
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
					__instance.realMasterFlipsCostText.GetComponent<TextMeshProUGUI>().text = __instance.fakeMasterFlipsCostText.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(MasterFlipper.MasterFlipsCost / PurchaseLog.masterFlipsPlussAmount);
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
					__instance.handShakeCostText.GetComponent<TextMeshProUGUI>().text = __instance.fakeHandShakeCostText.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(HandShake.handshakeCost / PurchaseLog.handShakePlussAmount);
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
					__instance.upgrade12CostText.GetComponent<TextMeshProUGUI>().text = __instance.fakeUpgrade12CostText.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(Upgrade12.upgrade12Cost / PurchaseLog.upgrade12Pluss);
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
					__instance.magicUpgradeText.GetComponent<TextMeshProUGUI>().text = __instance.fakeMagicUpgradeText.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(MagicFlipsUpgrade.magicUpgradeCost / PurchaseLog.magicFlipsPluss);
				}
			}
		}

		//Treasure Chest
		[HarmonyPatch(typeof(TreasureChest), "FixedUpdate")]
		[HarmonyPostfix]
		static void TreasureChestUpdate(TreasureChest __instance)
		{
			if (Input.GetKey(KeyCode.LeftShift))
			{
				if (MagicFlipsUpgrade.magicUpgradeCount > 0)
				{
					__instance.treausreCostText.GetComponent<TextMeshProUGUI>().text = __instance.treausreCostText.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(TreasureChest.treasureCost / PurchaseLog.treasureChestPluss);
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
					__instance.ritualCostText.GetComponent<TextMeshProUGUI>().text = __instance.fakeRitualCostText.GetComponent<TextMeshProUGUI>().text =
						CoinHelper.FormatCoins(RitualUpgrade.ritualCost / PurchaseLog.ritualPluss);
				}
			}
		}
	}
}
