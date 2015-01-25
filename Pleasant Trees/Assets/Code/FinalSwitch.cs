using UnityEngine;
using System.Collections;

public class FinalSwitch : MonoBehaviour {

    public FinalDoor finalDoor;
    public int switchNum;

    public Sprite ActivatedSprite;
    public SpriteRenderer SpriteRenderer;

    private Sprite originalSprite;

    void Start()
    {
        originalSprite = SpriteRenderer.sprite;
    }

    private void OpenLinkedDoor()
    {
        finalDoor.HitSwitch(switchNum, SwitchBack);
        SpriteRenderer.sprite = ActivatedSprite;
    }

    private void SwitchBack()
    {
        SpriteRenderer.sprite = originalSprite;
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
