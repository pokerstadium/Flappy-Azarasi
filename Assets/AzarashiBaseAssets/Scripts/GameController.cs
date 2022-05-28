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
    int point = 0;
    public int score;
    public AzarashiController azarashi;
    public GameObject block;
    public Text scoreText;
    public Text stateText;
    public bool isGameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        Ready();
        isGameOver = true;
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
                //ランキングを出す
                if (isGameOver) Ranking();

                // エンターを押したらシーンをリロード
                if (Input.GetKey(KeyCode.Return) && isGameOver) Reload();

                break;
        }
    }

    void Ready()
    {
        state = State.Ready;

        // 各オブジェクトを無効状態にする
        azarashi.SetSteerActive(false);

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

        Invoke("BlockGenerater", 1f);

        // 最初の入力だけゲームコントローラーから渡す
        azarashi.Flap();

        BlockGenerater();

        // ラベルを更新
        stateText.gameObject.SetActive(false);
        stateText.text = "";
    }

    void BlockGenerater()
    {
        // １回だけブロックを作る
        while (point < 1)
        {
            Instantiate(block, transform.position, transform.rotation);
            point++;
        }
    }

    void GameOver()
    {
        state = State.GameOver;

        // シーン中の全てのScrollObjectコンポーネントを探し出す
        ScrollObject[] scrollObjects = FindObjectsOfType<ScrollObject>();
        ScrollBlock scrollBlock = FindObjectOfType<ScrollBlock>();

        // 全ScrollObjectのスクロール処理を無効にする
        foreach (ScrollObject obj in scrollObjects) obj.enabled = false;
        scrollBlock.enabled = false;

        // ラベルを更新
        stateText.gameObject.SetActive(true);
        stateText.text = "Enterキーで再開！";
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

    void Ranking()
    {
        naichilab.RankingLoader.Instance.SendScoreAndShowRanking(score);
        isGameOver = false;
    }
}
