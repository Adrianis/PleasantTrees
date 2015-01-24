using UnityEngine;
using System.Collections;

public class BlowVent : MonoBehaviour {

    public float pushForce;


    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Player")
        {
            col.rigidbody.AddForce(transform.forward * pushForce, ForceMode.Force);
        }
    }

}
