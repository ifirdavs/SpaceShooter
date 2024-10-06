using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float moveSpeed;


    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        if (Input.GetKey(KeyCode.W) && transform.position.y < 5.0f) {
            transform.Translate(0f, moveSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.S) && transform.position.y > -5.0f) {
            transform.Translate(0f, -moveSpeed * Time.deltaTime, 0f);
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 8.9f) {
            transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
        }

        if (Input.GetKey(KeyCode.A) && transform.position.x > -8.9f) {
            transform.Translate(-moveSpeed * Time.deltaTime, 0f, 0f);
        }
    }

}
