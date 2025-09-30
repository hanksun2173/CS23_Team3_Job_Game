using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CardHover : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private Vector3 initialScale;
    public GameObject EnemyHealth;
    void Start()
    {
        initialScale = transform.localScale;
        EnemyHealth.SetActive(true);
        
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
        transform.localScale = initialScale;
    }

    void OnMouseDown()
    {
        int.TryParse(EnemyHealth.GetComponent<Text>().text, out int EnemyHealthValue);

        EnemyHealthValue -= 1;

        EnemyHealth.GetComponent<Text>().text = EnemyHealthValue.ToString();
    }

}
