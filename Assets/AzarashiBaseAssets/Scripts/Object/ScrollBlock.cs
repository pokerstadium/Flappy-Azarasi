using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBlock : MonoBehaviour
{
    public float speed = 4.0f;
    public float speedValue = 0.1f;
    float maxSpeed = 7.0f;
    float minHeight = -3.5f;
    float maxHeight = 3.3f;
    int startPosition = 5;
    public float blockSpeed = 1.0f;
    float blockBetween  = 1.0f;
    float minblockBetween  = 0.7f;
    bool controll = false;
    bool verticalControll = false;
    float verticalSpeed = 0.5f;
    GameControllerCopy gameController;

    private void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameControllerCopy>();
    }

    void Update()
    {
        // 毎フレームxポジションを少しずつ移動させる
        transform.Translate(-speed * Time.deltaTime, 0, 0);

        InleftBorderBlock();
        SpeedUp();
        BlockMotion();
        MaintainingSpeed();
        MaintainingVerticalSpeed();
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
        // 一定のスコアでブロックの間隔を狭くする
        if (gameController.score % 10 == 0)
        {
            Debug.Log("ブロック間隔変更");
            blockBetween -= 0.05f;
            transform.localScale = new Vector3(1.0f, blockBetween, 1.0f);

            // これ以上ブロックの間隔を狭くしない
            if (blockBetween <= minblockBetween)
            {
                // 0.05fを入れているのは上のblockBetween -=0.05fを相殺するために使用している
                blockBetween = minblockBetween + 0.05f;
            }
        }
    }

    void SpeedUp()
    {
        // スコアが０の時は加速しない
        if (gameController.score != 0)
        {
            // 一定のスコアでスピードアップ
            if (gameController.score % 5 == 0 && !controll)
            {
                // １回だけスピードアップする
                Debug.Log("スピードアップ！");
                speed += speedValue;
                controll = true;

                // これ以上スピードアップはしない
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

    void BlockMotion()
    {
        // スコアが３０以上になったら
        if (gameController.score >= 30)
        {
            // 関数呼び出し
            Invoke("Vertical", 0.5f);
        }
    }

    // ブロックの上下運動
    void Vertical()
    {
        VerticalMotion();
        VerticalSpeed();
    }

    void VerticalMotion()
    {
        // ブロックのリスタート時、最初だけ上or下の動きをランダムで決める
        int random = Random.Range(0, 1);
        if (random == 0 && transform.position.x < -5)
        {
            blockSpeed = -verticalSpeed;
        }

        transform.Translate(-speed * Time.deltaTime, blockSpeed * Time.deltaTime, 0);

        // 下に移動
        if (transform.position.y > maxHeight)
        {
            blockSpeed = -verticalSpeed;
        }

        // 上に移動
        if (transform.position.y < minHeight)
        {
            blockSpeed = verticalSpeed;
        }
    }

    void VerticalSpeed()
    {
        // 一定のスコアで上下運動のスピードアップ
        if (gameController.score % 10 == 0 && !verticalControll)
        {
            Debug.Log("１回のみ");
            verticalSpeed += 0.25f;
            verticalControll = true;

            // これ以上上下運動のスピードを上げない
            if (verticalSpeed >= 3)
            {
                // 2.75fなのは処理後、verticalSpeed += 0.25fで合計３になるため調整している。
                verticalSpeed = 2.75f;
            }
        }
    }


    void MaintainingVerticalSpeed()
    {
        if (gameController.score % 10 != 0 && verticalControll)
        {
            verticalControll = false;
        }
    }
}
