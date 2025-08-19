using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingButtons : MonoBehaviour
{
    [SerializeField] private InterfaceManagement interfaceManagement;
    [SerializeField] private PlayerMovement playerMovement;

    public void ButtonTreatment()
    {
        interfaceManagement.IsActiveButtons(false);
        interfaceManagement.CalculationForTreatment();
        playerMovement.IsActiveMovement(true);
    }

    public void ButtonSpeedAttack()
    {
        interfaceManagement.IsActiveButtons(false);
        interfaceManagement.CalculationForSpeedAttack();
        playerMovement.IsActiveMovement(true);
    }

    public void ButtonMeaningAttack()
    {
        interfaceManagement.IsActiveButtons(false);
        interfaceManagement.CalculationForMeaningAttack();
        playerMovement.IsActiveMovement(true);
    }

    public void ButtonToBegin()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void ButtonExitInMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ButtonExit()
    {
        Application.Quit();
    }
}
