using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class NetworkManager : MonoBehaviourPunCallbacks
{
    public static NetworkManager Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // يبقى بين المشاهد
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        ConnectToPhoton();
    }

    public void ConnectToPhoton()
    {
        PhotonNetwork.ConnectUsingSettings();
        Debug.Log("جاري الاتصال بـ Photon...");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("تم الاتصال بـ Photon Master");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("دخلت اللوبي!");
    }

    public void CreateRoom(string roomName)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = 4;
        PhotonNetwork.CreateRoom(roomName, options);
    }

    public void JoinRoom(string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("تم الدخول إلى الغرفة: " + PhotonNetwork.CurrentRoom.Name);
        SceneManager.LoadScene("GameScene"); // المشهد الفعلي للعب
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        Debug.LogError("فشل الانضمام: " + message);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("فشل إنشاء الغرفة: " + message);
    }
}
