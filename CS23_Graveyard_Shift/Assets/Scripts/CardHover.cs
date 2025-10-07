using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CardHover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 initialScale;
    public int cardValue;
    public int cardSuit;

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
    }

    void OnMouseExit()
    {
        transform.localScale = initialScale;

        CardValueDisplay.GetComponent<Text>().text = "";
    }

    void OnMouseDown()
    {
        int.TryParse(EnemyHealth.GetComponent<Text>().text, out int EnemyHealthValue);

        EnemyHealthValue -= cardValue;

        EnemyHealth.GetComponent<Text>().text = EnemyHealthValue.ToString();
    }
}
