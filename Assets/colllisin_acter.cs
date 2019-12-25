using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class colllisin_acter : MonoBehaviour
{
    public AudioClip audioData;
    public smasher_scr smash;
    public GameObject explosionEffect;
    public Text scoretext;
    public float restartDelay = 2f;
    public GameObject completUi ;
    private AudioSource source;
    public float radius = 5.0F;
    public float power = 10.0F;
    public bool hasExploded =  false;
    



    void Awake()
    {

        source = GetComponent<AudioSource>();

    }


    void OnCollisionEnter(Collision collisioninfo)
    {
        

        if (collisioninfo.collider.tag == "obstacle" && hasExploded == false)
        {

            source.PlayOneShot(audioData, 1f);
            Instantiate(explosionEffect, transform.position, transform.rotation);
            smash.enabled = false;
           
            FindObjectOfType<score>().enabled = false;
            scoretext.text = "Game Over";
           
            FindObjectOfType<follow_smasher>().enabled = false;
            Debug.Log("before reload");
            // Invoke("Reload", 1f);
             StartCoroutine(startCollision(.8f));
            
            
        }
        else if (collisioninfo.collider.tag == "oxygen")
        {
            FindObjectOfType<score>().enabled = false;            
            smash.enabled = false;
            //ozoneUi.SetActive(true);
            completUi.SetActive(true);
            StartCoroutine(ExecuteAfterTime(2f));
            
        }

    }
    public void Reload()
    {
        Debug.Log("inside reload");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }
    public void LevelComplete()
    {
        //ozoneUi.SetActive(false);
       
        StartCoroutine(ExecuteAfterTime1(2f));

    }
    IEnumerator collided_obstacle(float time)
    {
        yield return new WaitForSeconds(0f);

        // Code to execute after the delay
        
        Invoke("Reload", 1f);
    }
    IEnumerator startCollision(float time)
    {
        yield return new WaitForSeconds(time);

        if (hasExploded == false)
        {
            hasExploded = true;
            Destroy(gameObject);
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex );

        //Invoke("Reload", 0.1f);
    }
    IEnumerator ExecuteAfterTime(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        completUi.SetActive(false);
        Invoke("NextLevel", 0f);
    }
    IEnumerator ExecuteAfterTime1(float time)
    {
        yield return new WaitForSeconds(time);

        // Code to execute after the delay
        completUi.SetActive(false);
        Invoke("NextLevel", 0f);
    }
   
    public void NextLevel()
    {

        //Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        PlayerPrefs.SetInt("nextlevel", SceneManager.GetActiveScene().buildIndex);

    }

}
