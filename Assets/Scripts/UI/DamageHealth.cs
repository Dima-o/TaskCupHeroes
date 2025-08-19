using UnityEngine;
using UnityEngine.UI;

public class DamageHealth : MonoBehaviour
{
    [SerializeField] private GameObject gameObjectTextDamage;
    [SerializeField] private Text textDamage;
    
    private HealthSystem _healthSystem;
    private Shooter _shooter;

    private float _timerDisplayDamage;
    private bool _activeDisplayDamage;

    private void Start()
    {
        _healthSystem = GetComponent<HealthSystem>();
        UpdateTimer();
    }

    private void Update()
    {
        if (_activeDisplayDamage)
        {
            DisplayDamage();
        }
        else
        {
            gameObjectTextDamage.SetActive(false);
        }
    }

    private void DisplayDamage()
    {
        float _damage = _healthSystem.GettingTheDamageData();
        textDamage.text = "-" + _damage.ToString();

        gameObjectTextDamage.SetActive(true);

        _timerDisplayDamage -= Time.deltaTime;

        if (_timerDisplayDamage < 0)
        {
            IsActiveDisplayDamage(false);
            UpdateTimer();
        }
    }

    private void UpdateTimer()
    {
        _shooter = GetComponent<Shooter>();

        if (_shooter != null)
        {
            _timerDisplayDamage = _shooter.FireRate();
        }
        else
        {
            _timerDisplayDamage = 0.2f;
        }
    }

    public void IsActiveDisplayDamage(bool active)
    {
        _activeDisplayDamage = active;
    }
}
