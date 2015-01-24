using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public Transform Player;
    public float distance;

    void Update()
    {
        Vector3 movePos = Player.transform.position;
        movePos.z = distance;
        transform.position = movePos;
    }

}
