using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    public List<GameObject> targets;
    private float spawnRate = 1.0f;
    public TextMeshProUGUI scoreText;
    public int score;
    public bool isGameActive;
    public Button restartButton;
    public TextMeshProUGUI gameOverText;
    public GameObject titleScreen;
    // Start is called before the first frame update
    void Start()
    { 
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void GameOver()
    {
        restartButton.gameObject.SetActive(true);
        gameOverText.gameObject.SetActive(true);
        isGameActive = false;    
    }
    public void StartGame(int difficalParam)
    {
        spawnRate = spawnRate / difficalParam;
        isGameActive = true;
        score = 0;

        StartCoroutine(SpawnTarget());
        UpdateScore(score);
        titleScreen.gameObject.SetActive(false);
        

    }
    IEnumerator SpawnTarget()
    {
        while(isGameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            int index = Random.Range(0, targets.Count);
            Instantiate(targets[index]);
           // UpdateScore(5);
        }
    }
  public  void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }
    public void RestartGameManager()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
