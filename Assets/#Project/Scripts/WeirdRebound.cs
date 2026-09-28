using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class WeirdRebound : MonoBehaviour
{
    private const string GROUND_TAG = "Ground";
    [SerializeField] private float randomFactor = 0.1f;
    private Rigidbody rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!collision.collider.CompareTag(GROUND_TAG))
            return;

        Vector2 circle = Random.insideUnitCircle * randomFactor;
        Vector3 direction = new(circle.x, 1f, circle.y);
        rb.linearVelocity = direction * collision.relativeVelocity.magnitude;
    }
}
