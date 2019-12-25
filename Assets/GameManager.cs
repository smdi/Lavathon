using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   

    public bool gameEnd = false;
    public float restartDelay = 3f;
    public Text scoretext;

   
    public void EndGame()
    {

        Debug.Log("entered into end game");

        if (gameEnd == false)
        {
            Debug.Log("in side if in end game");
            FindObjectOfType<score>().enabled = false;
            scoretext.text = "Game Over";
            gameEnd = true;
            Debug.Log("in game manager Game Over");
            Invoke("ReStart", restartDelay);
        }


    }
    
    public void ReStart()
    {
       
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }
   

}


