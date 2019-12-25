using UnityEngine.SceneManagement;
using UnityEngine;

public class start : MonoBehaviour
{
    public int gamelevel;

    void Start()
    {
        gamelevel = PlayerPrefs.GetInt("nextlevel", 0);
    }       
    public void StartGame()
    {
        Debug.Log("start game");
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        SceneManager.LoadScene(gamelevel + 1);
    }

}
