using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Linq;

public class BattleManager : MonoBehaviour
{
    public Canvas canvas;

    public GameObject cardPrefab;
    public GameObject templateCard;
    public GameObject cardValuePrefab;
    public GameObject templateCardValue;

    public GameObject Boss;
    public GameObject EnemyHealth;
    public Button MultButton;
    public Button PlayButton;
    public GameObject RuleDisplay;

    public Sprite red;
    public Sprite black;
    public Sprite orangeCards;
    public Sprite blueCards;
    public Sprite allCards;

    private static int handSize = 5;
    private bool canMult = true;
    private bool[] selected = new bool[handSize];
    private GameObject[] cards = new GameObject[handSize];
    private GameObject[] cardValues = new GameObject[handSize];

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        GenerateCards();
        Boss boss = Boss.GetComponent<Boss>();
        int bossType = boss.generateRandom();

        if (bossType == 0) {
            RuleDisplay.GetComponent<SpriteRenderer>().sprite = orangeCards;
        } else if (bossType == 1) {
            RuleDisplay.GetComponent<SpriteRenderer>().sprite = blueCards;
        } else {
            RuleDisplay.GetComponent<SpriteRenderer>().sprite = allCards;
        }

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
                DestroyCard(selection);
                selected[selection] = false;
                GenerateCard(selection);
            }
        }

        

        canMult = true;
        checkBossHealth();
    }

    public void MultiplyCards() {
        int count = selected.Count(b => b);
        if (count != 2 || !canMult) {
            return;
        }

        int newVal = 1;
        int first = -1;
        int second = -1;
        int suit = -1;
        for (int i = 0; i < handSize; i++) {
            if (selected[i]) {
                CardHover cardHover = cards[i].GetComponent<CardHover>();
                if (cardHover != null) {
                    newVal *= cardHover.cardValue;
                }

                if (first != -1) {
                    second = i;
                    if (cardHover.cardSuit != suit) {
                        Debug.Log("tried multiplying different suits");
                        return;
                    }
                } else {
                    first = i;
                    suit = cardHover.cardSuit;
                }
            }
        }

        Debug.Log("test mult: " + newVal + " " + first + " " + second);

        canMult = false;
        DestroyCard(first);
        DestroyCard(second);
        selected[first] = false;
        selected[second] = false;

        GenerateCard(first, newVal, suit);
        // GenerateCard(second);
    }

    void DestroyCard(int id) {
        Destroy(cards[id]);
        Destroy(cardValues[id]);
    }

    void GenerateCards() {
        for (int i = 0; i < handSize; i++) {
            GenerateCard(i);
        }
    }

    void GenerateCard(int id, int val = -1, int new_suit = -1) {
        int value = Random.Range(1, 11);
        int suit = Random.Range(0, 2);
        if (val != -1) {
            value = val;
        }
        if (new_suit != -1) {
            suit = new_suit;
        }
        
        GameObject newCard = Instantiate(cardPrefab);
        GameObject newCardValue = Instantiate(cardValuePrefab, canvas.transform);
        float xOffset = (id - 2) * 2f;
        newCard.transform.position = templateCard.transform.position + new Vector3(xOffset, 0f, 0f);
        newCardValue.transform.position = templateCardValue.transform.position + new Vector3(xOffset * 53, 0f, 0f);

        newCardValue.GetComponent<Text>().text = value.ToString();

        // newCardValue.transform.SetParent(canvas);

        newCardValue.SetActive(true);

        CardHover hover = newCard.GetComponent<CardHover>();
        if (hover != null) {
            hover.cardValue = value;
            hover.cardSuit = suit;
            hover.cardIndex = id;

            hover.BattleManager = gameObject;
        }

        if (suit == 0) {
            newCard.GetComponent<SpriteRenderer>().sprite = red;
        } else {
            newCard.GetComponent<SpriteRenderer>().sprite = black;
        }

        cards[id] = newCard;
        cardValues[id] = newCardValue;
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
