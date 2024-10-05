using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> powerUpPrefabs;
    [SerializeField] float minSpawnInterval = 5f;
    [SerializeField] float maxSpawnInterval = 15f;

    private Camera mainCamera;

    private void Start()
    {
        mainCamera = Camera.main;
        StartCoroutine(SpawnPowerUps());
    }

    private IEnumerator SpawnPowerUps()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(minSpawnInterval, maxSpawnInterval));
            SpawnPowerUp();
        }
    }

    private void SpawnPowerUp()
    {
        if (powerUpPrefabs.Count == 0) return;

        int randomIndex = Random.Range(0, powerUpPrefabs.Count);
        float randomX = RandomXPosition();
        float spawnY = mainCamera.ViewportToWorldPoint(new Vector3(0.5f, 1f, 0)).y;

        GameObject powerUp = Instantiate(powerUpPrefabs[randomIndex], new Vector3(randomX, spawnY, 0), Quaternion.identity);
        Debug.Log($"Spawning power-up {randomIndex} at ({randomX}, {spawnY})");
    }

    private float RandomXPosition()
    {
        float screenXMin = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, 0)).x;
        float screenXMax = mainCamera.ViewportToWorldPoint(new Vector3(1, 0, 0)).x;
        return Random.Range(screenXMin, screenXMax);
    }
}