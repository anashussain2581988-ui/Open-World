using UnityEngine;

public class CarController : MonoBehaviour
{
    [Header("Driving")]
    public float acceleration = 12f;
    public float maxSpeed = 25f;
    public float brakePower = 20f;
    public float steeringSpeed = 80f;

    [Header("References")]
    public Rigidbody carRigidbody;

    private float throttle;
    private float steering;

    private bool playerDriving;

    private void Start()
    {
        if (carRigidbody == null)
            carRigidbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (!playerDriving)
            return;

        throttle = Input.GetAxis("Vertical");
        steering = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        if (!playerDriving || carRigidbody == null)
            return;

        Drive();
        Steer();
        LimitSpeed();
    }

    private void Drive()
    {
        Vector3 force =
            transform.forward *
            throttle *
            acceleration;

        carRigidbody.AddForce(
            force,
            ForceMode.Acceleration
        );

        if (Input.GetKey(KeyCode.Space))
        {
            carRigidbody.linearVelocity *=
                1f - brakePower * Time.fixedDeltaTime;
        }
    }

    private void Steer()
    {
        float speedFactor =
            Mathf.Clamp01(
                carRigidbody.linearVelocity.magnitude /
                maxSpeed
            );

        float rotation =
            steering *
            steeringSpeed *
            speedFactor *
            Time.fixedDeltaTime;

        transform.Rotate(
            0f,
            rotation,
            0f
        );
    }

    private void LimitSpeed()
    {
        if (carRigidbody.linearVelocity.magnitude >
            maxSpeed)
        {
            carRigidbody.linearVelocity =
                carRigidbody.linearVelocity.normalized *
                maxSpeed;
        }
    }

    public void SetDriving(bool driving)
    {
        playerDriving = driving;
    }
}
