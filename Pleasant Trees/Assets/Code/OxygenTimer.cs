using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class OxygenTimer : MonoBehaviour {

    public float TimeTillAsphyx;

    public GUIHandler GUI;

    public int playerNum { get; set; }

    private PlayerMovement PC;

    public List<SpriteRenderer> Visuals;
    public GameObject CamTint;
    public GameObject DirArrow;

    void Start()
    {
        StartCoroutine(AsphyxCounter());
        GUI.TimeOri = TimeTillAsphyx;
        StartCoroutine(UpdateGUI());
        PC = GetComponent<PlayerMovement>();
    }

    private IEnumerator AsphyxCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            
            if (TimeTillAsphyx <= 0)
            {
                GUI.KillPlayer(playerNum);
                PC.enabled = false;
                CamTint.SetActive(true);
                DirArrow.SetActive(true);
                foreach (SpriteRenderer sprite in Visuals)
                    sprite.sortingOrder = 0;
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
