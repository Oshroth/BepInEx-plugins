using BepInEx;
using BepInEx.Configuration;
using BepInEx.IL2CPP;
using HarmonyLib;
using Reactor;
using UnityEngine;

namespace DisableLobbyShake {

    [BepInAutoPlugin]
    [BepInProcess("Among Us.exe")]
    [BepInDependency(ReactorPlugin.Id)]
    public partial class DisableLobbyShakePlugin : BasePlugin {
        public Harmony Harmony { get; } = new(Id);

        public override void Load() {

            Harmony.PatchAll();
        }

		[HarmonyPatch(typeof(LobbyBehaviour))]
		private static class LobbyBehaviourPatch {
			[HarmonyPatch(nameof(LobbyBehaviour.Start))]
			[HarmonyPostfix]
			private static void BeginPostfix() {
				Camera main = Camera.main;
				if (main != null) {
					FollowerCamera component = main.GetComponent<FollowerCamera>();
					if (component != null) {
						component.shakeAmount = 0f;
						component.shakePeriod = 0f;
					}
				}
			}
		}
	}
}