using UnityEngine;
using System.Collections;

public class Switch : MonoBehaviour {

    public Door LinkedDoor;

    private void OpenLinkedDoor()
    {
        LinkedDoor.Open();
    }
    
    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Player")
        {
            PlayerMovement player = col.GetComponent<PlayerMovement>();
            player.activationEnabled = true; // enable player input for 
            player.ActivationMethod = OpenLinkedDoor; // register method with delegate
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Player")
        {
            PlayerMovement player = col.GetComponent<PlayerMovement>();
            player.activationEnabled = false;
            player.ActivationMethod = null; // unregister method
        }
    }

}
