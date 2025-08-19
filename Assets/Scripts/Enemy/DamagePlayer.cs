using UnityEngine;

public class DamagePlayer : MonoBehaviour
{
    [SerializeField] private float damage;

    private EnemyMovement _enemyMovement;

    private void Start()
    {
        _enemyMovement = GetComponent<EnemyMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthSystem>().TakeDamage(damage);
            _enemyMovement.DiscardEnemy();
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            bool thisEnemyIsBehind = transform.position.x > collision.transform.position.x;

            if (thisEnemyIsBehind)
            {
                _enemyMovement.DiscardEnemy();
            }
        }
    }
}
