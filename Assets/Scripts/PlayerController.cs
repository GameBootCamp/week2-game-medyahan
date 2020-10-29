using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    private float speed = 4;
    [SerializeField] private Player player;

    [SerializeField] private Text scoreText;
    [SerializeField] private Text bestText;

    private Rigidbody rb;
    float horizontal = 0;
    float vertical = 0;
    Vector3 vec;

    float minX = -2.5f;
    float maxX = 2.5f;
    float minY = -3.4f;
    float maxY = 5.3f;


    private CallBack dieCallBack;

    private void OnEnable()
    {
        Reset();
        rb = GetComponent<Rigidbody>();

        player = new Player();

        scoreText.text = "score: 0";

        bestText.text = "best: " + PlayerPrefs.GetInt("bestScore").ToString();
    }

    private void OnDisable()
    {
        dieCallBack = null;
    }

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        vec = new Vector3(horizontal, vertical, 0);
        rb.velocity = vec * speed;

        rb.position = new Vector3(Mathf.Clamp(rb.position.x, minX, maxX), Mathf.Clamp(rb.position.y, minY, maxY), 0.0f); // Oyun çerçevesinden çıkmasını engelleme
    }


    public void ChangeScore(int score)
    {
        player.ScoreKeeper(score);
        ApplyScore();
    }

    private void ApplyScore()
    {
        scoreText.text = "score: " + player.GetScore().ToString();
    }

    public void GameOver()
    {
        dieCallBack();
        var gameManager = GameManager.Instance;
        gameManager.SetBestScore(player.GetScore());
        gameManager.SetState(StateType.StartState);
    }

    public void SetCallBack(CallBack callBack)
    {
        dieCallBack = callBack;
    }
    public void Reset()
    {
        gameObject.transform.position = new Vector3(0.0f, -2.63f, 0.0f);
    }
}
