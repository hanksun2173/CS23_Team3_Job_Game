using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GraveDig : MonoBehaviour
{
    public GameObject grave;
    public bool isDug { get; private set; } = false;
    public string GraveID;
    public Sprite DugGraveSprite;

    void Start(){
        GraveID = $"{gameObject.transform.position.x}_{gameObject.transform.position.y}";
    }
    public bool CanDigGrave() {
        return !isDug;
    }

    public void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            DigGrave();
        }
    }

    public void DigGrave() {
        if (Input.GetKey(KeyCode.E)) {
            Debug.Log("Digging Grave");
            if (CanDigGrave()) {
                isDug = true;
                grave.GetComponent<SpriteRenderer>().sprite = DugGraveSprite;
            }
        }
    }
}
