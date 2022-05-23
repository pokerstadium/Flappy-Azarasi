using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBlockPositionTrigger : MonoBehaviour
{
    GameController gameController;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (gameController.score % 2 == 0)
        {
            collision.gameObject.SetActive(false);
        }
    }
}
