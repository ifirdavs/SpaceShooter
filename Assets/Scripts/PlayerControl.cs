//2110021
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 5f;
    public GameObject bulletPrefab;
    public float bulletSpeed = 10f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

     void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }

    void FixedUpdate()
    {
        float move = Input.GetAxisRaw("Horizontal");
        Vector2 newPosition = rb.position + Vector2.right * move * speed * Time.fixedDeltaTime;
        newPosition.x = Mathf.Clamp(newPosition.x, -849f, 850f); // Borders
        rb.MovePosition(newPosition);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = Vector2.up * bulletSpeed;
    }
}
