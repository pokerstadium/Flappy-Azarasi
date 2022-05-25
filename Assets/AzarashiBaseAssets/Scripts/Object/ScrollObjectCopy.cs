using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjectCopy : MonoBehaviour
{
    public float speed;
    public float minHeight;
    public float maxHeight;
    public float startPosition;

    private void Start()
    {

    }

    void Update()
    {
        // 毎フレームxポジションを少しずつ移動させる
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        // スクロールが目標ポイントまで到達したか確認
        if (transform.position.x < -5)
        {
            // ランダムな高さを生成して設定
            float height = Random.Range(minHeight, maxHeight);
            transform.localPosition = new Vector3(startPosition, height, 0.0f);
        }
    }

    // 一定のスコアでスピードアップ

}
