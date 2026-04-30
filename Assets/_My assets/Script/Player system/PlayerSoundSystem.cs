using UnityEngine;

public class PlayerSoundSystem : MonoBehaviour
{
    [Header("Rolling")]
    [SerializeField] private AudioSource rollSource;
    [SerializeField] private float minSpeedToRoll = 0.2f;
    [SerializeField] private float maxSpeed = 15f;

    Rigidbody ballRb;
    bool isGrounded;
    float speed;

    [SerializeField] private Vector2 volumeMinMax;
    [SerializeField] private Vector2 pitchMinMax;

    [Header ("Impact")]
    [SerializeField] AudioSource impactSource;
    [SerializeField] float minImpactForce = 2f;
    [SerializeField] float maxImpactForce = 20f;

    void Awake()
    {
        ballRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        speed = ballRb.linearVelocity.magnitude;

        if (isGrounded && speed > minSpeedToRoll)
        {
            if (!rollSource.isPlaying)
                rollSource.Play();

            float normalizedSpeed = Mathf.InverseLerp(minSpeedToRoll, maxSpeed, speed);
            rollSource.volume = Mathf.Lerp(volumeMinMax.x, volumeMinMax.y, normalizedSpeed);
            rollSource.pitch = Mathf.Lerp(pitchMinMax.x, pitchMinMax.y, normalizedSpeed);
        }
        else
        {
            rollSource.volume = Mathf.Lerp(rollSource.volume, 0f, Time.deltaTime * 15f);
            if (rollSource.volume < 0.01f)
                rollSource.Stop();
        }
    }

    void OnCollisionStay(Collision collision)
    {
        if (collision.collider.CompareTag ("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    

    void OnCollisionEnter(Collision collision)
    {
        float impactForce = collision.impulse.magnitude;

        if (impactForce < minImpactForce)
            return;

        float normalizedImpact = Mathf.InverseLerp(minImpactForce, maxImpactForce, impactForce);

        impactSource.volume = Mathf.Lerp(0.15f, 0.2f, normalizedImpact);
        impactSource.pitch = Random.Range(0.9f, 1.1f); // slight variation
        impactSource.PlayOneShot(impactSource.clip);
    }
}
