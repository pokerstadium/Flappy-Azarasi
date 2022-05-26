using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjectCopy : MonoBehaviour
{
    public float speed;
    public float minHeight;
    public float maxHeight;
    public float startPosition;
    protected bool controll = false;
    GameControllerCopy gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameControllerCopy>();
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
            if (gameController.score % 3 == 0)
            {
                transform.localScale = new Vector3(1.0f, 0.5f, 1.0f);
                Debug.Log("ブロック間隔狭める");
            }
        }

        SpeedUp();
        SpeedNow();
    }

    void SpeedUp()
    {
        // 一定のスコアでスピードアップ
        if (gameController.score != 0)
        {
            if (gameController.score % 2 == 0 && !controll)
            {
                // １回だけスピードアップする
                Debug.Log("スピードアップ！");
                speed += 1f;
                controll = true;
            }
        }
    }

    // ある一定のスコアではない場合、falseに戻す
    void SpeedNow()
    {
        if (gameController.score % 2 != 0 && controll)
        {
            controll = false;
        }
    }
}
