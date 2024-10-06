using System.Collections;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [Header("General")]
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] float projectileSpeed = 10f;
    [SerializeField] float projectileLifeTime = 5f;
    [SerializeField] float baseFiringRate = 0.2f;

    [Header("AI")]
    [SerializeField] bool useAI;
    [SerializeField] float firingRateVariance = 0f;
    [SerializeField] float minimumFiringRate = 0.1f;

    Coroutine firingCoroutine;
    AudioPlayer audioPlayer;
    [HideInInspector] public bool isFiring;
    [HideInInspector] public bool isTripleShotActive;

    void Awake()
    {
        audioPlayer = FindObjectOfType<AudioPlayer>();
    }

    void Start()
    {
        if (useAI)
        {
            isFiring = true;
        }
        else
        {
            isFiring = false;
        }
    }

    void Update()
    {
        Fire();
    }

    void Fire()
    {
        if (isFiring && firingCoroutine == null)
        {
            firingCoroutine = StartCoroutine(FireContinuously());
        }
        else if (!isFiring && firingCoroutine != null)
        {
            StopCoroutine(firingCoroutine);
            firingCoroutine = null;
        }
    }

    IEnumerator FireContinuously()
    {
        while (true)
        {
            if (isTripleShotActive)
            {
                FireTripleShot();
            }
            else
            {
                FireSingleShot();
            }
            
            float timeToNextProjectile = Random.Range(baseFiringRate - firingRateVariance, baseFiringRate + firingRateVariance);
            timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumFiringRate, float.MaxValue);
            audioPlayer.PlayShootingSound();
            yield return new WaitForSeconds(timeToNextProjectile);
        }
    }

    void FireSingleShot()
    {
        GameObject instance = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * projectileSpeed;
        }
        Destroy(instance, projectileLifeTime);
    }

    void FireTripleShot()
    {
        Vector3 leftOffset = transform.position + new Vector3(-0.5f, 0, 0);
        Vector3 rightOffset = transform.position + new Vector3(0.5f, 0, 0);

        FireProjectile(transform.position); // Center shot
        FireProjectile(leftOffset); // Left shot
        FireProjectile(rightOffset); // Right shot
    }

    void FireProjectile(Vector3 position)
    {
        GameObject instance = Instantiate(projectilePrefab, position, Quaternion.identity);
        Rigidbody2D rb = instance.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = transform.up * projectileSpeed;
        }
        Destroy(instance, projectileLifeTime);
    }
}