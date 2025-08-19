using UnityEngine;
using UnityEngine.UI;

public class InterfaceManagement : MonoBehaviour
{
    [SerializeField] private Text textSpeedAttack;
    [SerializeField] private Text textMeaningAttack;
    [SerializeField] private Text textCurrency;
    [SerializeField] private GameObject gameObjectButttonTreatment;
    [SerializeField] private GameObject gameObjectButttonSpeedAttack;
    [SerializeField] private GameObject gameObjectButttonMeaningAttack;
    [SerializeField] private Button butttonTreatment;
    [SerializeField] private Button butttonSpeedAttack;
    [SerializeField] private Button butttonMeaningAttack;
    [SerializeField] private int costTreatment = 2;
    [SerializeField] private int costSpeedAttack = 3;
    [SerializeField] private int costMeaningAttack = 1;
    [SerializeField] private int valueImprovementTreatment = 10;
    [SerializeField] private int valueImprovementSpeedAttack = 2;
    [SerializeField] private int valueImprovementMeaningAttack = 10;

    private Shooter _shooter;
    private PlayerHealth _playerHealth;

    private float _speedAttack;
    private int _currency;

    private void Start()
    {
        _shooter = GetComponent<Shooter>();
        _playerHealth = GetComponent<PlayerHealth>();
    }

    private void Update()
    {
        BroadcastSpeedAttack();
        BroadcastMeaningAttack();
        _currency = int.Parse(textCurrency.text);
    }

    private void BroadcastSpeedAttack()
    {
        _speedAttack = 1 / _shooter.FireRate();
        textSpeedAttack.text = "x" + _speedAttack.ToString();
    }

    private void BroadcastMeaningAttack()
    {
        textMeaningAttack.text = _shooter.arrowDamage.ToString();
    }

    public void IsActiveButtons(bool active)
    {
        if (active)
        {
            gameObjectButttonTreatment.SetActive(true);
            gameObjectButttonSpeedAttack.SetActive(true);
            gameObjectButttonMeaningAttack.SetActive(true);

            CheckingPurchaseAvailability();
        }
        else
        {
            gameObjectButttonTreatment.SetActive(false);
            gameObjectButttonSpeedAttack.SetActive(false);
            gameObjectButttonMeaningAttack.SetActive(false);

            butttonTreatment.interactable = false;
            butttonSpeedAttack.interactable = false;
            butttonMeaningAttack.interactable = false;

            Time.timeScale = 1;
        }
    }

    public void CalculationForTreatment()
    {
        _playerHealth.HealthValues(valueImprovementTreatment);
        CurrencyTransactions(costTreatment);
    }

    public void CalculationForSpeedAttack()
    {
        _shooter.fireRate /= valueImprovementSpeedAttack;
        CurrencyTransactions(costSpeedAttack);
    }

    public void CalculationForMeaningAttack()
    {
        _shooter.arrowDamage += valueImprovementMeaningAttack;
        CurrencyTransactions(costMeaningAttack);
    }

    private void CurrencyTransactions(int cost)
    {
        _currency -= cost;
        textCurrency.text = _currency.ToString();
    }

    private void CheckingPurchaseAvailability()
    {
        _currency = int.Parse(textCurrency.text);

        var buttonsAndCosts = new (Button button, int cost)[]
        {
        (butttonTreatment, costTreatment),
        (butttonSpeedAttack, costSpeedAttack),
        (butttonMeaningAttack, costMeaningAttack)
        };

        foreach (var item in buttonsAndCosts)
        {
            item.button.interactable = item.cost <= _currency;
        }
    }
}
