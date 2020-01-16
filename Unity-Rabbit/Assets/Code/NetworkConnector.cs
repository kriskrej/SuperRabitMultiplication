using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class NetworkConnector : MonoBehaviourPunCallbacks {
    [SerializeField] byte maxPlayersPerRoom = 32;
    
    public string roomName = "default";
    
    void Start() {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster() {
        Debug.Log($"Connected to Master\n Creating or joining room \"{roomName}\"");
        PhotonNetwork.JoinOrCreateRoom(roomName, new RoomOptions { MaxPlayers = maxPlayersPerRoom }, TypedLobby.Default);
        
    }
    
    public override void OnJoinRandomFailed(short returnCode, string message) {
        Debug.Log("No random room available, we created one\n");
        PhotonNetwork.CreateRoom(null, new RoomOptions {MaxPlayers = maxPlayersPerRoom});
    }

    public override void OnJoinedRoom() {
        var playersInside = PhotonNetwork.CurrentRoom.PlayerCount;
        Debug.Log($"I'm in a room! (with {playersInside-1} other players inside)\n\t loading map");
    }

    public override void OnDisconnected(DisconnectCause cause) {
        Debug.LogWarningFormat("Disconnected : {0}\n", cause);
    }
}