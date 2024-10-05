using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    private float padding = 0.5f;
    private BoxCollider2D boxCollider;
    Vector2 minBounds;
    Vector2 maxBounds;

    Shooter shooter;
    private float originalSpeed;
    private Health health;

    void Awake()
    {
        shooter = GetComponent<Shooter>();
        health = GetComponent<Health>();
        originalSpeed = speed;
    }

    void Start()
    {
        initBounds();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void initBounds()
    {
        Camera cam = Camera.main;
        minBounds = cam.ScreenToWorldPoint(new Vector2(0, 0));
        maxBounds = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void FixedUpdate()
    {
        // Get keyboard input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontal, vertical);

        transform.Translate(movement * speed * Time.deltaTime);

        // Clamp position to screen bounds
        Vector2 newPosition = new Vector2();
        newPosition.x = Mathf.Clamp(transform.position.x, minBounds.x + padding, maxBounds.x - padding);
        newPosition.y = Mathf.Clamp(transform.position.y, minBounds.y + padding, maxBounds.y - padding);
        transform.position = newPosition;
    }

    void Update()
    {
        // Check for space bar input for shooting
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shooter.isFiring = true;
        }
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            shooter.isFiring = false;
        }
    }

    public void ActivatePowerUp(PowerUpType type, float duration)
    {
        switch (type)
        {
            case PowerUpType.TripleShot:
                StartCoroutine(ActivateTripleShot(duration));
                break;

            case PowerUpType.Speed:
                StartCoroutine(ActivateSpeedBoost(duration));
                break;
        }
    }

    public void IncreaseHealth(int amount)
    {
        health.IncreaseHealth(amount);
    }

    IEnumerator ActivateTripleShot(float duration)
    {
        shooter.isTripleShotActive = true;
        yield return new WaitForSeconds(duration);
        shooter.isTripleShotActive = false;
    }

    IEnumerator ActivateSpeedBoost(float duration)
    {
        speed *= 2;
        yield return new WaitForSeconds(duration);
        speed = originalSpeed;
    }
}