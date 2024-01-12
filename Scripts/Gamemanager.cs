using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject[] obstacles;
    private int score = 0;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject player;

    private int currentObstacleIndex = 0;

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            float waitTime = Random.Range(0.5f, 2f);

            // Instantiate the next obstacle at the fixed position
            Instantiate(obstacles[currentObstacleIndex], spawnPoint.position, Quaternion.identity);

            // Increment the index for the next iteration
            currentObstacleIndex = (currentObstacleIndex + 1) % obstacles.Length;

            yield return new WaitForSeconds(waitTime);
        }
    }

    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameStart()
    {
        player.SetActive(true);
        playButton.SetActive(false);
        StartCoroutine("SpawnObstacle");
        InvokeRepeating("ScoreUp", 2f, 1f);
    }
}
