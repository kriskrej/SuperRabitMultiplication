using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkConnector : MonoBehaviourPunCallbacks {
    void Awake() {
        // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    void Start() {
        Connect();
    }


    void Connect() {
        if (PhotonNetwork.IsConnected)
            PhotonNetwork.JoinRandomRoom();
        else
            PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        Debug.Log("OnConnectedToMaster() was called by PUN");
        PhotonNetwork.JoinRandomRoom();
    }


    public override void OnDisconnected(DisconnectCause cause) {
        Debug.LogWarningFormat("OnDisconnected() was called by PUN with reason {0}",
            cause);
    }

    public override void OnJoinedRoom() {
        Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
    }

    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.Log(
            "OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");
        PhotonNetwork.CreateRoom(null, new RoomOptions());
    }
}