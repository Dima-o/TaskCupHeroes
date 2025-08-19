using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : HealthSystem
{
    [SerializeField] private Text textCurrency;
    [SerializeField] private int scoreValue = 10;
    [SerializeField] private int sizeCurrency = 1;

    protected override void Die()
    {
        textCurrency.text = (int.Parse(textCurrency.text) + sizeCurrency).ToString();
        base.Die();
        Destroy(gameObject);
    }
}
