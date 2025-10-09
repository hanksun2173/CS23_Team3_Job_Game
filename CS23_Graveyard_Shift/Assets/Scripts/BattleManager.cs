using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class BattleManager : MonoBehaviour
{
    public GameObject cardPrefab;
    public GameObject templateCard;

    public GameObject Boss;
    public GameObject EnemyHealth;
    public GameObject CardValueDisplay;
    public GameObject CardSuitDisplay;
    public Button MultButton;
    public Button PlayButton;

    private static int handSize = 5;
    private bool[] selected = new bool[handSize];
    private GameObject[] cards = new GameObject[handSize];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        GenerateCards();
        MultButton.onClick.AddListener(MultiplyCards);
        PlayButton.onClick.AddListener(PlayCard);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public bool ClickCard(int index) {
        selected[index] = !selected[index];
        bool ans = false;
        if (selected[index]) {
            Debug.Log("case 1");
            int count = selected.Count(b => b);
            if (count > 2) {
                // already selected 2 cards, cannot select a third
                // return false;
                selected[index] = false;
                ans = false;
            } else {
                ans = true;
            }
            // return true;
        }

        Debug.Log("attempted clicking " + index + ans);
        return ans;
        // return false;
    }

    public void PlayCard() {
        int count = selected.Count(b => b);
        if (count != 1) {
            // do nothing
            return;
        }
        
        int selection = -1;
        for (int i = 0; i < handSize; i++) {
            if (selected[i]) {
                selection = i;
                break;
            }
        }

        Boss boss = Boss.GetComponent<Boss>();
        CardHover hover = cards[selection].GetComponent<CardHover>();
        if (boss != null && hover != null) {
            bool played = boss.playCard(hover.cardValue, hover.cardSuit);
            if (played) {
                Destroy(cards[selection]);
                selected[selection] = false;
            }
        }

        checkBossHealth();
    }

    public void MultiplyCards() {
        int count = selected.Count(b => b);
        if (count != 2) {
            // do nothing
            return;
        }
        
        int newVal = 1;
        int first = -1;
        int second = -1;
        for (int i = 0; i < handSize; i++) {
            if (selected[i]) {
                CardHover cardHover = cards[i].GetComponent<CardHover>();
                if (cardHover != null) {
                    newVal *= cardHover.cardValue;
                }

                if (first != -1) {
                    second = i;
                } else {
                    first = i;
                }
            }
        }

        Debug.Log("test mult: " + newVal + " " + first + " " + second);

        Destroy(cards[first]);
        Destroy(cards[second]);
        selected[first] = false;
        selected[second] = false;

        GameObject newCard = Instantiate(cardPrefab);
        float xOffset = (first - 2) * 2f;
        newCard.transform.position = templateCard.transform.position + new Vector3(xOffset, 0f, 0f);
        int suit = Random.Range(0, 4);

        CardHover hover = newCard.GetComponent<CardHover>();
        if (hover != null) {
            hover.cardValue = newVal;
            hover.cardSuit = suit;
            hover.cardIndex = first;

            hover.CardSuitDisplay = CardSuitDisplay;
            hover.CardValueDisplay = CardValueDisplay;
            hover.BattleManager = gameObject;
        }

        cards[first] = newCard;
    }

    void GenerateCards() {
        for (int i = 0; i < handSize; i++) {
            int value = Random.Range(1, 11);
            int suit = Random.Range(0, 4);

            Debug.Log("Generated card: " + value + " of suit " + suit);

            GameObject newCard = Instantiate(cardPrefab);
            float xOffset = (i - 2) * 2f;
            newCard.transform.position = templateCard.transform.position + new Vector3(xOffset, 0f, 0f);

            CardHover hover = newCard.GetComponent<CardHover>();
            if (hover != null) {
                hover.cardValue = value;
                hover.cardSuit = suit;
                hover.cardIndex = i;

                hover.CardSuitDisplay = CardSuitDisplay;
                hover.CardValueDisplay = CardValueDisplay;
                hover.BattleManager = gameObject;
            }

            cards[i] = newCard;
        }
    }

    void checkBossHealth() {
        Boss boss = Boss.GetComponent<Boss>();
        if (boss != null) {
            if (!boss.aliveCheck()) {
                SceneManager.LoadScene("Graveyard");
            }
        }
    }
}
