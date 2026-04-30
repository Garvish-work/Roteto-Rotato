using UnityEngine;

public class PlayerSystem : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] private Transform shadowHolder;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.sleepThreshold = 0;

    }

    private void Update()
    {
        shadowHolder.position = transform.position;
    }

    void FixedUpdate()
    {
        //rb.AddForce(Vector3.forward * 0.1f, ForceMode.Impulse);
    }
}
