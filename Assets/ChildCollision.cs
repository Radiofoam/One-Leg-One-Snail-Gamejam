using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildCollision : MonoBehaviour
{
    [SerializeField] private GameObject parentRig;
    [SerializeField] private bool isSnailProof;
    void OnCollisionEnter(Collision collision)
    {
        parentRig.GetComponent<PlayerManager>().OnCollide(collision.collider, isSnailProof);
    }

    private void OnTriggerEnter(Collider other)
    {
        parentRig.GetComponent<PlayerManager>().OnCollide(other, isSnailProof);
    }

}
