using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {

    public void Open()
    {
        Animator anim = GetComponent<Animator>();
        anim.SetTrigger("Open");
        collider.enabled = false;
    }

}
