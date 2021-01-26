using Photon.Pun;
using Photon.Realtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviourPunCallbacks
{
    public bool testing;
    public PlayerController playerPrefab;
    [HideInInspector] public PlayerController localPlayer;

    void Start()
    {
        if (!PhotonNetwork.IsConnected && !testing)
        {
            PhotonNetwork.LoadLevel("Scenes/Menu");
        }
            
        PlayerController.RefreshInstance(ref localPlayer, playerPrefab);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        PlayerController.RefreshInstance(ref localPlayer, playerPrefab);
    }
}