using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class MiniGame1_Mash : MonoBehaviour
{

    public int targetPressCount = 5;
    private int currentPressCount = 0;

    public TMP_Text counterText; // Or TMP_Text if you're using TextMeshPro
    public string menuSceneName = "MainMenu";

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            currentPressCount++;
            counterText.text = "Presses: " + currentPressCount;

            if (currentPressCount >= targetPressCount)
            {
                Win();
            }
        }
    }

    void Win()
    {
        Debug.Log("You win!");
        // Load idol menu scene
        SceneManager.LoadScene(menuSceneName);
    }
}
