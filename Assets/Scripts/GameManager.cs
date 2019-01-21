using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public delegate void GameInitiation();
    public static event GameInitiation InitiateGame;
    int currentTimer;
    public GameObject timeValue;
    TMP_Text timeValueText;
    public GameObject gameOver;
    public bool gameStarted = false;
    static GameManager _instance; //Singleton Instance
    void Awake()
    {
        if(_instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            _instance = this;
        }
    }

    // Use this for initialization
    void Start () {

        //Initialize Components
        timeValueText = timeValue.GetComponent<TMP_Text>();

    }

    // Update is called once per frame
    void Update()
    {

        //Check to see if all the cubes are destroyed
        if (gameStarted == true)
        {
            if (GameObject.FindWithTag("Enemy") == null)
            {
                GameOver();
            }
        }
    }

   
    private IEnumerator Counter()
    {
        currentTimer = 60;
        while (currentTimer > 0)
        {
            //yield after 1 second and start counting down
            yield return new WaitForSeconds(1);
            currentTimer--;

            //update times on UI
            timeValueText.SetText(currentTimer.ToString());

            //check to see if timer is over
            if (currentTimer < 1)
            {
                GameOver();
            }
        }

    }
    public void GameOver()
    {
        /* -Set gameOver bool to true
        -Stop the coroutine of timer
        -Stop the ball from movement
        -get the final updated score */
        gameOver.SetActive(true);
        gameStarted = false;
        StopCoroutine("Counter");
        gameObject.GetComponent<ScoreManager>().timeBonus = currentTimer;
        GameObject.Find("Ball").GetComponent<Rigidbody>().isKinematic = true;
        gameObject.GetComponent<ScoreManager>().FinalScore();
    }
    public void RestartGame()
    {
        //get the current scene, reload it.
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);
    }
    public void StartGame(){

        /* -Start the coroutine
        -set gameStarted bool to true
        -Remove the start game panel of UI
        -Instantiate Cubes
        -Enable ball movement */
        gameStarted = true;
        StartCoroutine("Counter");
        if(InitiateGame != null)
        {
            InitiateGame();
        }
    }
}
