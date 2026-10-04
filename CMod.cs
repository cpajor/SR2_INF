using System.Linq;
using Il2Cpp;
using Il2CppMonomiPark.SlimeRancher.Player.CharacterController.Abilities;
using MelonLoader;
using UnityEngine;

[assembly: MelonInfo(typeof(InfMod.CMod), "INF", "1.0.0", "cpajor")]
[assembly: MelonGame("MonomiPark", "SlimeRancher2")]

namespace InfMod
{
    public class CMod : MelonMod
    {
        public static T Get<T>(string name) where T : Object
        {
            return Resources.FindObjectsOfTypeAll<T>().FirstOrDefault(x => x.name == name);
        }

        public override void OnSceneWasLoaded(int buildIndex, string sceneName)
        {
            if (sceneName == "PlayerCore")
            {
                Get<JetpackAbilityData>("Jetpack")._hoverHeight = float.MaxValue;
                Get<JetpackAbilityData>("Jetpack")._maxUpwardThrustForce = 5f;
                Get<JetpackAbilityData>("Jetpack")._upwardThrustForceIncrement = 5f;
            }

        }

        public override void OnUpdate()
        {
            if (SRSingleton<SceneContext>.Instance != null && SRSingleton<SceneContext>.Instance.PlayerState != null)
            {            
                SRSingleton<SceneContext>.Instance.PlayerState.SetEnergy(SRSingleton<SceneContext>.Instance.PlayerState.GetMaxEnergy());
            }
        }

    }
}