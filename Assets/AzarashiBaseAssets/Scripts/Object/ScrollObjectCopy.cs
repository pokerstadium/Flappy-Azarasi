using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObjectCopy : MonoBehaviour
{
    public float speed = 5.0f;
    public float speedValue = 0.1f;
    public float maxSpeed = 7.0f;
    public float minHeight = -3.5f;
    public float maxHeight = 3.3f;
    public int startPosition = 5;
    public int blockSpeed = 3;
    public float blockBetween  = 1.0f;
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
        if (gameController.score >= 1)
        {
            transform.Translate(-speed * Time.deltaTime, blockSpeed * Time.deltaTime, 0);

            if (transform.position.y > maxHeight)
            {
                Debug.Log("test");
                blockSpeed = -3;
            }

            if (transform.position.y < minHeight)
            {
                blockSpeed = 3;
            }
        }
        InleftBorderBlock();
        SpeedUp();
        MaintainingSpeed();
    }

    void InleftBorderBlock()
    {
        // スクロールが目標ポイントまで到達したか確認
        if (InLeftBorder())
        {
            BlockRamdomRange();
            BlockBetween();
        }
    }

    bool InLeftBorder()
    {
        return transform.position.x < -5;
    }

    void BlockRamdomRange()
    {
        // ランダムな高さを生成して設定
        float height = Random.Range(minHeight, maxHeight);
        transform.localPosition = new Vector3(startPosition, height, 0.0f);
    }

    void BlockBetween()
    {
        if (gameController.score % 10 == 0)
        {
            Debug.Log("ブロック間隔変更");
            blockBetween -= 0.1f;
            transform.localScale = new Vector3(1.0f, blockBetween, 1.0f);
        }
    }

    void SpeedUp()
    {
        // 一定のスコアでスピードアップ
        if (gameController.score != 0)
        {
            if (gameController.score % 5 == 0 && !controll)
            {
                // １回だけスピードアップする
                Debug.Log("スピードアップ！");
                speed += speedValue;
                controll = true;
                if(speed >= maxSpeed)
                {
                    speed = maxSpeed;
                }
            }
        }
    }

    // ある一定のスコアではない場合、falseに戻す
    void MaintainingSpeed()
    {
        if (gameController.score % 5 != 0 && controll)
        {
            controll = false;
        }
    }



}
