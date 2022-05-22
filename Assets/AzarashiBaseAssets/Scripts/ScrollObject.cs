using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollObject : MonoBehaviour
{
    public float speed = 1.0f;
    public float startPosition;
    public float endPosition;
    GameController controller;
    bool controll = false;

    private void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
    }

    void Update()
    {
        // 毎フレームxポジションを少しずつ移動させる
        transform.Translate(-1 * speed * Time.deltaTime, 0, 0);

        // スクロールが目標ポイントまで到達したか確認
        if (transform.position.x <= endPosition) ScrollEnd();

        SpeedUp();
        SpeedNow();
    }


    void ScrollEnd()
    {
        // 通り過ぎた分を加味してポジションを再設定
        float diff = transform.position.x - endPosition;
        Vector3 restartPosition = transform.position;
        restartPosition.x = startPosition + diff;
        transform.position = restartPosition;

        // 同じゲームオブジェクトにアタッチされているコンポーネントにメッセージを送る
        SendMessage("OnScrollEnd", SendMessageOptions.DontRequireReceiver);
    }

    // 一定のスコアでスピードアップ
    void SpeedUp()
    {
        if (controller.score % 10 == 0 && !controll)
        {
            // １回だけスピードアップする
            speed += 0.5f;
            controll = true;
        }
    }

    // ある一定のスコアではない場合、falseに戻す
    void SpeedNow()
    {
        if (controller.score % 10 != 0 && controll)
        {
            controll = false;
        }
    }
}
