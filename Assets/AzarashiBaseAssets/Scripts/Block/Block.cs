using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public float minHeight;
    public float maxHeight;
    public GameObject root;
    protected GameController controller;
    protected Vector2 position;
    public int num = 1;

    // Start is called before the first frame update
    void Start()
    {
        ChangeHeight();
        controller = GameObject.Find("GameController").gameObject.GetComponent<GameController>();
    }

    // Update is called once per frame
    public virtual void Update()
    {

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
}
