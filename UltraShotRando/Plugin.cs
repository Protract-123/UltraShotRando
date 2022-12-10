using BepInEx;
using System.Collections.Generic;
using UltraShotRando.UltraShotRando;
using UnityEngine;
using HarmonyLib;

namespace UltraShotRando
{
    [BepInPlugin("protract.uk.ultraShotRando", "UltraShotRandomizer", "0.1.0")]
    [BepInProcess("ULTRAKILL.exe")]

    [HarmonyPatch(typeof(MapLoader), "EnsureCommonIsLoaded")]
    public class Plugin : BaseUnityPlugin
    {
        public void Start()
        {
            var harmony = new Harmony("Protract.UK.USR");
            harmony.PatchAll();
        }
        public static void Postfix()
        {
            AssetBundle commonBundle = null;

            IEnumerable<AssetBundle> x = AssetBundle.GetAllLoadedAssetBundles();

            foreach (AssetBundle bundle in x)
            {
                Debug.Log(bundle.name);
                if (bundle.name == "common")
                {
                    commonBundle = bundle;
                }
            }

            object LoadAssetFromBundle(string name)
            {

                bool flag = commonBundle == null;
                object result;
                if (flag)
                {
                    Debug.LogError("Could not load asset " + name + " due to the common asset bundle not being loaded.");
                    result = null;
                }
                else
                {
                    result = commonBundle.LoadAsset(name);
                }
                return result;
            }

            if (commonBundle != null)
            {
                Projectiles.revBeamPrefab = (GameObject)LoadAssetFromBundle("RevolverBeam.prefab");
                Projectiles.revBeamSuperPrefab = (GameObject)LoadAssetFromBundle("RevolverBeamSuper.prefab");

                Projectiles.shotgunPelletPrefab = (GameObject)LoadAssetFromBundle("ShotgunProjectile.prefab");
                Projectiles.shotgunCorePrefab = (GameObject)LoadAssetFromBundle("Grenade.prefab");

                Projectiles.blueNailPrefab = (GameObject)LoadAssetFromBundle("NailFodder.prefab");
                Projectiles.nailPrefab = (GameObject)LoadAssetFromBundle("Nail.prefab");
                Projectiles.heatedNailPrefab = (GameObject)LoadAssetFromBundle("NailHeated.prefab");

                Projectiles.blueSawPrefab = (GameObject)LoadAssetFromBundle("NailAltFodder.prefab");
                Projectiles.sawPrefab = (GameObject)LoadAssetFromBundle("NailAlt.prefab");
                Projectiles.heatedSawPrefab = (GameObject)LoadAssetFromBundle("NailAltHeated.prefab");

                Projectiles.railRedPrefab = (GameObject)LoadAssetFromBundle("RailcannonBeamMalicious.prefab");
                Projectiles.railBluePrefab = (GameObject)LoadAssetFromBundle("RailcannonBeam.prefab");
                Projectiles.railGreenPrefab = (GameObject)LoadAssetFromBundle("HarpoonMalicious.prefab");

                Projectiles.rocketPrefab = (GameObject)LoadAssetFromBundle("Rocket.prefab");

                Projectiles.lightningPrefab = (GameObject)LoadAssetFromBundle("LightningBeamReflectable Variant.prefab");

                Projectiles.projectilePrefab = (GameObject)LoadAssetFromBundle("Projectile.prefab");
                Projectiles.projectileSpreadPrefab = (GameObject)LoadAssetFromBundle("ProjectileSpread.prefab");
                Projectiles.projectileHomingPrefab = (GameObject)LoadAssetFromBundle("ProjectileHoming.prefab");
                Projectiles.projectileExplosivePrefab = (GameObject)LoadAssetFromBundle("ProjectileExplosive.prefab");
                Projectiles.projectileHomingExplosivePrefab = (GameObject)LoadAssetFromBundle("ProjectileHomingExplosive");

                Projectiles.swordThrown1Prefab = (GameObject)LoadAssetFromBundle("ThrownSword.prefab");
                Projectiles.swordThrown2Prefab = (GameObject)LoadAssetFromBundle("ThrownSword2.prefab");

                Projectiles.turretBeamPrefab = (GameObject)LoadAssetFromBundle("TurretBeam.prefab");
                Projectiles.maliciousBeamPrefab = (GameObject)LoadAssetFromBundle("MaliciousBeam.prefab");

                Projectiles.massProjectilePrefab = (GameObject)LoadAssetFromBundle("ProjectileExplosiveHH.prefab");
                Projectiles.massSpearPrefab = (GameObject)LoadAssetFromBundle("Spear");

                Projectiles.gabSpearPrefab = (GameObject)LoadAssetFromBundle("GabrielThrownSpear");
                Projectiles.gabAxePrefab = (GameObject)LoadAssetFromBundle("GabrielThrownAxes");
                Projectiles.gabZweiPrefab = (GameObject)LoadAssetFromBundle("GabrielThrownZwei");
                Projectiles.gabSwordPrefab = (GameObject)LoadAssetFromBundle("GabrielCombinedSwords");
                Projectiles.gabSummonSwordsPrefab = (GameObject)LoadAssetFromBundle("GabrielSummonedSwords");

                Projectiles.mpSnakePrefab = (GameObject)LoadAssetFromBundle("ProjectileMinosPrime.prefab");


                Projectiles.projectiles = new Dictionary<int, GameObject>()
                {
                    [0] = Projectiles.revBeamPrefab,
                    [1] = Projectiles.revBeamSuperPrefab,
                    [2] = Projectiles.shotgunPelletPrefab,
                    [3] = Projectiles.shotgunCorePrefab,
                    [4] = Projectiles.blueNailPrefab,
                    [5] = Projectiles.nailPrefab,
                    [6] = Projectiles.heatedNailPrefab,
                    [7] = Projectiles.blueSawPrefab,
                    [8] = Projectiles.sawPrefab,
                    [9] = Projectiles.heatedSawPrefab,
                    [10] = Projectiles.railRedPrefab,
                    [11] = Projectiles.railBluePrefab,
                    [12] = Projectiles.railGreenPrefab,
                    [13] = Projectiles.rocketPrefab,
                    [14] = Projectiles.lightningPrefab,
                    [15] = Projectiles.projectilePrefab,
                    [16] = Projectiles.projectileSpreadPrefab,
                    [17] = Projectiles.projectileHomingPrefab,
                    [18] = Projectiles.projectileExplosivePrefab,
                    [19] = Projectiles.projectileHomingExplosivePrefab,
                    [20] = Projectiles.swordThrown1Prefab,
                    [21] = Projectiles.swordThrown2Prefab,
                    [22] = Projectiles.turretBeamPrefab,
                    [23] = Projectiles.maliciousBeamPrefab,
                    [24] = Projectiles.massProjectilePrefab,
                    [25] = Projectiles.massSpearPrefab,
                    [26] = Projectiles.gabSpearPrefab,
                    [27] = Projectiles.gabAxePrefab,
                    [28] = Projectiles.gabZweiPrefab,
                    [29] = Projectiles.gabSwordPrefab,
                    [30] = Projectiles.gabSummonSwordsPrefab,
                    [31] = Projectiles.mpSnakePrefab
                };
            }
        }
       
    }
    

}
