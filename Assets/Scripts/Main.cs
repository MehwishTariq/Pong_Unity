using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Main : MonoBehaviour
{
    public GameObject Paddle1, Paddle2, Ball, Walls, Startbtn, Quitbtn,Resetbtn,Texts;
    private Button strt, quit;

    private void Awake()
    {
        Paddle1.SetActive(false);
        Paddle2.SetActive(false);
        Ball.SetActive(false);
        Walls.SetActive(false);
        Texts.SetActive(false);
        Resetbtn.SetActive(false);
    }

    void Start()
    {
        
        strt = Startbtn.GetComponent<Button>();
        quit = Quitbtn.GetComponent<Button>();
        
        strt.onClick.AddListener(StartGame);
        quit.onClick.AddListener(QuitApp);
        
    }

    private void QuitApp()
    {
       Application.Quit();
    }

    private void StartGame()
    {
        
        Paddle1.SetActive(true);
        Paddle2.SetActive(true);
        Ball.SetActive(true);
        Walls.SetActive(true);
        Texts.SetActive(true);
        Startbtn.SetActive(false);
        Quitbtn.SetActive(false);
       
    }
}
