using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CardHover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private string[] suitMap = {"♥", "♦", "♠", "♣"};
    private Vector3 initialScale;
    public int cardValue;
    public int cardSuit;

    public GameObject Boss;
    public GameObject EnemyHealth;
    public GameObject CardValueDisplay;
    public GameObject CardSuitDisplay;

    void Start()
    {
        initialScale = transform.localScale;
        EnemyHealth.SetActive(true);
        CardValueDisplay.SetActive(true);
        CardSuitDisplay.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        transform.localScale = initialScale * 1.1f;

        CardValueDisplay.GetComponent<Text>().text = cardValue.ToString();
        CardSuitDisplay.GetComponent<Text>().text = suitMap[cardSuit];
        CardSuitDisplay.GetComponent<Text>().color = Color.black;
        if (cardSuit <= 1) {
            CardSuitDisplay.GetComponent<Text>().color = Color.red;
        }
    }

    void OnMouseExit()
    {
        transform.localScale = initialScale;

        CardValueDisplay.GetComponent<Text>().text = "";
        CardSuitDisplay.GetComponent<Text>().text = "";
    }

    void OnMouseDown()
    {
        Boss boss = Boss.GetComponent<Boss>();
        if (boss != null)
        {
            bool played = boss.playCard(cardValue, cardSuit);
            if (played) {
                Destroy(gameObject);
            }
        }
    }
}
