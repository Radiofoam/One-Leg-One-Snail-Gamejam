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
        transform.LookAt(player.position);
    }
}
