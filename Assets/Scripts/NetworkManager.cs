using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public Button connectButton;
    public Button joinRoomButton;
    public TMP_Text statusText;

    private void Start()
    {
        statusText.text = "";
        DontDestroyOnLoad(gameObject);

        if (DeviceManager.mode == Mode.VR)
        {
            OnConnectToServerClicked();
        }
    }

    public void OnConnectToServerClicked()
    {
        PhotonNetwork.OfflineMode = false;
        PhotonNetwork.NickName = "Player";
        PhotonNetwork.GameVersion = "1";

        PhotonNetwork.ConnectUsingSettings();
    }

    public void OnJoinGameClicked()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
            
        Debug.Log($"Joined game");
        statusText.text = "Successfully joined game";
            
        PhotonNetwork.LoadLevel("Scenes/Game");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        base.OnJoinRandomFailed(returnCode, message);

        Debug.Log($"No game existing, creating one");
        PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = 2});
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        base.OnCreateRoomFailed(returnCode, message);
            
        statusText.text = "Creating game failed";
    }

    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();

        statusText.text = "Connected to master server";

        if (DeviceManager.mode == Mode.VR)
        {
            OnJoinGameClicked();
        }
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        base.OnDisconnected(cause);

        statusText.text = cause.ToString();
    }

    private void Update()
    {
        if (connectButton != null)
        {
            connectButton.gameObject.SetActive(!PhotonNetwork.IsConnected);
        }

        if (joinRoomButton != null)
        {
            joinRoomButton.gameObject.SetActive(PhotonNetwork.IsConnected);
        }
    }
}