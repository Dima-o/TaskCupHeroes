using UnityEngine.SceneManagement;

public class PlayerHealth : HealthSystem
{
    public void HealthValues(float plusHealth)
    {
        LinerBar.fillAmount += plusHealth / 100f;
        maxHealth += plusHealth;
    }

    protected override void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
        base.Die();
    }
}
