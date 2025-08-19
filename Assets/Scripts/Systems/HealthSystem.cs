using UnityEngine;
using UnityEngine.UI;

public class HealthSystem : MonoBehaviour
{
    [Header("Health Settings")]
    [SerializeField] private Text textHealth;
    public float maxHealth = 100f;
    public Image LinerBar;
    
    private DamageHealth _damageHealth;

    private float _damage;

    [HideInInspector] public float _realTimeHealth;

    private void Start()
    {
        _damageHealth =  GetComponent<DamageHealth>();
    }

    private void Update()
    {
        HealthDisplay();
    }

    private void HealthDisplay()
    {
        _realTimeHealth = LinerBar.fillAmount * 100;
        _realTimeHealth = Mathf.Clamp(maxHealth, 0, 100);

        textHealth.text = _realTimeHealth.ToString();
    }

    public float GettingTheDamageData()
    {
        return _damage;
    }

    public void TakeDamage(float damage)
    {
        maxHealth -= damage;
        _damage = damage;
        LinerBar.fillAmount = maxHealth / 100;

        _damageHealth.IsActiveDisplayDamage(true);


        if (maxHealth <= 0)
        {
            Die();
        }
    }

    protected virtual void Die()
    {
        if (gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        
    }
}