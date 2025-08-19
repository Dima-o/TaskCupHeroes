using UnityEngine;

public class StopPlayer : MonoBehaviour
{
    //Подумать над названием скрипта (остановка перед боем)!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private EnemyMovement[] enemyMovement;
    [SerializeField] private Shooter shooter;
    [SerializeField] private CheckingEnemies checkingEnemies;
    [SerializeField] private float preFightDelayTimer;

    private bool _activeTimer;

    private void Update()
    {
        if (_activeTimer)
        {
            StartingFight();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _activeTimer = true;
            playerMovement.IsActiveMovement(false);
            checkingEnemies.IsActiveFindEnemiesInRadius(true);
        }
    }

    private void StartingFight()
    {
        preFightDelayTimer -= Time.deltaTime;

        if (preFightDelayTimer <= 0)
        {
            _activeTimer = false;
            for (int i = 0; i < enemyMovement.Length; i++)
            {
                enemyMovement[i].IsActiveMovement(true);
            }
            shooter.IsActiveShoot(true);
        }
    }
}
