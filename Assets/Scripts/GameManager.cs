using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    private Vector3 spawnPosition = new Vector3(0.9f, 15.7f, 0f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnPlayer", 0, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnPlayer()
    {
        Instantiate(player, spawnPosition, player.transform.rotation);
    }
}
