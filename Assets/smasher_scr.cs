using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;


public class smasher_scr : MonoBehaviour
{

    public Rigidbody rb;
    public float forwardforce = 500f;
    public float slippery = 50f;
   // public GameManager gmr;
    public float restartDelay = 3f;
    public bool gameEnd = false;
    public Text scoretext;
    private float sidewaysMotion = 0.0f;

   
    

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 accel = Input.acceleration;
        sidewaysMotion = accel.x;

      
            rb.AddForce(0, 0, forwardforce * Time.deltaTime);
        
       
        Debug.Log("z motion " + Input.acceleration.z);
        Debug.Log("slippery " + slippery);
        Debug.Log("forward force " + forwardforce);

        if (sidewaysMotion >=1f)
        {
            Debug.Log("in side way motion");
            rb.AddForce(1000 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (sidewaysMotion <= -1f)
        {
            rb.AddForce(-1000 * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

       

        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.AddForce(slippery * Time.deltaTime, 0,0 ,ForceMode.VelocityChange);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.AddForce(-slippery * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
        if (rb.position.y < -1f)
        {

            //FindObjectOfType<GameManager>().EndGame();
            if (gameEnd == false)
            {
                Debug.Log("in side if in end game");
                FindObjectOfType<score>().enabled = false;
                scoretext.text = "Game Over";
                gameEnd = true;                
                Invoke("ReStart", restartDelay);
            }

        }

    }

    public void ReStart()
    {

        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

}
