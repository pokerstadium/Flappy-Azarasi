using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjectCopy : MonoBehaviour
{
    public float speed = 1.0f;


    private void Start()
    {

    }

    void Update()
    {
        // 毎フレームxポジションを少しずつ移動させる
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        // スクロールが目標ポイントまで到達したか確認
        if (transform.position.x < -5)
        {
            Destroy(gameObject);
        }
    }

    // 一定のスコアでスピードアップ

}
