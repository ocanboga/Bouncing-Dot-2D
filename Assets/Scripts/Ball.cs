using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Ball : MonoBehaviour
{
    private Rigidbody2D topRb;
    private SpriteRenderer topRenderer;
    public float jumpingPower;
    public Color color1, color2, color3, color4, color5, color6;
    public Text scoreText,highScoreText;
    private int score,highScore; 
    // Start is called before the first frame update
    void Start()
    {
        topRb = GetComponent<Rigidbody2D>();
        topRenderer = GetComponent<SpriteRenderer>();
        if (PlayerPrefs.HasKey("highScore"))
        {
            highScore = PlayerPrefs.GetInt("highScore");
            highScoreText.text = "Rekor: " + highScore.ToString();
        }
        else
        {
            highScore = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D touch)
    {

        if (touch.gameObject.tag == "Zemin")
        {
            topRb.AddForce(Vector2.up * jumpingPower/2, ForceMode2D.Impulse);
        }
        if (touch.gameObject.tag == "Kenar")
        {
            Debug.Log(topRenderer.color);
            Debug.Log(touch.gameObject.GetComponent<SpriteRenderer>().color + topRenderer.color);
            topRb.AddForce(Vector2.up * jumpingPower,ForceMode2D.Impulse);
            
            if (topRenderer.color == touch.gameObject.GetComponent<SpriteRenderer>().color)
            {
                score+= Random.RandomRange(5, 15);
                scoreText.text = "Score: " + score.ToString();

                if (score > highScore)
                {
                    highScore = score;
                    highScoreText.text = "Rekor: " + highScore.ToString();
                    PlayerPrefs.SetInt("highScore", highScore);
                }
            }
            else if (topRenderer.color != touch.gameObject.GetComponent<SpriteRenderer>().color)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D temast)
    {
        if(temast.gameObject.tag == "ColorChanger")
        {
            ColorChanger();
        }
    }

    private void ColorChanger()
    {
        int random = Random.RandomRange(1, 7);
        switch (random)
        {
            case 1:
                topRenderer.color = color1;
                break;
            case 2:
                topRenderer.color = color2;
                break;
            case 3:
                topRenderer.color = color3;
                break;
            case 4:
                topRenderer.color = color4;
                break;
            case 5:
                topRenderer.color = color5;
                break;
            case 6:
                topRenderer.color = color6;
                break;
        }
    }
}
