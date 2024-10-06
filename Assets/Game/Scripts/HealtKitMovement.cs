using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealtKitMovement : MonoBehaviour {
    // Start is called before the first frame update

    public float moveSpeed;
    public GameObject player;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            player.GetComponent<GameStats>().health = 100f;
            Destroy(this.gameObject);
        }
    }

    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        moveSpeed = 2f;
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
        if (transform.position.x > 15f || transform.position.x < -15f) {
            Destroy(this.gameObject);
        }
    }
}
