using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public delegate void ActivationRoutine();

    public int PlayerNumber;
    public float pushForce;
    public float magnetForce;
    public float moveSpeedMax;

    private float pushForceOri;
    private bool isTouchingSurface;

    public bool activationEnabled { get; set; }
    public ActivationRoutine ActivationMethod;


    void Start()
    {
        pushForceOri = pushForce;
    }

    void Update()
    {
        Vector3 direction = new Vector3(-Input.GetAxis("DirectionX_" + PlayerNumber), -Input.GetAxis("DirectionY_" + PlayerNumber), 0);
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = rotation;

        if (Input.GetButton("Push_" + PlayerNumber))
        { 
            // charge push force even when player isnt on wall
            if (pushForce < (pushForceOri * 4))
            {
                pushForce += (pushForceOri / 18);
            }
        }
        else if (Input.GetButtonUp("Push_" + PlayerNumber))
        {
            if (isTouchingSurface)
            {
                if (direction != Vector3.zero)
                {
                    // allow pushing off only when touching surface && direction is valid
                    rigidbody.AddForce(direction * pushForce, ForceMode.Impulse);
                }
            }
            // reset pushForce whenever the button is released
            pushForce = pushForceOri;
        }


        if (Input.GetButton("Hold_" + PlayerNumber)) 
        { 
            if (isTouchingSurface)
            {
                // kill speed while hold is held down
                rigidbody.velocity = Vector3.zero;
            }
        }
        if (Input.GetButtonDown("Activate_" + PlayerNumber)) 
        { 
            if (activationEnabled)
            {
                if (ActivationMethod != null)
                {
                    ActivationMethod();
                }
            }
        }
    }


    void OnTriggerEnter(Collider col)
    {
        isTouchingSurface = true;
    }

    void OnTriggerStay(Collider col)
    {
        isTouchingSurface = true;
    }

    void OnTriggerExit(Collider col)
    {
        isTouchingSurface = false;
    }

}
