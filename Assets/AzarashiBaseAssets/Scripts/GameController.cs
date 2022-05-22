using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    enum State
    {
        Ready,
        Play,
        GameOver
    }

    State state;
    public int score;
    public AzarashiController azarashi;
    public GameObject blocks;
    public Text scoreText;
    public Text stateText;

    // Start is called before the first frame update
    void Start()
    {
        Ready();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        switch (state)
        {
            case State.Ready:
                // スペースを押したらゲームスタート
                if (Input.GetKey(KeyCode.Space)) GameStart();
                break;

            case State.Play:
                //キャラクターが死亡したらゲームオーバー
                if (azarashi.IsDead()) GameOver();
                break;

            case State.GameOver:
                // エンターを押したらシーンをリロード
                if (Input.GetKey(KeyCode.Return)) Reload();
                break;
        }
    }

    void Ready()
    {
        state = State.Ready;

        // 各オブジェクトを無効状態にする
        azarashi.SetSteerActive(false);
        blocks.SetActive(false);

        // ラベルを更新
        scoreText.text = "スコア : " + 0;

        stateText.gameObject.SetActive(true);
        stateText.text = "スペースキーでスタート！";
    }

    void GameStart()
    {
        state = State.Play;

        // 各オブジェクトを有効にする
        azarashi.SetSteerActive(true);
        blocks.SetActive(true);

        // 最初の入力だけゲームコントローラーから渡す
        azarashi.Flap();

        // ラベルを更新
        stateText.gameObject.SetActive(false);
        stateText.text = "";
    }

    void GameOver()
    {
        state = State.GameOver;

        // シーン中の全てのScrollObjectコンポーネントを探し出す
        ScrollObject[] scrollObjects = FindObjectsOfType<ScrollObject>();

        // 全ScrollObjectのスクロール処理を無効にする
        foreach (ScrollObject obj in scrollObjects) obj.enabled = false;

        // ラベルを更新
        stateText.gameObject.SetActive(true);
        stateText.text = "ゲームオーバー…";
    }

    void Reload()
    {
        // 現在読み込んでいるシーンを再読み込み
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = "スコア : " + score;
    }
}
