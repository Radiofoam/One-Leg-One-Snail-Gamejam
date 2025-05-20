using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    private Transform camTransform;
    [SerializeField] private Transform targetRoot;
    [SerializeField] private Transform camTarget;
    [SerializeField] private float speed;

    private float fov;
    [SerializeField] private float sensitivity;

    void Start()
    {
        camTransform = transform;
        fov = 40;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            camTransform.rotation = camTransform.rotation * Quaternion.Euler(0, 0, 0);

            camTransform.RotateAround(camTarget.position, Vector3.up, Input.GetAxis("Mouse X") * speed);
            camTransform.RotateAround(camTarget.position, camTransform.right, -Input.GetAxis("Mouse Y") * speed);
        }

        fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
        Camera.main.fieldOfView = fov;
    }
}
