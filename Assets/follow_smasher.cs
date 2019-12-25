using UnityEngine;

public class follow_smasher : MonoBehaviour
{
    public Transform smasher;
    public Vector3 camposition;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(smasher.position);
        transform.position = smasher.position +camposition;
    }
}
