using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingEnemyBehaviour : MonoBehaviour {

    public float moveSpeed;
    public GameObject bullet;
    public GameObject player;
    public GameObject explosion;


    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            player.GetComponent<GameStats>().decreaseLife(20);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }


    // Start is called before the first frame update
    void Start() {
        bullet = (GameObject)Resources.Load("EnemyLaser");
        player = GameObject.FindGameObjectWithTag("Player");
        explosion = (GameObject)Resources.Load("Explosion");
        StartCoroutine(EnemyShoot());
    }

    // Update is called once per frame
    void Update() {


    }

    void FixedUpdate() {
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        Vector2 direction = player.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.deltaTime);
    }


    IEnumerator EnemyShoot() {
        while (true) {
            yield return new WaitForSeconds(1.5f);
            Vector2 direction = player.transform.position - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100f * Time.deltaTime);
            Vector3 spawnPoint = transform.position;
            Instantiate(bullet, spawnPoint, transform.rotation);
        }
    }

}
