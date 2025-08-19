using UnityEngine;

public class DeleteBullet : MonoBehaviour
{
    [SerializeField] private float timeDeleteBullet;

    private void Update()
    {
        timeDeleteBullet -= Time.deltaTime;
        
        if (timeDeleteBullet < 0 )
        {
            Destroy(gameObject);
        }
    }
}
