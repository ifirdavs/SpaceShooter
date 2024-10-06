using UnityEngine;
using System.Collections;

public class BackgroundManagement : MonoBehaviour {

    public GameObject ship;

    // Use this for initialization
    void Start() {
        ship = (GameObject)Resources.Load("Ship");
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {

    }


    IEnumerator Spawn() {
        while (true) {
            yield return new WaitForSeconds(Random.Range(1f, 2f));
            for (int i = 0; i < 3; i++) {
                Vector3 spawn = new Vector3(-10f, Random.Range(-4.25f, 4.25f), 0f);
                Instantiate(ship, spawn, ship.transform.rotation);
            }
        }
    }
}
