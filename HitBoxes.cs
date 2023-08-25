using UnityEngine;
using UnityEngine.UI;
using Utilla;
using System;
using BepInEx;
using HarmonyLib;
using System.Reflection;
using static OVRPlugin;
using Photon.Pun;

namespace Mod1
{
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin("com.gorillatag.kongo.hitboxes", "HitBoxes", "1.0.0")]


    public class Plugin : BaseUnityPlugin
    {
        bool inRoom;
        GameObject LeftHand;
        GameObject RightHand;
        bool enabled;

        void Start()
        {
            /* A lot of Gorilla Tag systems will not be set up when start is called /*
            /* Put code in OnGameInitialized to avoid null references */

            Utilla.Events.GameInitialized += OnGameInitialized;

        }

        void OnEnable()
        {
            enabled = true;
        }

        void OnDisable()
        {
            enabled = false;
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            LeftHand = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            RightHand = GameObject.CreatePrimitive(PrimitiveType.Sphere);
        }

        void Update()
        {
            LeftHand.SetActive(enabled);
            RightHand.SetActive(enabled);
            LeftHand.transform.localPosition = GorillaLocomotion.Player.Instance.leftControllerTransform.localPosition;
            RightHand.transform.localPosition = GorillaLocomotion.Player.Instance.rightControllerTransform.localPosition;
            LeftHand.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            RightHand.transform.localScale = new Vector3(0.1f, 0.1f, 0.1f);
            LeftHand.GetComponent<Material>().color = Color.white;
            RightHand.GetComponent<Material>().color = Color.white;
        }

        /* This attribute tells Utilla to call this method when a modded room is joined */
        [ModdedGamemodeJoin]
        public void OnJoin(string gamemode)
        {
            /* Activate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = true;
        }

        /* This attribute tells Utilla to call this method when a modded room is left */
        [ModdedGamemodeLeave]
        public void OnLeave(string gamemode)
        {
            /* Deactivate your mod here */
            /* This code will run regardless of if the mod is enabled*/

            inRoom = false;
        }
    }
}
    
    