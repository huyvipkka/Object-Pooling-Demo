using UnityEngine;
using UnityEngine.Pool;
public class ObjectPooling : MonoBehaviour
{
    public static ObjectPooling Instance { get; set; }

    public ObjectPool<Projectile> projectilePool;
    [SerializeField] protected Projectile ProjectilePrefab;
    private void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else Instance = this;
        DontDestroyOnLoad(gameObject);

        projectilePool = new ObjectPool<Projectile>(CreateFunc,
                ActionOnGet, ActionOnRelease, ActionOnDestroy,
                collectionCheck: true, defaultCapacity: 100, maxSize: 1000);
    }
    private Projectile CreateFunc()
    {
        Projectile obj = Instantiate(ProjectilePrefab);
        return obj;
    }

    private void ActionOnGet(Projectile obj)
    {
        obj.rb.transform.parent = transform;
    }

    private void ActionOnRelease(Projectile obj)
    {
        obj.gameObject.SetActive(false);
    }

    private void ActionOnDestroy(Projectile obj)
    {
        Destroy(obj);
    }
}