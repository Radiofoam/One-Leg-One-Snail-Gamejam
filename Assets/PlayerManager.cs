using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    [SerializeField] private int saltCount;
    [SerializeField] private TextMeshProUGUI saltUI;
    void OnCollisionEnter(Collision collision)
    {
        OnCollide(collision.collider, false);
    }

    public void OnCollide(Collider collision, bool isSnailProof)
    {
        if (collision.CompareTag("Salt"))
        {
            print("hit salt");
            collision.gameObject.SetActive(false);
            saltCount++;
        }
        else
        {
            if (collision.CompareTag("Snail") && !isSnailProof)
            {
                print("die");
                
            }
        }
    }

    private void Update()
    {
        saltUI.text = saltCount.ToString() + " Salt Jar(s)";
    }

}
