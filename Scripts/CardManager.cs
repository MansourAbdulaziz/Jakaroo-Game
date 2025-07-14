using UnityEngine;
using System.Collections.Generic;

public class CardManager : MonoBehaviour
{
    public static CardManager Instance;

    public GameObject cardPrefab;
    public Transform deckPosition;

    private List<Card> deck = new List<Card>();
    private List<Card> usedCards = new List<Card>();

    private string[] suits = { "Hearts", "Spades", "Clubs", "Diamonds" };
    private string[] values = {
        "A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"
    };

    void Awake()
    {
        Instance = this;
    }

    public void CreateDeck()
    {
        deck.Clear();
        usedCards.Clear();

        foreach (string suit in suits)
        {
            foreach (string value in values)
            {
                GameObject cardObj = Instantiate(cardPrefab, deckPosition.position, Quaternion.identity);
                Card card = cardObj.GetComponent<Card>();
                card.SetCard(value, suit);
                cardObj.SetActive(false); // نخفيه حالياً
                deck.Add(card);
            }
        }

        ShuffleDeck();
    }

    public void ShuffleDeck()
    {
        for (int i = 0; i < deck.Count; i++)
        {
            int rnd = Random.Range(0, deck.Count);
            Card temp = deck[i];
            deck[i] = deck[rnd];
            deck[rnd] = temp;
        }
    }

    public Card DrawCard()
    {
        if (deck.Count == 0)
        {
            Debug.LogWarning("Deck is empty!");
            return null;
        }

        Card card = deck[0];
        deck.RemoveAt(0);
        usedCards.Add(card);
        return card;
    }

    public void ResetDeck()
    {
        foreach (Card card in usedCards)
        {
            deck.Add(card);
        }
        usedCards.Clear();
        ShuffleDeck();
    }
}
