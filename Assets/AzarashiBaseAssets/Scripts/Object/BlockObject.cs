using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockObject : ScrollObject
{
    public int verticalSpeed = 1;
    public override void Update()
    {
        // 毎フレームxポジションを少しずつ移動させる
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        // スクロールが目標ポイントまで到達したか確認
        if (transform.position.x <= endPosition) ScrollEnd();

        SpeedUp();
        SpeedNow();
        VerticalMotionBlock();
    }

    void VerticalMotionBlock()
    {
        if (controller.score >= 1)
        {
            transform.Translate(transform.up * Time.deltaTime * verticalSpeed);

            if(transform.position.y > 1.5f)
            {
                verticalSpeed = -1;
            }

            if(transform.position.y < -4)
            {
                verticalSpeed = 1;
            }
        }
    }
}
