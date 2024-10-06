using UnityEngine;
using System.Collections;

public class BulletBehaviour : MonoBehaviour {

    public float moveSpeed;
    public GameObject player;
    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Enemy") {
            player.GetComponent<GameStats>().increasePoint(100);
            player.GetComponent<GameStats>().increaseSpecialPoint(100);
            Instantiate(explosion, col.transform.position, col.transform.rotation);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "ShootinEnemy") {
            player.GetComponent<GameStats>().increasePoint(200);
            player.GetComponent<GameStats>().increaseSpecialPoint(200);
            Instantiate(explosion, col.transform.position, col.transform.rotation);
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }

    // Use this for initialization
    void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        explosion = (GameObject)Resources.Load("Explosion");
        transform.position = player.transform.position;
        transform.Translate(0.75f, 0f, 0f);
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
