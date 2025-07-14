using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using System.Collections.Generic;

public class RoomManager : MonoBehaviourPunCallbacks
{
    public static RoomManager Instance;

    public GameObject playerPrefab;
    public Transform[] spawnPoints; // اربط 4 نقاط للسباون في المشهد

    private Dictionary<int, GameObject> spawnedPlayers = new Dictionary<int, GameObject>();

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        SpawnPlayer();
    }

    void SpawnPlayer()
    {
        int actorNumber = PhotonNetwork.LocalPlayer.ActorNumber;
        Vector3 spawnPos = spawnPoints[(actorNumber - 1) % spawnPoints.Length].position;

        GameObject playerObj = PhotonNetwork.Instantiate(playerPrefab.name, spawnPos, Quaternion.identity);
        playerObj.GetComponent<PlayerManager>().InitPlayer(actorNumber, GameManager.Instance.PlayerName);

        spawnedPlayers.Add(actorNumber, playerObj);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("لاعب جديد دخل: " + newPlayer.NickName);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log("لاعب خرج: " + otherPlayer.NickName);

        if (spawnedPlayers.ContainsKey(otherPlayer.ActorNumber))
        {
            Destroy(spawnedPlayers[otherPlayer.ActorNumber]);
            spawnedPlayers.Remove(otherPlayer.ActorNumber);
        }
    }

    public GameObject GetPlayerById(int actorNumber)
    {
        return spawnedPlayers.ContainsKey(actorNumber) ? spawnedPlayers[actorNumber] : null;
    }
}
