using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Rigidbody2D rb;
    public float moveSpeed = 10f;
    public float collisionOffset = 0.05f;
    public Vector2 movement;
    public ContactFilter2D movementFilter;
    public RaycastHit2D[] castCollisions = new RaycastHit2D[10];

    void Start() {
        rb = GetComponent<Rigidbody2D> ();
    }

    public bool MovePlayer() {

        movement.x = Input.GetAxisRaw ("Horizontal");
        movement.y = Input.GetAxisRaw ("Vertical");

        if (movement != Vector2.zero) {
            int count = rb.Cast(
                movement.normalized,
                movementFilter,
                castCollisions,
                moveSpeed * Time.fixedDeltaTime + collisionOffset);

            if (count == 0){
                rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
                return true;
            } else {
                return false;
            }
        }
        
        return true;
    }

    void FixedUpdate() {
        bool moved = MovePlayer();
    }

}