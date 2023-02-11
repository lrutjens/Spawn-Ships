using MelonLoader;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR;
using System.Runtime;

namespace Melon_Mod
{
    public class MyMod : MelonMod
    {

        public static MelonPreferences_Category spawnShip;
        public static MelonPreferences_Entry<int> shipsToSpawn;
        public static MelonPreferences_Entry<int> TeamId;


        public override void OnApplicationStart()
        {
            spawnShip = MelonPreferences.CreateCategory("Spawn Ships");
            shipsToSpawn = spawnShip.CreateEntry("Ships to Spawn", 1);
            //int TeamId = spawnShip.CreateEntry("Team ID", 1);

            
        }

        public override void OnUpdate()
        {
            InputDevice oculusTouch = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
            if (oculusTouch.TryGetFeatureValue(CommonUsages.primaryButton, out bool isPrimaryButtonPressed))
            {
                LoggerInstance.Msg("YAYYYYYY");
                if (isPrimaryButtonPressed)
                {
                    LoggerInstance.Msg("OMFG IT MIGHT WORK");
                    int repeat = 0;
                    while (repeat < 10)
                    {
                        LoggerInstance.Msg("FKGSFDKJFUWYVKGVWDFKAQ");
                        TeamManager.instance.GetTeam(1).TryProduceShip();
                        LoggerInstance.Msg("IT WORKSSSS!!!!!");
                        repeat++;
                    }
                }
            }
            
            /*bool isGameLeaderOffline = NetworkManager.instance.isLocalRoomHost;
            int i = 0;
            if (Input.GetKeyDown(KeyCode.F1))
            {
                isGameLeaderOffline = NetworkManager.instance.isLocalRoomHost;

                if (isGameLeaderOffline == true)
                {
                    //int teamId = 1; //TeamManager.instance.GetTeam(1);
                    while (i < 10)
                    {
                        TeamManager.instance.GetTeam(1).TryProduceShip();
                        i++;
                    }
                    i = 0;
                    LoggerInstance.Msg("You just spawned " + shipsToSpawn + " ships!");

                }
                if (Input.GetKeyDown(KeyCode.F2))
                {
                    if (isGameLeaderOffline == true)
                    {
                        //int teamId = -1;
                        while (i < 10)
                        {
                            TeamManager.instance.GetTeam(1).TryProduceShip();
                            i++;
                        }
                        i = 0;
                        LoggerInstance.Msg("You just spawned " + shipsToSpawn + " ships!");

                    }

                }
            }*/
        }
    }
}
