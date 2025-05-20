using System.Collections;
using UnityEngine;

public class snailMovement : MonoBehaviour
{
    public Transform player;
    public float maxSpeed = 5f;
    public float accelerateSpeed = 10f;
    public float decelerationSpeed = 10f;
    public float maxSpeedDuration = 2f;

    private float currentSpeed = 0f;
    private enum Phase { Accelerating, MaxSpeed, Decelerating }
    private Phase currentPhase = Phase.Accelerating;
    private float maxSpeedTimer = 0f;

    void Update()
    {
        if (player == null) return;

        Vector3 direction = (player.position - transform.position).normalized;

        switch (currentPhase)
        {
            case Phase.Accelerating:
                currentSpeed += accelerateSpeed * Time.deltaTime;
                if (currentSpeed >= maxSpeed)
                {
                    currentSpeed = maxSpeed;
                    currentPhase = Phase.MaxSpeed;
                    maxSpeedTimer = 0f;

                    // Random pitch (±3 semitones): from 0.89 to 1.12 approx
                    int semitones = Random.Range(-16, 10); // pitch
                    float pitch = Mathf.Pow(1.059463f, semitones); // Equal temperament formula

                    // Random volume between 0.8 and 1.0
                    float volume = Random.Range(0.7f, 1.0f);

                    AudioManager.instance.PlaySFX("Trail", pitch, volume);

                }
                break;

            case Phase.MaxSpeed:
                maxSpeedTimer += Time.deltaTime;
                if (maxSpeedTimer >= maxSpeedDuration)
                {
                    currentPhase = Phase.Decelerating;
                }
                break;

            case Phase.Decelerating:
                currentSpeed -= decelerationSpeed * Time.deltaTime;
                if (currentSpeed <= 0f)
                {
                    currentSpeed = 0f;
                    currentPhase = Phase.Accelerating;
                }
                break;
        }

        transform.Translate(direction * currentSpeed * Time.deltaTime, Space.World);
    }
}
