using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialBarBehaviour : MonoBehaviour {

    public GameObject special;
    private float end;
    // Start is called before the first frame update
    void Start() {
        special = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update() {
        if (special.gameObject.GetComponent<GameStats>().specialActived == false) {
            int threshold = special.gameObject.GetComponent<GameStats>().special;
            float points = special.gameObject.GetComponent<GameStats>().specialPoints;
            if (points > threshold)
                points = threshold;
            float bar = points / threshold;
            this.gameObject.transform.localScale = new Vector3(bar, 1f, 1f);
            if (bar >= 1f && Input.GetKeyDown(KeyCode.Space)) {
                special.gameObject.GetComponent<GameStats>().specialActived = true;
                end = Time.time + 10;
            }
        } else {
            float bar = (end - Time.time) / 10;
            if (bar <= 0) {
                special.gameObject.GetComponent<GameStats>().specialActived = false;
                special.gameObject.GetComponent<GameStats>().specialPoints = 0;
            }
            this.gameObject.transform.localScale = new Vector3(bar, 1f, 1f);
        }
    }

    void FixedUpdate() {

    }
}
