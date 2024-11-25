using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] protected Transform target;
    [SerializeField] protected float smoot = 10;
    private void Start()
    {
        if (target == null)
        {
            target = GameObject.FindGameObjectWithTag("Player").transform;
        }
    }

    private void Update()
    {
        Vector2 lerp = Vector2.Lerp(transform.position, target.position, smoot);
        transform.position = new(lerp.x, lerp.y, -10);
    }
}