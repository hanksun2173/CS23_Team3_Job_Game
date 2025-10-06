using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GraveDig : MonoBehaviour {
    public GameObject grave;
    public GameObject InteractionText;
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
    }

    public bool CanDigGrave() {
        return !isDug;
    }

    public void OnCollisionStay2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            DigGrave();
        }
    }

    public void DigGrave() {
        if (Input.GetKey(KeyCode.E)) {
            if (CanDigGrave())
            {
                isDug = true;
                grave.GetComponent<SpriteRenderer>().sprite = DugGraveSprite;
                if (gameObject.tag == "HealthGrave")
                {
                    InteractionText.SetActive(true);
                    gameHandler.AddHealth(1);
                    StartCoroutine(DelayInteractionText());
                }
                if (gameObject.tag == "HauntedGrave") {
                    InteractionText.SetActive(true);
                    StartCoroutine(DelayBattleScene());
                }
            }
        }
    }

    private IEnumerator DelayInteractionText() {
        yield return new WaitForSeconds(2f);
        InteractionText.SetActive(false);
    }

    private IEnumerator DelayBattleScene() {
        yield return new WaitForSeconds(2f);
        InteractionText.SetActive(false);
        SceneManager.LoadScene("Battle");
    }
}
