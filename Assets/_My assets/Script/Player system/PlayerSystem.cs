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
}
