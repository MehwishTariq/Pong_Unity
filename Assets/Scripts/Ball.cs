using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class Ball : MonoBehaviour
{

    private Transform ball;
    private Vector2 direction;
    public AudioClip score_clip,win_clip;
    private AudioSource ball_out;

    public TextMeshProUGUI score1, score2, winner;

    public GameObject reset;
    private Button restart;

    private int p1Score = 0, p2Score = 0;
    public int WinScore = 0;
    private float ballSpeed = 0.5f;
    string GameState = "s";
    bool ans = false;

    void Start()
    {
        ball = GetComponent<Transform>();
        restart = reset.GetComponent<Button>();
        ball_out = GetComponent<AudioSource>();
        
    }

    
    void Update()
    {
        if (Input.GetKey(KeyCode.Return) && GameState == "s")
        {
            
            direction = new Vector2(ball.position.x,ball.position.y);
            ball.Translate(direction * ballSpeed * Time.deltaTime);
            GameState = "p";
        }

        if (GameState == "p")
        {
            
            ball.Translate(direction * ballSpeed * Time.deltaTime);
            Winner();
            UpdateScore(ball.position.x);
            
            if (ans)
            {
                SetBall();
                ans = false;
            }            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.collider.tag == "Up" || collision.collider.tag == "Down")
        {            
            direction.y = -direction.y;   
            
        }

        if (collision.collider.tag == "Player1" || collision.collider.tag == "Player2")
        {
            direction.x = -direction.x;            
        }
    }

    public void UpdateScore(float ball)
    {
        if (ball > 18.0f)
        {
            
            p2Score += 1;
            ans = true;
            ball_out.PlayOneShot(score_clip);
            GameState = "s";
        }
        else if (ball < 1.8f)
        {
            p1Score += 1;
            ans = true;
            ball_out.PlayOneShot(score_clip);
            GameState = "s";
        }

        if (score1 != null || score2 != null)
        {
            score1.text = p1Score.ToString();
            score2.text = p2Score.ToString();            
        }
    }

    public void Winner()
    {
        if (p1Score == WinScore && p1Score > p2Score)
        {
            score1.enabled = false;
            score2.enabled = false;
            this.enabled = false;

            ball_out.PlayOneShot(win_clip);
            winner.text = "Congratulations! Player 1 Wins!!";

            reset.SetActive(true);
            restart.onClick.AddListener(RestartGame);
        }

        else if (p2Score == WinScore && p2Score > p1Score)
        {

            score1.enabled = false;
            score2.enabled = false;
            this.enabled = false;

            ball_out.PlayOneShot(win_clip);
            winner.text = "Congratulations! Player 2 Wins!!";

            reset.SetActive(true);
            restart.onClick.AddListener(RestartGame);
        }
        
    }

    public void SetBall()
    {
        ballSpeed = ballSpeed + 0.1f;
        ball.position = new Vector3(Random.Range(3.3f,12.0f),5.03f, 2f);
        GameState = "s";
       
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }
}
