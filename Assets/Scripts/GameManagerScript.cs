using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class GameManagerScript : MonoBehaviour
{
    public static GameManagerScript instance;
    public GameObject goPlayer1;
    public GameObject goPlayer2;
    public GameObject goBackground;
    public Text txtP1Score;
    public Text txtP2Score;
    public GameObject goCurrentObject;
    public Image imgP1Item;
    public Image imgP2Item;
    public Image imgScreen;
    public Sprite[] spritesScreen;

    public float fSpeed = 25;
    public bool isP1TouchObject = false;
    public bool isP2TouchObject = false;
    public int iP1Score;
    public int iP2Score;

    public int iP1HitNum;
    public int iP2HitNum;

    public EClick eClick = EClick.Max;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer(goPlayer1, 1);
        MovePlayer(goPlayer2, 2);
        ChangeScreen();
    }

    /// <summary>
    /// 玩家移動及範圍限制
    /// </summary>
    /// <param name="goPlayer"></param>
    /// <param name="iPlayerNum"></param>
    private void MovePlayer(GameObject goPlayer, int iPlayerNum)
    {
        switch (iPlayerNum)
        {
            case 1:
                if (Input.GetKey(KeyCode.A))
                {
                    goPlayer.transform.Translate(Vector2.left * fSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.D))
                {
                    goPlayer.transform.Translate(Vector2.right * fSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.W))
                {
                    goPlayer.transform.Translate(Vector2.up * fSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.S))
                {
                    goPlayer.transform.Translate(Vector2.down * fSpeed * Time.deltaTime);
                }
                if (Input.GetKeyDown(KeyCode.E) && isP1TouchObject.Equals(true))
                {
                    Debug.Log($"{goPlayer.name}進行一次破壞行動");
                    goBackground.transform.DOShakePosition(0.1f, 10);
                    eClick = EClick.P1Click;
                    iP1HitNum--;
                    if (iP1HitNum.Equals(0))
                    {
                        Debug.Log($"iP1HitNum = {iP1HitNum}");
                    }
                }
                break;
            case 2:
                if (Input.GetKey(KeyCode.LeftArrow))
                {
                    goPlayer.transform.Translate(Vector2.left * fSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.RightArrow))
                {
                    goPlayer.transform.Translate(Vector2.right * fSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.UpArrow))
                {
                    goPlayer.transform.Translate(Vector2.up * fSpeed * Time.deltaTime);
                }
                if (Input.GetKey(KeyCode.DownArrow))
                {
                    goPlayer.transform.Translate(Vector2.down * fSpeed * Time.deltaTime);
                }
                if (Input.GetKeyDown(KeyCode.Slash) && isP2TouchObject.Equals(true))
                {
                    Debug.Log($"{goPlayer.name}進行一次破壞行動");
                    goBackground.transform.DOShakePosition(0.1f, 10);
                    eClick = EClick.P2Click;
                    iP2HitNum--;
                    if (iP2HitNum.Equals(0))
                    {
                        Debug.Log($"iP2HitNum = {iP2HitNum}");
                    }
                }
                break;
            default:
                break;
        }
        if (goPlayer.transform.localPosition.x < -380)
        {
            goPlayer.transform.localPosition = new Vector2(-380, goPlayer.transform.localPosition.y);
        }
        if (goPlayer.transform.localPosition.x > 380)
        {
            goPlayer.transform.localPosition = new Vector2(380, goPlayer.transform.localPosition.y);
        }
        if (goPlayer.transform.localPosition.y < -320)
        {
            goPlayer.transform.localPosition = new Vector2(goPlayer.transform.localPosition.x, -320);
        }
        if (goPlayer.transform.localPosition.y > 320)
        {
            goPlayer.transform.localPosition = new Vector2(goPlayer.transform.localPosition.x, 320);
        }
    }

    private void ChangeScreen()
    {
        txtP1Score.text = iP1Score.ToString();
        txtP2Score.text = iP2Score.ToString();
        if ((iP1Score + iP2Score)>30)
        {
            imgScreen.sprite = spritesScreen[0];
        }
        if ((iP1Score + iP2Score) > 60)
        {
            imgScreen.sprite = spritesScreen[1];
        }
    }
}
public enum EPlayer
{
    player1,
    player2
}
public enum EClick
{
    P1Click,
    P2Click,
    Max
}