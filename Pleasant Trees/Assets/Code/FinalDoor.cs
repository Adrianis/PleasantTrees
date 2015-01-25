using UnityEngine;
using System.Collections;

public class FinalDoor : MonoBehaviour {

    public delegate void SwitchBack();

    private bool Switch1;
    private bool Switch2;

    public SwitchBack SwitchBack1;
    public SwitchBack SwitchBack2;

    public void HitSwitch(int switchNum, SwitchBack switchBack)
    {
        if (switchNum == 1)
        {
            Switch1 = true;
            SwitchBack1 = switchBack;
            StartCoroutine("TurnOff", switchNum);
        }
        else if (switchNum == 2)
        {
            Switch2 = true;
            SwitchBack2 = switchBack;
            StartCoroutine("TurnOff", switchNum);
        }
    }

    private IEnumerator TurnOff(int switchNum)
    {
        yield return new WaitForSeconds(3);
        if (switchNum == 1)
            SwitchBack1();
        else if (switchNum == 2)
            SwitchBack2();
    }

    private IEnumerator CheckSwitches()
    {
        while (true)
        {
            if (Switch1 && Switch2)
            {
                StopCoroutine("TurnOff");
                Animator anim = GetComponent<Animator>();
                anim.SetTrigger("Open");
                collider.enabled = false;
            }
            yield return new WaitForEndOfFrame();
        }
    }

}
