using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObject : ScrollObject
{
    public override void SpeedUp()
    {
        if (controller.score != 0)
        {
            if (controller.score % 2 == 0 && !controll)
            {
                // １回だけスピードアップする
                speed += 0.5f;
                controll = true;
                //transform.localScale += new Vector3(0, -0.1f, 0);
            }
        }
    }
}
