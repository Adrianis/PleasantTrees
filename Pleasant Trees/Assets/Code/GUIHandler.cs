using UnityEngine;
using System.Collections;

public class GUIHandler : MonoBehaviour {

    private Texture2D guiMeasureTex;
    private GUIStyle guiMeasureStyle;
    private Texture2D guiBackgroundTex;
    private GUIStyle guiBackgroundStyle;

    public float TimeOri;
    public float Player1Time;
    public float Player2Time;

    public bool Player1Dead;
    public bool Player2Dead;

    void Start()
    {
        InitialiseGUIElements();
    }

    public void UpdatePlayerTime(int playerNum, float time)
    {
        if (playerNum == 1)
        {
            Player1Time = time;
        }
        else if (playerNum == 2)
        {
            Player2Time = time;
        }
    }
    public void KillPlayer(int playerNum)
    {
        if (playerNum == 1)
            Player1Dead = true;
        else if (playerNum == 2)
            Player2Dead = true;
    }

    void OnGUI()
    {
        // Player 1
        if (!Player1Dead)
        {
            GUI.Label(new Rect(10, 30, 40, 20), "O2:");
            GUI.Label(new Rect(50, 30, TimeOri * 7, 20), "", guiBackgroundStyle);
            GUI.Label(new Rect(50, 30, Player1Time * 7, 20), "", guiMeasureStyle);
        }
        
        // Player 2
        if (!Player2Dead)
        {
            GUI.Label(new Rect(780, 30, 40, 20), "O2:");
            GUI.Label(new Rect(820, 30, TimeOri * 7, 20), "", guiBackgroundStyle);
            GUI.Label(new Rect(820, 30, Player2Time * 7, 20), "", guiMeasureStyle);
        }
    }

    private void InitialiseGUIElements()
    {
        guiMeasureTex = new Texture2D(1, 1);
        guiMeasureTex.SetPixel(1, 1, Color.white);
        guiMeasureTex.wrapMode = TextureWrapMode.Repeat;
        guiMeasureTex.Apply();
        guiMeasureStyle = new GUIStyle();
        guiMeasureStyle.normal.background = guiMeasureTex;


        guiBackgroundTex = new Texture2D(1, 1);
        guiBackgroundTex.SetPixel(1, 1, Color.gray);
        guiBackgroundTex.wrapMode = TextureWrapMode.Repeat;
        guiBackgroundTex.Apply();
        guiBackgroundStyle = new GUIStyle();
        guiBackgroundStyle.normal.background = guiBackgroundTex;
    }

}
