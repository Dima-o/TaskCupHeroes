using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] GameObject gameObjectTextFinish;
    [SerializeField] GameObject gameObjectButtonExit;

    private void Start()
    {
        Time.timeScale = 1;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            Time.timeScale = 0;

            gameObjectTextFinish.SetActive(true);
            gameObjectButtonExit.SetActive(true);
        }
    }
}
