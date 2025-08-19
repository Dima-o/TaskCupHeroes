using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float discardForce = 10f;
    [SerializeField] private float timerWihoutMovement;

    private Rigidbody2D _rb;

    private bool _activeMove;
    private bool _activeTimerWihoutMovement;

    private float _timer;

    private void Start()
    {
        _timer = timerWihoutMovement;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        if (_activeMove)
        {
            Move();
        }

        if (_activeTimerWihoutMovement)
        {
            TimeWihoutMovement();
        }
    }

    private void Move()
    {
        _rb.velocity = new Vector2(-moveSpeed, _rb.velocity.y);
    }

    public void DiscardEnemy()
    {
        _rb.AddForce(new Vector2(discardForce, 0f), ForceMode2D.Impulse);
        _activeTimerWihoutMovement = true;
        IsActiveMovement(false);
    }

    private void TimeWihoutMovement()
    {
        _timer -= Time.deltaTime;

        if (_timer < 0)
        {
            _activeTimerWihoutMovement = false;
            IsActiveMovement(true);
            _timer = timerWihoutMovement;
        }

    }

    public void IsActiveMovement(bool active)
    {
        _activeMove = active;
    }
}
