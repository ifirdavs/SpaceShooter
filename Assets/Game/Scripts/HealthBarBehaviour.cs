using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehaviour : MonoBehaviour {

    public GameObject health;

    // Start is called before the first frame update
    void Start() {
        health = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        float vita = health.GetComponent<GameStats>().health;
        vita /= 100;
        if (vita < 0) {
            vita = 0;
        }
        this.gameObject.transform.localScale = new Vector3(vita, 1f, 1f);
    }
}
