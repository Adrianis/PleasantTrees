using UnityEngine;
using System.Collections;

public class AppENd : MonoBehaviour {

	void OnTriggerEnter(Collider col)
    {
        Application.Quit();
    }
}
