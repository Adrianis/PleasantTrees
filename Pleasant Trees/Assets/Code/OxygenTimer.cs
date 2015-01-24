using UnityEngine;
using System.Collections;

public class OxygenTimer : MonoBehaviour {

    public int TimeTillAsphyx;




    private IEnumerator AsphyxCounter()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            
            TimeTillAsphyx -= 1;
            if (TimeTillAsphyx < 0)
            {
                // KILL
            }
        }
    }

}
