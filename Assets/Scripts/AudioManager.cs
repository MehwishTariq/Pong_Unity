using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public GameObject Paddle, Walls;
    private AudioSource paddle_hit, wall_hit;
    private AudioClip p_clip, w_clip;

    void Start()
    {
        paddle_hit = Paddle.GetComponent<AudioSource>();
        p_clip = paddle_hit.clip;

        wall_hit = Walls.GetComponent<AudioSource>();
        w_clip = wall_hit.clip;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == "Up" || collision.collider.tag == "Down")
        {
            wall_hit.PlayOneShot(w_clip);
        }

        else if (collision.collider.tag == "Player1" || collision.collider.tag == "Player2")
        {
            paddle_hit.PlayOneShot(p_clip);
        }
    }
}
