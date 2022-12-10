using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace UltraShotRando.UltraShotRando.Weapons
{
    [HarmonyPatch(typeof(Nailgun), "Shoot")]
    public class NailgunShots
    {
        public static void Prefix()
        {
            GunControl gc = MonoSingleton<NewMovement>.Instance.GetComponentInChildren<GunControl>();
            Camera cc = MonoSingleton<NewMovement>.Instance.GetComponentInChildren<Camera>();
            if (gc != null)
            {
                if (gc.currentWeapon.name.Contains("Nailgun"))
                {
                    Nailgun nailgun = gc.currentWeapon.GetComponent<Nailgun>();
                    System.Random r = new System.Random();
                    int ran = r.Next(0, 32);
                    Debug.Log(ran);
                    if (nailgun != null)
                    {
                        GameObject projectile = Projectiles.projectiles[ran];

                        Vector3 spawnPos = cc.transform.position;
                        if (ran == 22 || (ran > 14 && ran < 20) || ran == 24 || (ran >= 26 && ran <= 31) || ran == 20 || ran == 21)
                        {
                            spawnPos = cc.transform.position + (cc.transform.forward * 7f);

                            if (ran > 14 && ran < 20)
                            {
                                spawnPos = cc.transform.position + (cc.transform.forward * 4f);
                            }
                            if (ran == 21 || ran == 20)
                            {
                                spawnPos = cc.transform.position + (cc.transform.forward * 5f);
                            }
                        }


                        GameObject gameObject = UnityEngine.Object.Instantiate<GameObject>(projectile, spawnPos, cc.transform.rotation);

                        #region Saws

                        if (ran == 9 || ran == 8 || ran == 7)
                        {
                            gameObject.transform.forward = cc.transform.forward;
                            if (Physics.Raycast(cc.transform.position, cc.transform.forward, 1f, LayerMaskDefaults.Get(LMD.Environment)))
                            {
                                gameObject.transform.position = cc.transform.position;
                            }

                            gameObject.transform.Rotate(0, 0, 0);
                            Rigidbody rigidbody;
                            if (gameObject.TryGetComponent<Rigidbody>(out rigidbody))
                            {
                                rigidbody.velocity = gameObject.transform.forward * 200f;
                            }
                            Nail nail;
                            if (gameObject.TryGetComponent<Nail>(out nail))
                            {
                                if (nail.sawblade)
                                {
                                    int x = 0;

                                    if (ran == 9)
                                    {
                                        x = 15;
                                    }
                                    else if (ran == 8)
                                    {
                                        x = 2;
                                    }
                                    else if (ran == 7)
                                    {
                                        x = 5;
                                    }

                                    nail.multiHitAmount = x;
                                    nail.ForceCheckSawbladeRicochet();
                                }
                            }
;
                        }

                        #endregion

                        #region Nails

                        if (ran == 4 || ran == 5 || ran == 6)
                        {
                            gameObject.GetComponent<Rigidbody>().velocity = cc.transform.forward * 20;
                            int i = 0;
                            while (i < 25)
                            {
                                GameObject.Instantiate(gameObject);
                                i++;
                            }
                        }

                        #endregion

                        #region Shotgun
                        if (ran == 3 || ran == 24 || ran == 18)
                        {
                            GameObject cam = cc.gameObject;
                            float grenadeForce = UnityEngine.Random.Range(30, 60);

                            Vector3 grenadeVector = new Vector3(cam.transform.forward.x, cam.transform.forward.y, cam.transform.forward.z);
                            gameObject.GetComponent<Collider>();

                            if (ran == 3)
                            {
                                gameObject.GetComponent<Rigidbody>().AddForce(grenadeVector * (grenadeForce + 10f), ForceMode.VelocityChange);
                            }
                            else if (ran == 24 || ran == 18)
                            {
                                gameObject.GetComponent<Rigidbody>().velocity = (grenadeVector * (grenadeForce + 10f) * 2);
                            }

                        }
                        if (ran == 2)
                        {
                            int i = 0;
                            while (i < 10)
                            {
                                GameObject.Instantiate(gameObject);
                                i++;
                            }
                        }

                        #endregion

                        #region Drills/Harpoon

                        if (ran == 12 || ran == 25)
                        {
                            if (ran == 25)
                            {
                                DestroyObjects.Destroy(gameObject);
                            }
                            else if (ran == 12)
                            {
                                gameObject.GetComponent<Rigidbody>().velocity = (cc.transform.forward * 80);
                            }
                        }

                        #endregion

                        #region Swordsmachine

                        if (ran == 20 || ran == 21)
                        {
                            if (ran == 21)
                            {
                                DestroyObjects.Destroy(gameObject);
                            }
                            else if (ran == 20)
                            {
                                gameObject.GetComponent<Rigidbody>().velocity = cc.transform.forward * 30;

                            }
                        }

                        #endregion

                        #region Other

                        if (ran == 29 || ran == 31 || ran == 28)
                        {
                            GameObject cam = cc.gameObject;
                            Vector3 vector = new Vector3(cam.transform.forward.x, cam.transform.forward.y, cam.transform.forward.z);
                            if (ran == 31)
                            {
                                gameObject.GetComponentInChildren<Rigidbody>().velocity = vector * 60;
                            }
                            if (ran == 29 || ran == 28)
                            {
                                gameObject.GetComponent<Rigidbody>().velocity = vector * 60;
                            }
                        }


                        #endregion



                    }
                }
            }
        }
    }
}
