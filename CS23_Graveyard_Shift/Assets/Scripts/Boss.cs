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

    
    void Start() {
        bossType = Random.Range(0, 4);
        health = Random.Range(15, 30);

        EnemyHealth.SetActive(true);
        EnemyHealth.GetComponent<Text>().text = health.ToString();

        Debug.Log("generated boss:" + bossType);
    }

    public void playCard(int val, int suit)
    {
        Debug.Log("trying to play card " + val + " " + suit);
        if (bossType == 0) {
            if (suit <= 1) {
                // red card, allowed
                health -= val;
            }
        } else if (bossType == 1) {
            if (suit >= 2) {
                // black card allowed
                health -= val;
            }
        } else if (bossType == 2) {

        } else if (bossType == 3) {

        }

        EnemyHealth.GetComponent<Text>().text = health.ToString();
    }
}
