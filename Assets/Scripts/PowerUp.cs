using UnityEngine;

public enum PowerUpType
{
    TripleShot,
    Speed,
    HealthIncrease
}

public class PowerUp : MonoBehaviour
{
    public PowerUpType powerUpType;  // Type of the power-up
    public float duration = 8f;      // Duration of the power-up effect (not used for HealthIncrease)
    
    // For health increase power-up
    public int healthIncreaseAmount = 20;

    // Speed of the power-up movement
    [SerializeField] private float speed = 2f;

    private void Update()
    {
        // Move power-up downwards
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        // Destroy power-up if it goes off-screen
        if (transform.position.y < Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y - 1f)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name + " tagged as: " + collision.gameObject.tag);

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Collided with Player");
            Player player = collision.gameObject.GetComponent<Player>();

            if (player != null)
            {
                Debug.Log("Player component found, activating power-up");
                if (powerUpType == PowerUpType.HealthIncrease)
                {
                    player.IncreaseHealth(healthIncreaseAmount);
                }
                else
                {
                    player.ActivatePowerUp(powerUpType, duration);
                }
            }
            else
            {
                Debug.Log("Player component not found on the collided object.");
            }

            // Destroy the power-up object after it's collected
            Destroy(gameObject);
        }
    }
}