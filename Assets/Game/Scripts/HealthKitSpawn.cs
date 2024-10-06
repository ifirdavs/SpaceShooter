using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthKitSpawn : MonoBehaviour {

    public GameObject health_kit;


    // Start is called before the first frame update
    void Start() {
        health_kit = (GameObject)Resources.Load("HealthKit");
        StartCoroutine(SpawnKit());
    }

    // Update is called once per frame
    void Update() {

    }

    IEnumerator SpawnKit() {
        Vector3 kitSpawn;
        while (true) {
            Debug.Log(Time.timeSinceLevelLoad);
            kitSpawn = new Vector3(-9.5f, Random.Range(-5f, 5f), 0f);
            yield return new WaitForSeconds(Random.Range(90f, 110f));
            Instantiate(health_kit, kitSpawn, health_kit.transform.rotation);
        }
    }


}
