using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gamecompleted : MonoBehaviour
{
  
    public void QuitGame()
    {
        PlayerPrefs.SetInt("nextlevel", 0);
        Debug.Log("quit game");
        Application.Quit();

    }

}
