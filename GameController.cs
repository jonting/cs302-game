// All lines written by Jonathan Ting.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Controls the game logic, scoring, and win conditions of the game along with the timer.
public class GameController : MonoBehaviour
{
    public Canvas uIObject;

    public float endTimer = 5;
    public float maxTime = 60;
    public float seconds = 0;
    public float minute = 0;
    public float second = 0;
    public int seekerScore = 0;
    public int hiderScore = 0;
    public bool seekerWins = false;
    public bool hiderWins = false;

    private GameObject seekerObject;
    private GameObject hiderObject;
    private Timer timer;
    private Seeker seeker;
    private Hider hider;

    private int[] levelIDs = { 3, 4, 5 };

    // Start is called before the first frame update
    void Start()
    {
        // Preserves the same instance of game controller throughout the entire run of the game.
        DontDestroyOnLoad(gameObject);

        timer = uIObject.GetComponent<Timer>();
        
        // Sets the timer to the indicated round time.
        seconds = maxTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Finds the created seeker and hider objects.
        seekerObject = GameObject.FindGameObjectWithTag("Player");
        hiderObject = GameObject.FindGameObjectWithTag("Player2");
        seeker = seekerObject.GetComponent<Seeker>();
        hider = hiderObject.GetComponent<Hider>();

        // Subtracts the time from the clock.
        if (seconds > 0)
            seconds -= Time.deltaTime;

        // Displays the round timer as [MM:SS].
        minute = Mathf.FloorToInt(seconds / 60);
        second = Mathf.FloorToInt(seconds % 60);

        // Adds to the hider's score if either the seeker dies (by the hider running into the seeker) or if time runs out.
        // Then it loads the next level and resets the time.
        if (seeker.dead || seconds <= 0)
        {
            hiderScore++;
            seconds = maxTime;
            LoadNextLevel();
        }

        // Adds to the seeker's score if either the hider dies
        // (by the seeker shooting the hider or if the hider gets too close to the seeker during the seeker's freeze time.)
        // Then it loads the next level and resets the time.
        if (hider.dead)
        {
            seekerScore++;
            seconds = maxTime;
            LoadNextLevel();
        }

        // Gives the hider the win if the hider reaches 3 points first and ends the game.
        if (hiderScore >= 3)
        {
            hiderWins = true;
            EndGame();
        }

        // Gives the seeker the win if the seeker reaches 3 points first and ends the game.
        if (seekerScore >= 3)
        {
            seekerWins = true;
            EndGame();
        }
    }

    // Ends the game.
    public void EndGame()
    {
        // Waits a certain amount of seconds.
        endTimer -= Time.deltaTime;

        // Loads the main menu.
        if (endTimer <= 0)
            StartCoroutine(LoadMainMenu());
    }

    // Loads the next level.
    private void LoadNextLevel()
    {
        // Chooses a random level out of 3 pre-made levels to load.
        int rand = Random.Range(0, 2);
        SceneManager.LoadScene(levelIDs[rand]);
    }

    // Loads the main menu asynchronously.
    IEnumerator LoadMainMenu()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scenes/Main Menu");

        // Wait until the asynchronous scene fully loads.
        while (!asyncLoad.isDone)
            yield return null;
    }
}
