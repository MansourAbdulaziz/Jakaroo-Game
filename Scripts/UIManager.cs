using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("Player Info")]
    public Text playerNameText;
    public Text coinsText;

    [Header("Game UI")]
    public Button drawCardButton;
    public Button endTurnButton;
    public Text statusText;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        UpdatePlayerInfo();
        SetGameUIActive(false);
        statusText.text = "";
    }

    public void UpdatePlayerInfo()
    {
        playerNameText.text = GameManager.Instance.PlayerName;
        coinsText.text = "Coins: " + GameManager.Instance.PlayerCoins.ToString();
    }

    public void SetGameUIActive(bool active)
    {
        drawCardButton.interactable = active;
        endTurnButton.interactable = active;
    }

    public void ShowStatus(string message)
    {
        statusText.text = message;
    }

    // هذه الدوال يتم ربطها بالأزرار
    public void OnDrawCardClicked()
    {
        GameLogic.Instance.PlayerDrawCard(); // تأكد عندك سكربت GameLogic.cs
    }

    public void OnEndTurnClicked()
    {
        GameLogic.Instance.EndPlayerTurn();
    }
}
