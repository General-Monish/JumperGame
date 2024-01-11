using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Gamemanager : MonoBehaviour
{
    [SerializeField] private GameObject obstacle;
     private int score=0;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private GameObject playButton;
    [SerializeField] private GameObject Player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator SpawnObstacle()
    {
        while (true)
        {
            float waitTime = Random.Range(0.5f, 2f);
            yield return new WaitForSeconds(waitTime);
            Instantiate(obstacle, spawnPoint.position, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ScoreUp()
    {
        score++;
        scoreText.text = score.ToString();
    }

    public void GameStart()
    {
        Player.SetActive(true);
        playButton.SetActive(false);
        StartCoroutine("SpawnObstacle");
        InvokeRepeating("ScoreUp", 2f, 1f);
    }
}
