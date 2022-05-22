using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : Block
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    public override void Update()
    {

    }

    void VerticalMotion()
    {
        if (controller.score == 0)
        {
            position = transform.position;

            // （ポイント）マイナスをかけることで逆方向に移動する。
            transform.Translate(transform.up * Time.deltaTime * 3 * num);

            if (position.y > 5)
            {
                num = -1;
            }
            if (position.y < 1.2)
            {
                num = 1;
            }
        }
    }
}
