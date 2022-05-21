using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public GameObject root;

    // Start is called before the first frame update
    void Start()
    {
        ChangeHeight();
    }

    void ChangeHeight()
    {
        // ランダムな高さを生成して設定
        float height = Random.Range(minHeight, maxHeight);
        root.transform.localPosition = new Vector3(0.0f, height, 0.0f);
    }

    // ScrollObjectスクリプトからのメッセージを受け取って高さを変更
    void OnScrollEnd()
    {
        ChangeHeight();
    }
    // Update is called once per frame
    void Update()
    {

    }
}
