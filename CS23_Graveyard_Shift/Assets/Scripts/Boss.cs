using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    // public GameObject cardPrefab;
    // public GameObject templateCard;

    // public GameObject EnemyHealth;
    // public GameObject CardValueDisplay;
    // public GameObject CardSuitDisplay;
    // public int handSize = 5;

    private int bossType;
    private int health;

    public GameObject EnemyHealth;
    public Sprite Baron;
    public Sprite Skellyrat;
    public Sprite Skulls;

    
    void Start() {
    }

    public int generateRandom() {
        bossType = Random.Range(0, 3);
        health = Random.Range(60, 150);

        EnemyHealth.SetActive(true);
        EnemyHealth.GetComponent<Text>().text = "Enemy Health: " + health.ToString();

        if (bossType == 0) {
            gameObject.GetComponent<SpriteRenderer>().sprite = Baron;
        } else if (bossType == 1) {
            gameObject.GetComponent<SpriteRenderer>().sprite = Skellyrat;
        } else if (bossType == 2) {
            gameObject.GetComponent<SpriteRenderer>().sprite = Skulls;
        }

        Debug.Log("generated boss:" + bossType);

        return bossType;
    }

    public bool aliveCheck() {
        return health > 0;
    }

    public bool playCard(int val, int suit)
    {
        Debug.Log("trying to play card " + val + " " + suit);
        bool played = false;
        if (bossType == 0) {
            if (suit == 0) {
                // red card, allowed
                health -= val;
                played = true;
            }
        } else if (bossType == 1) {
            if (suit == 1) {
                // black card allowed
                health -= val;
                played = true;
            }
        } else if (bossType == 2) {
            health -= val;
            played = true;
        }

        EnemyHealth.GetComponent<Text>().text = "Enemy Health: " + health.ToString();

        return played;
    }
}
