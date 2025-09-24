using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

     public Rigidbody2D rb;
     public float moveSpeed = 5f;
     public Vector2 movement;
    //  public GameHandler gameHandlerObj;

     void Start(){
          rb = GetComponent<Rigidbody2D> ();
        //   if (GameObject.FindWithTag("GameHandler") != null){
        //        gameHandlerObj = GameObject.FindWithTag("GameHandler").GetComponent<GameHandler>();
        //   }
     }

     void FixedUpdate(){
          movement.x = Input.GetAxisRaw ("Horizontal");
          movement.y = Input.GetAxisRaw ("Vertical");
          rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
     }

}