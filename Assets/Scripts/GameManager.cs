using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Canvas canvas;
    public Text liveText;
    public Text scoreText;

    private int lives;
    private int score;
    private int level;

    private void Awake() {
        if(instance == null)
            instance = this;
        else
            DestroyImmediate(gameObject); 
    }

    private void Start() {
        DontDestroyOnLoad(gameObject);  
        DontDestroyOnLoad(canvas.gameObject);
        NewGame();
    }

    private void NewGame()
    {
        lives = 3;
        score = 0;
        liveText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;

        LoadLevel(1);
    }

    private void LoadLevel(int index)
    {
        level = index;

        Camera camera = Camera.main;

        if(camera != null){
            camera.cullingMask = 0;
        }
        canvas.gameObject.SetActive(false);
        Invoke(nameof(LoadScene),1f);
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(level);
        liveText.text = "Lives: " + lives;
        scoreText.text = "Score: " + score;
        canvas.gameObject.SetActive(true);
    }

    public void LevelComplete()
    {
        score += 1000;

        int nextLevel = level + 1;

        if (nextLevel < SceneManager.sceneCountInBuildSettings) {
            LoadLevel(nextLevel);
        } else {
            LoadLevel(1);
        }
    }

    public void LevelFailed()
    {
        lives--;

        if (lives <= 0) {
            NewGame();
        } else {
            LoadLevel(level);
        }
    }
}
