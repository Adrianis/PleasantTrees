using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public delegate void ActivationRoutine();

    public int PlayerNumber;
    public float pushForce;
    public float magnetForce;
    public float moveSpeedMax;
    public float oxygenBoostRate;

    private float pushForceOri;
    private bool isTouchingSurface;

    public bool activationEnabled { get; set; }
    public ActivationRoutine ActivationMethod;

    public ParticleEmitter OxygenPS;

    public Transform Visual;
    public Transform DirArrow;

    private Vector3 prevVel = Vector3.right;

    private OxygenTimer OxyTimer;

    void Start()
    {
        pushForceOri = pushForce;
        OxyTimer = GetComponent<OxygenTimer>();
    }

    void FixedUpdate()
    {
        Vector3 direction = new Vector3(-Input.GetAxis("DirectionX_" + PlayerNumber), -Input.GetAxis("DirectionY_" + PlayerNumber), 0);
        Quaternion rotation = Quaternion.LookRotation(direction, Vector3.up);
        
        DirArrow.rotation = rotation;
        if (direction == Vector3.zero)
            DirArrow.gameObject.SetActive(false);
        else if (!DirArrow.gameObject.activeInHierarchy)
            DirArrow.gameObject.SetActive(true);

        // PLAYER INPUTS //

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

        OxygenPS.emit = false; // more reliable way of turning off PS if not pushing Y

        if (Input.GetButton("Propel_" + PlayerNumber))
        {
            if (direction != Vector3.zero)
            {
                OxygenPS.emit = true;
                rigidbody.AddForce(direction * (pushForce * 1.5f), ForceMode.Force);
                // do oxygen reduction over time
                OxyTimer.TimeTillAsphyx -= oxygenBoostRate;
            }
        }

        // SPRITE ROTATION //
        if (rigidbody.velocity != Vector3.zero)
        {
            Quaternion Q = Quaternion.LookRotation(rigidbody.velocity);
            Vector3 EQ = Q.eulerAngles;
            EQ.z = 0;
            Q = Quaternion.Euler(EQ);
            Visual.rotation = Q;

            prevVel = rigidbody.velocity;
        }
        else
        {
            Visual.rotation = Quaternion.LookRotation(prevVel);
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
