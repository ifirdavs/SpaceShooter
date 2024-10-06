using UnityEngine;
using System.Collections;

public class EnemiesSpawn : MonoBehaviour {

    public GameObject enemy;
    public GameObject shootingEnemy;
    public GameObject bigEnemy;

    // Use this for initialization
    void Start() {
        enemy = (GameObject)Resources.Load("Enemy");
        shootingEnemy = (GameObject)Resources.Load("ShootingEnemy");
        bigEnemy = (GameObject)Resources.Load("BigEnemy");
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update() {

    }

    void FixedUpdate() {

    }


    IEnumerator Spawn() {
        Vector3 spawn;
        while (true) {
            Debug.Log(Time.timeSinceLevelLoad);
            if (Time.timeSinceLevelLoad < 30f) {
                yield return new WaitForSeconds(1.5f);
                spawn = new Vector3(Random.Range(-9.5f, 9.5f), 6f, 0f);
                Instantiate(enemy, spawn, enemy.transform.rotation);
                spawn = new Vector3(Random.Range(-9.5f, 9.5f), -6f, 0f);
                Instantiate(enemy, spawn, enemy.transform.rotation);
            } else if (Time.timeSinceLevelLoad >= 30f && Time.timeSinceLevelLoad < 60f) {
                yield return new WaitForSeconds(1f);
                spawn = new Vector3(Random.Range(-9.5f, 9.5f), 6f, 0f);
                Instantiate(enemy, spawn, enemy.transform.rotation);
                spawn = new Vector3(Random.Range(-9.5f, 9.5f), -6f, 0f);
                Instantiate(enemy, spawn, enemy.transform.rotation);
            } else if (Time.timeSinceLevelLoad >= 60f && Time.timeSinceLevelLoad < 80) {
                yield return new WaitForSeconds(2f);
                spawn = new Vector3(Random.Range(-9.5f, 9.5f), 6f, 0f);
                Instantiate(enemy, spawn, enemy.transform.rotation);
                spawn = new Vector3(Random.Range(-9.5f, 9.5f), -6f, 0f);
                Instantiate(enemy, spawn, enemy.transform.rotation);
                yield return new WaitForSeconds(0.5f);
                spawn = new Vector3(-9.5f, Random.Range(-5f, 5f), 0f);
                Instantiate(shootingEnemy, spawn, shootingEnemy.transform.rotation);
                spawn = new Vector3(9.5f, Random.Range(-5f, 5f), 0f);
                Instantiate(shootingEnemy, spawn, shootingEnemy.transform.rotation);
            } else if (Time.timeSinceLevelLoad >= 80f && Time.timeSinceLevelLoad < 120f) {
                yield return new WaitForSeconds(2f);
                spawn = new Vector3(Random.Range(-9.5f, 9.5f), 6f, 0f);
                Instantiate(enemy, spawn, enemy.transform.rotation);
                spawn = new Vector3(Random.Range(-9.5f, 9.5f), -6f, 0f);
                Instantiate(enemy, spawn, enemy.transform.rotation);
                yield return new WaitForSeconds(1f);
                spawn = new Vector3(-9.5f, Random.Range(-5f, 5f), 0f);
                Instantiate(shootingEnemy, spawn, shootingEnemy.transform.rotation);
                spawn = new Vector3(10f, Random.Range(-5f, 5f), 0f);
                Instantiate(bigEnemy, spawn, shootingEnemy.transform.rotation);
            } else if (Time.timeSinceLevelLoad >= 120f && Time.timeSinceLevelLoad < 150) {
                yield return new WaitForSeconds(1.5f);
                spawn = new Vector3(Random.Range(-9.5f, 9.5f), 6f, 0f);
                Instantiate(shootingEnemy, spawn, enemy.transform.rotation);
                spawn = new Vector3(Random.Range(-9.5f, 9.5f), -6f, 0f);
                Instantiate(shootingEnemy, spawn, enemy.transform.rotation);
                yield return new WaitForSeconds(1.5f);
                spawn = new Vector3(-9.5f, Random.Range(-5f, 5f), 0f);
                Instantiate(shootingEnemy, spawn, shootingEnemy.transform.rotation);
                spawn = new Vector3(10f, Random.Range(-5f, 5f), 0f);
                Instantiate(shootingEnemy, spawn, shootingEnemy.transform.rotation);
            } else {
                yield return new WaitForSeconds(3f);
                spawn = new Vector3(10f, Random.Range(-5f, 5f), 0f);
                Instantiate(bigEnemy, spawn, shootingEnemy.transform.rotation);
                spawn = new Vector3(-10f, Random.Range(-5f, 5f), 0f);
                Instantiate(bigEnemy, spawn, shootingEnemy.transform.rotation);
                yield return new WaitForSeconds(1f);
                spawn = new Vector3(Random.Range(-9.5f, 9.5f), 6f, 0f);
                Instantiate(shootingEnemy, spawn, enemy.transform.rotation);
                spawn = new Vector3(Random.Range(-9.5f, 9.5f), -6f, 0f);
                Instantiate(enemy, spawn, enemy.transform.rotation);
            }

        }
    }

}
