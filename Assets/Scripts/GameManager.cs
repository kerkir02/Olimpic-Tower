using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private float time;
    public float delay = 5f;
    private bool isTimer;
    public bool isGameOver;
    public int score;

    public TMP_Text gameOverText;
    public TMP_Text scoreText;
    public TMP_Text introText;

    private Vector3 spawnPosition = new Vector3(0.9f, 15.7f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        score = -1;
        gameOverText.gameObject.SetActive(false);
        scoreText.gameObject.SetActive(true);
        introText.gameObject.SetActive(true);
        SpawnPlayer();
        isTimer = false;
        isGameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        //check game over
        if (isGameOver)
        {
            gameOverText.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            gameOverText.text = "Game Over\nYour score: " + score + "\nPress SPACE to restart";
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(0);
            }
        }
        else CountDown();
    }

    //spawn new player
    private void SpawnPlayer()
    {
        Instantiate(player, spawnPosition, player.transform.rotation);
        WriteNewScore();
    }

    //spawn new player after time 
    private void CountDown()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameOver)
        {
            introText.gameObject.SetActive(false);
            isTimer = true;
            time = 0;
        }
        if (isTimer)
        {
            time += Time.deltaTime;
            if (time >= delay)
            {
                SpawnPlayer();
                isTimer = false;
            }
        }
    }

    //new score
    private void WriteNewScore()
    {
        score++;
        scoreText.text = "Score: " + score;
    }
}
