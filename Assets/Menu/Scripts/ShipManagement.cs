using UnityEngine;
using System.Collections;

public class ShipManagement : MonoBehaviour {

    private float moveSpeed;


    // Use this for initialization
    void Start() {
        moveSpeed = Random.Range(1f, 5f);
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {
        transform.Translate(moveSpeed * Time.deltaTime, 0f, 0f);
        if (this.transform.position.x > 10)
            Destroy(this.gameObject);
    }
}
