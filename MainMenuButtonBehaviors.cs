// All lines initially written by Zachary Ables. Lines 20-21, 27-28, 40-44, and 53-61 modified by Jonathan Ting
// for loading main game. Lines 30-31, 46-50, and 63-72 modified by Philip Hicks for loading network test.
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

// Controls the main menu.
public class MainMenuButtonBehaviors : MonoBehaviour
{
    public GameObject NetworkManager;
    public Button exitTutorial;
    public Button startButton;
    public Button testButton;

    // Use this for initialization
    private void Start()
    {
        // Destroys any old Game Controllers so a new one can be made on game start.
        Destroy(GameObject.Find("GameController"));

        // Creates three buttons for the main menu.
        Button btn1 = exitTutorial.GetComponent<Button>();
        btn1.onClick.AddListener(OnExitClick);

        Button btn2 = startButton.GetComponent<Button>();
        btn2.onClick.AddListener(OnStartClick);

        Button btn3 = testButton.GetComponent<Button>();
        btn3.onClick.AddListener(onTestClick);
    }

    // Quits the game.
    private void OnExitClick()
    {
        Application.Quit();
    }

    // Loads first level upon clicking Start Game button.
    private void OnStartClick()
    {
        StartCoroutine(LoadGame());
    }

    // Loads network test upon clicking Network Test button.
    private void onTestClick()
    {
        StartCoroutine(LoadNetworkTest());
    }

    // Loads the main game.
    IEnumerator LoadGame()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scenes/Test Room");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
            yield return null;
    }

    //Loads the Network Test.
    IEnumerator LoadNetworkTest()
    {
        // The Application loads the Scene in the background as the current Scene runs.
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("Scenes/NetworkTest");

        // Wait until the asynchronous scene fully loads
        while (!asyncLoad.isDone)
            yield return null;
    }
}
