using UnityEngine;

public class Ground : MonoBehaviour
{
    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent(out Rigidbody2D orb))
        {
            orb.AddForce(Vector2.left * 25);
        }
    }
}
