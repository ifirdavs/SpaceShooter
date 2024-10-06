using UnityEngine;
using System.Collections;

public class EnemyBehavior : MonoBehaviour {

    public GameObject target;
    public GameObject explosion;
    public float moveSpeed;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            target.GetComponent<GameStats>().decreaseLife(20);
            Instantiate(explosion, this.transform.position, this.transform.rotation);
            Destroy(this.gameObject);
        }
    }


    // Use this for initialization
    void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
        explosion = (GameObject)Resources.Load("Explosion");
    }

    // Update is called once per frame
    void Update() {

    }


    void FixedUpdate() {
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, moveSpeed * Time.deltaTime);
        Vector2 direction = target.transform.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 5f * Time.deltaTime);
    }


}
