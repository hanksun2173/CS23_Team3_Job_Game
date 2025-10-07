using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Grandma : MonoBehaviour
{
    public GameObject grave;
    public GameObject InteractionText;
    public GameObject GrandmaText;
    public bool isDug = false;
    public string GraveID;
    public Sprite DugGraveSprite;
    private GameHandler gameHandler;


    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        if (gameHandler == null)
        {
            Debug.LogError("GameHandler not found in scene!");
        }
        InteractionText.SetActive(false);
        GrandmaText.SetActive(false);

    }

    void Update()
    {
        if (gameHandler.health_graves_dug < 5)
        {
            isDug = true;
        }
        else
        {
            isDug = false;
        }
    }

    public bool CanDigGrave()
    {
        return !isDug;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DigGrave();
        }
    }

    public void DigGrave()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (CanDigGrave())
            {
                isDug = true;
                grave.GetComponent<SpriteRenderer>().sprite = DugGraveSprite;
                InteractionText.SetActive(true);
                StartCoroutine(DelayInteractionText());
            }
            else
            {
                GrandmaText.SetActive(true);
                StartCoroutine(DelayGrandmaText());
            }
        }
    }

    public IEnumerator DelayInteractionText()
    {
        yield return new WaitForSeconds(2f);
        InteractionText.SetActive(false);
        SceneManager.LoadScene("WinScene");
    }
    
    public IEnumerator DelayGrandmaText()
    {
        yield return new WaitForSeconds(2f);
        GrandmaText.SetActive(false);
    }
}
