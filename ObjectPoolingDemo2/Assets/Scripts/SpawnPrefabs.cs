using UnityEngine;

public class SpawnPrefabs : MonoBehaviour
{
    [SerializeField] GameObject square;
    [SerializeField] GameObject circle;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PoolManager.Instance.GetFromPool(square).transform.position = transform.position;
        }
        else if (Input.GetKeyDown(KeyCode.A))
        {
            PoolManager.Instance.GetFromPool(circle).transform.position = transform.position;
        }
    }
}
