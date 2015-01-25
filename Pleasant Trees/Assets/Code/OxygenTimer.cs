using UnityEngine;
using System.Collections;

public class OxygenTimer : MonoBehaviour {

    public float TimeTillAsphyx;

    public GUIHandler GUI;

    public int playerNum { get; set; }

    void Start()
    {
        StartCoroutine(AsphyxCounter());
        GUI.TimeOri = TimeTillAsphyx;
        StartCoroutine(UpdateGUI());
    }

    private IEnumerator AsphyxCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            
            if (TimeTillAsphyx <= 0)
            {
                Debug.LogWarning("DEATH");
            }
            else TimeTillAsphyx -= 1;
        }
    }

    private IEnumerator UpdateGUI()
    {
        while (true)
        {
            GUI.UpdatePlayerTime(playerNum, TimeTillAsphyx);
            yield return new WaitForEndOfFrame();
        }
    }
}
