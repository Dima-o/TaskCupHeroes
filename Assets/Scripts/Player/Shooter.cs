using UnityEngine;
using UnityEngine.UI;

public class Shooter : MonoBehaviour
{
    [Header("Bullet Settings")]
    [SerializeField] private GameObject bullet;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireSpeed = 10f;
    [SerializeField] private float gravityScale = 1f;

    [Header("Angle Control")]
    [SerializeField] private Slider angleSlider;
    [SerializeField] private float minAngle = 15f;
    [SerializeField] private float maxAngle = 75f;
    [SerializeField] private Text angleDisplayText;

    [HideInInspector] public float fireRate;
    [HideInInspector] public int arrowDamage;

    private GameObject _currentBullet;
    private Rigidbody2D _currentBulletVelocity;

    private float _nextFireTime;
    private float _timer;
    private float currentAngle;
    private bool _activeShoot;

    private void Start()
    {
        angleSlider.minValue = minAngle;
        angleSlider.maxValue = maxAngle;
        angleSlider.value = 45f;

        angleSlider.onValueChanged.AddListener(UpdateShootingAngle);

        UpdateShootingAngle(angleSlider.value);
    }

    private void Update()
    {
        if (_activeShoot)
        {
            _timer = Time.time;

            if (_timer >= _nextFireTime)
            {
                Shoot();
                _nextFireTime = Time.time + fireRate;
            }
        } 
    }

    private void Shoot()
    {
        if (bullet == null || firePoint == null)
        {
            Debug.LogWarning("Bullet prefab or fire point not set!");
            return;
        }

        // Создаем пулю
        _currentBullet = Instantiate(bullet, firePoint.position, Quaternion.identity);
        _currentBullet.GetComponent<DamageEnemy>().damage = arrowDamage;

        // Задаем скорость пули
        _currentBulletVelocity = _currentBullet.GetComponent<Rigidbody2D>();

        if (_currentBulletVelocity != null)
        {
            DirectionShootSpeed(fireSpeed);
        }
        else
        {
            Debug.LogWarning("Bullet prefab has no Rigidbody2D component!");
        }
    }

    private void DirectionShootSpeed(float _fireSpeed)
    {
        _currentBulletVelocity.gravityScale = 1f;

        // Рассчитываем скорость по углу
        float radAngle = currentAngle * Mathf.Deg2Rad;
        Vector2 velocity = new Vector2(
            Mathf.Cos(radAngle) * _fireSpeed,
            Mathf.Sin(radAngle) * _fireSpeed
        );

        _currentBulletVelocity.velocity = velocity;
    }

    private void UpdateShootingAngle(float newAngle)
    {
        currentAngle = newAngle;

        // Обновляем текст с текущим углом
        if (angleDisplayText != null)
        {
            angleDisplayText.text = $"Угол: {currentAngle:F0}°";
        }
    }

    public void IsActiveShoot(bool _active)
    {
        _activeShoot = _active;
    }

    public float FireRate()
    {
        return fireRate;
    }
}
