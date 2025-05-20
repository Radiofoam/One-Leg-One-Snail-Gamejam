using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    public Rigidbody rb;
    [SerializeField] public Transform camTransform;

    private Vector3 screenPoint;
    private Vector3 offset;

    private void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //print("mouse down");
        //rb.velocity = camTransform.forward * 100;
        //ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit) && hit.collider.CompareTag("Foot"))
        //{
            
        //}

        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        transform.position = new Vector3(curPosition.x, Mathf.Clamp(curPosition.y, curPosition.y, transform.position.y + 1f), curPosition.z);

    }

}
