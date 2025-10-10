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
    public Vector2 dugColliderSize = new Vector2(2.5f, 5f);
    private GameHandler gameHandler;
    private BoxCollider2D boxCollider;


    void Start()
    {
        gameHandler = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        if (gameHandler == null)
        {
            Debug.LogError("GameHandler not found in scene!");
        }
        
        // Get the BoxCollider2D component
        boxCollider = GetComponent<BoxCollider2D>();
        if (boxCollider == null)
        {
            Debug.LogError("BoxCollider2D not found on " + gameObject.name);
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
                
                // Change the box collider size after digging
                if (boxCollider != null)
                {
                    boxCollider.size = dugColliderSize;
                }
                
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
        yield return new WaitForSeconds(3.5f);
        InteractionText.SetActive(false);
        SceneManager.LoadScene("Battle");
    }
}
