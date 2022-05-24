using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockGenerater : MonoBehaviour
{
    public GameObject block;
    protected GameController controller;
    protected bool controll = false;
    public ScrollObjectCopy scrollObjectCopy;
    float speed = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GameObject.Find("GameController").GetComponent<GameController>();
        InvokeRepeating("Spawn", 1f, speed);
    }

    void Update()
    {
        SpeedUp();
        SpeedNow();
    }

    void SpeedUp()
    {
        if (controller.score != 0)
        {
            if (controller.score % 2 == 0 && !controll)
            {
                // １回だけスピードアップする
                speed -= 1f;
                controll = true;
            }
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

    void Spawn()
    {
        Instantiate(block,transform.position,transform.rotation);
    }
}
