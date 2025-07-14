using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string PlayerName { get; private set; }
    public int PlayerCoins { get; private set; }

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // يضمن بقاء GameManager عبر المشاهد
            LoadPlayerData();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadPlayerData()
    {
        PlayerName = PlayerPrefs.GetString("PlayerName", "لاعب");
        PlayerCoins = PlayerPrefs.GetInt("PlayerCoins", 1000);
    }

    public void UpdateCoins(int newAmount)
    {
        PlayerCoins = newAmount;
        PlayerPrefs.SetInt("PlayerCoins", PlayerCoins);
    }

    public void AddCoins(int amount)
    {
        UpdateCoins(PlayerCoins + amount);
    }

    public void SubtractCoins(int amount)
    {
        UpdateCoins(PlayerCoins - amount);
    }
}
