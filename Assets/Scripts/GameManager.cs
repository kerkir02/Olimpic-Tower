using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private float time;
    public float delay = 5f;
    private bool isTimer;
    public bool isGameOver;

    private Player playerScript;

    public TMP_Text gameOverText;

    private Vector3 spawnPosition = new Vector3(0.9f, 15.7f, 0f);

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gameOverText.gameObject.SetActive(false);
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
        }
        else CountDown();
    }

    //spawn new player
    private void SpawnPlayer()
    {
        Instantiate(player, spawnPosition, player.transform.rotation);
        playerScript = GameObject.Find("Player(Clone)").GetComponent<Player>();
    }

    //spawn new player after time 
    private void CountDown()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isGameOver)
        {
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
}
