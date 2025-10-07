using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CardGenerator : MonoBehaviour {

    public GameObject cardPrefab;
    public GameObject templateCard;

    public GameObject Boss;
    public GameObject EnemyHealth;
    public GameObject CardValueDisplay;
    public GameObject CardSuitDisplay;
    public int handSize = 5;

    void Start() {
        for (int i = 0; i < handSize; i++) {

            int value = Random.Range(1, 11);
            int suit = Random.Range(0, 4);

            Debug.Log("Generated card: " + value + " of suit " + suit);

            GameObject newCard = Instantiate(cardPrefab);
            float xOffset = (i - 2) * 2f;
            newCard.transform.position = templateCard.transform.position + new Vector3(xOffset, 0f, 0f);

            CardHover hover = newCard.GetComponent<CardHover>();
            if (hover != null)
            {
                hover.cardValue = value;
                hover.cardSuit = suit;

                hover.Boss = Boss;
                hover.EnemyHealth = EnemyHealth;
                hover.CardSuitDisplay = CardSuitDisplay;
                hover.CardValueDisplay = CardValueDisplay;
            }
        }
    }
}