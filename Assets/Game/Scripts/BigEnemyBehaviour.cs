using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigEnemyBehaviour : MonoBehaviour {

    public float moveSpeed;
    int health;
    public GameObject bullet;
    public GameObject player;
    public GameObject explosion;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            player.GetComponent<GameStats>().decreaseLife(50);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
        if (col.gameObject.tag == "Bullet") {
            Destroy(col.gameObject);
            health--;
        }
    }


    // Start is called before the first frame update
    void Start() {
        bullet = (GameObject)Resources.Load("EnemyLaser");
        bullet.gameObject.GetComponent<EnemyBulletBehaviour>().moveSpeed = 8f;
        player = GameObject.FindGameObjectWithTag("Player");
        explosion = (GameObject)Resources.Load("Explosion");
        health = 5;
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
        if (health == 0) {
            player.GetComponent<GameStats>().increasePoint(300);
            player.GetComponent<GameStats>().increaseSpecialPoint(300);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }


    IEnumerator EnemyShoot() {
        while (true) {
            yield return new WaitForSeconds(3f);
            bullet.transform.rotation = transform.rotation;
            Instantiate(bullet, transform.position, bullet.transform.rotation);
            bullet.transform.Rotate(new Vector3(0f, 0f, 20f));
            Instantiate(bullet, transform.position, bullet.transform.rotation);
            bullet.transform.Rotate(new Vector3(0f, 0f, -40f));
            Instantiate(bullet, transform.position, bullet.transform.rotation);
        }
    }

}
