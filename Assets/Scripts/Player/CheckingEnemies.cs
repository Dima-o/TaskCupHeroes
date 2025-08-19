using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CheckingEnemies : MonoBehaviour
{
    [SerializeField] private string enemyTag = "Enemy";
    [SerializeField] private float detectionRange = 10f;

    private PlayerMovement _playerMovement;
    private InterfaceManagement _interfaceManagement;
    private Shooter _shooter;

    private bool _activeFindEnemiesInRadius;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _interfaceManagement = GetComponent<InterfaceManagement>();
        _shooter = GetComponent<Shooter>();
    }

    private void Update()
    {
        if (_activeFindEnemiesInRadius)
        {
            FindEnemiesInRadius();
        }
    }

    private void FindEnemiesInRadius()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(
            transform.position,
            detectionRange);

        bool enemyFound = false;

        foreach (Collider2D hit in hits)
        {
            if (hit.CompareTag(enemyTag))
            {
                enemyFound = true;
                _playerMovement.IsActiveMovement(false);
                break;
            }
        }

        if (!enemyFound)
        {
            _interfaceManagement.IsActiveButtons(true);
            IsActiveFindEnemiesInRadius(false);
            _shooter.IsActiveShoot(false);
            Time.timeScale = 0;
        }
    }

    public void IsActiveFindEnemiesInRadius(bool active)
    {
        _activeFindEnemiesInRadius = active;
    }
}
