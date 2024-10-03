//2110021
using UnityEngine;

public class BulletController : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y > 580f) // Roof
        {
            Destroy(gameObject);
        }
    }
}
