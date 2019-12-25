using UnityEngine;
using UnityEngine.UI;

public class score : MonoBehaviour
{
   public Transform smasher;
    public Text scoretext;

    // Update is called once per frame
    void Update()
    {

        scoretext.text = smasher.position.z.ToString("0");
        
    }
    //public void gameOverMessage() => scoretext.text = "Game Over";
}
