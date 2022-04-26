using MelonLoader;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using ExitGames.Client.Photon;

namespace MyProject
{
    public class MyMod : MelonMod
    {

        public static MelonPreferences_Category spawnShip;
        public static MelonPreferences_Entry<int> shipsToSpawn;

        public override void OnApplicationStart()
        {
            spawnShip = MelonPreferences.CreateCategory("Spawn Ships");
            shipsToSpawn = spawnShip.CreateEntry("Ships to Spawn", 1);
        }

        public override void OnUpdate()
        {
            int i = 0;
            if (Input.GetKeyDown(KeyCode.F1))
            {
                if (NetworkManager.instance.IsRoomPrivate() == true)
                {
                    int teamId = GameManager.instance.GetTeamID(NetworkManager.instance.primaryLocalPlayerID);
                    while (i < 10)
                    {
                        TeamManager.instance.GetTeam(teamId).TryProduceShip();
                        i++;
                    }
                    i = 0;
                    LoggerInstance.Msg("You just spawned " + shipsToSpawn + " ships!");

                }
            if (Input.GetKeyDown(KeyCode.F2))
            {
                if (NetworkManager.instance.IsRoomPrivate() == true)
                {
                    int teamId = -1;
                    while (i < 10)
                    {
                        TeamManager.instance.GetTeam(teamId).TryProduceShip();
                        i++;
                    }
                    i = 0;
                    LoggerInstance.Msg("You just spawned " + shipsToSpawn + " ships!");

                }

            }
        }
    }
}
}
