using UnityEngine;

public class DamageEnemy : MonoBehaviour
{
    [HideInInspector] public float damage;

    private void OnCollisionEnter2D(Collision2D collision)
    { 
        if (collision.gameObject.CompareTag("Player"))
        {
            return;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}