using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class MovementScript : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;

    public Rigidbody rb;
    [SerializeField] public Transform camTransform;

    private Vector3 screenPoint;
    private Vector3 offset;
    private Vector3 originalFootTransform;

    private bool isHipLock;
    [SerializeField] private Transform rigHip;
    [SerializeField] private TextMeshProUGUI hipUI;

    private void Start()
    {
        isHipLock = false;

        hipUI.text = "Hip: " + (isHipLock ? "Locked" : "Free");
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            isHipLock = !isHipLock;
            changeHipLock();
        }
    }

    void changeHipLock()
    {
        if(isHipLock)
        {
            print("lock hip");
            rigHip.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
            
        }
        else
        {
            print("free hip");
            //rigHip.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            //rigHip.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }

        hipUI.text = "Hip: " + (isHipLock ? "Locked" : "Free");
    }

    private void OnMouseDown()
    {
        screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);

        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));

        originalFootTransform = transform.position;
    }

    private void OnMouseDrag()
    {
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);

        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;

        //transform.position = Vector3.ClampMagnitude(new Vector3(curPosition.x, curPosition.y, curPosition.z), 4);

        //transform.position = Vector3.MoveTowards(originalFootTransform, curPosition, 4);

        //rb.velocity = (Vector3.ClampMagnitude(curPosition, 4) - rb.position) * 5;

        if (!isHipLock)
        {
            //rb.MovePosition(curPosition);
            //transform.position = Vector3.ClampMagnitude(new Vector3(curPosition.x, curPosition.y, curPosition.z), 4);

            rb.velocity = (Vector3.ClampMagnitude(curPosition, 4) - rb.position) * 5;

            rigHip.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            rigHip.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY;
        }
        else
        {
            rb.velocity = (Vector3.ClampMagnitude(curPosition, 4) - rb.position) * 5;

            rigHip.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        

    }

}
