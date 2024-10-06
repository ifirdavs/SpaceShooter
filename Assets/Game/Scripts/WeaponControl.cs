using UnityEngine;
using System.Collections;

public class WeaponControl : MonoBehaviour {

    public GameObject bullet;
    public GameObject player;
    private float delay;


    // Use this for initialization
    void Start() {
        bullet = (GameObject)Resources.Load("Bullet");
        player = GameObject.FindGameObjectWithTag("Player");
        delay = Time.time;
    }


    // Update is called once per frame
    void Update() {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, 100f * Time.deltaTime);


        if (Input.GetMouseButton(0) && player.GetComponent<GameStats>().isPaused == false && Time.time >= delay) {
            if (player.gameObject.GetComponent<GameStats>().specialActived == false) {
                Instantiate(bullet, transform.position, transform.rotation);
            } else {
                bullet.transform.rotation = transform.rotation;
                Instantiate(bullet, transform.position, transform.rotation);
                bullet.transform.Rotate(new Vector3(0f, 0f, 90f));
                Instantiate(bullet, transform.position, bullet.transform.rotation);
                bullet.transform.Rotate(new Vector3(0f, 0f, 90f));
                Instantiate(bullet, transform.position, bullet.transform.rotation);
                bullet.transform.Rotate(new Vector3(0f, 0f, 90f));
                Instantiate(bullet, transform.position, bullet.transform.rotation);
            }
            delay = Time.time + 0.175f;
        }

    }

    void FixedUpdate() {



    }
}
