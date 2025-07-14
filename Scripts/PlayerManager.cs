using UnityEngine;
using System.Collections.Generic;

public class PlayerManager : MonoBehaviour
{
    public int playerId;
    public string playerName;
    public bool isMyTurn;
    public bool hasFinished;

    public List<Card> handCards = new List<Card>();

    public void InitPlayer(int id, string name)
    {
        playerId = id;
        playerName = name;
        isMyTurn = false;
        hasFinished = false;
        handCards.Clear();
    }

    public void StartTurn()
    {
        isMyTurn = true;
        Debug.Log($"{playerName} يبدأ دوره");
        // هنا ممكن تفعّل UI اللعب أو المؤشر
    }

    public void EndTurn()
   
