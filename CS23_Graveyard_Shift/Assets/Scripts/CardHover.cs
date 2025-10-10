using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CardHover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private string[] suitMap = {"Heart", "Diamond"};
    private Vector3 initialScale;
    public int cardValue;
    public int cardSuit;
    public int cardIndex;
    public bool selected;

    // public GameObject Boss;
    // public GameObject EnemyHealth;
    public GameObject BattleManager;


    void Start()
    {
        initialScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        transform.localScale = initialScale * 1.1f;
    }

    void OnMouseExit()
    {
        if (!selected) {
            transform.localScale = initialScale;
        }
    }

    void OnMouseDown()
    {
        BattleManager battleManager = BattleManager.GetComponent<BattleManager>();
        if (battleManager != null)
        {
            bool clickStatus = battleManager.ClickCard(cardIndex);
            selected = false;
            if (clickStatus)
            {
                transform.localScale = initialScale * 1.1f;
                selected = true;
            }
        }
    }
}
