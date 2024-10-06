using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletBehaviour : MonoBehaviour {
    public float moveSpeed;
    public GameObject player;
    public GameObject explosion;
    public GameObject enemy;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            player.GetComponent<GameStats>().decreaseLife(10);
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        explosion = (GameObject)Resources.Load("Explosion");
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
        if (transform.position.y > 6f || transform.position.y < -6f || transform.position.x > 9.5f || transform.position.x < -9.5f) {
            Destroy(this.gameObject);
        }
    }
}
