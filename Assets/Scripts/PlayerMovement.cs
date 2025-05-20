using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); // A/D or Left/Right
        float vertical = Input.GetAxisRaw("Vertical");     // W/S or Up/Down

        Vector3 move = new Vector3(horizontal, 0f, vertical).normalized;
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}
