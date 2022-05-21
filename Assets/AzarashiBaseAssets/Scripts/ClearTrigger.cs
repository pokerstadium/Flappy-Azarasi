using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearTrigger : MonoBehaviour
{
    GameObject gameController;
    // Start is called before the first frame update
    void Start()
    {
        // ゲーム開始時にGameControllerをFindしておく
        gameController = GameObject.FindWithTag("GameController");
    }

    // トリガーからExitしたらクリアとみなす
    private void OnTriggerEnter2D(Collider2D collision)
    {
        gameController.SendMessage("IncreaseScore");
    }
}
