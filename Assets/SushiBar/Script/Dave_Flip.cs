using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dave_Flip
{
    GameObject dave;
    // Start is called before the first frame update


    public Dave_Flip(GameObject _dave)
    {
        dave = _dave;
    }





    public void LeftFlip()
    {
        Vector3 vector3 = new Vector3(1, 1, 1);

        dave.transform.localScale = vector3;
    }

    public void RightFlip()
    {
        Vector3 vector3 = new Vector3(-1, 1, 1);

        dave.transform.localScale = vector3;
    }

}
