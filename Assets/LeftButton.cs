using UnityEngine;

public class LeftButton : MonoBehaviour
{
    public Rigidbody rb;
    public float slippery = 130f;

    public void MoveLeft()
    {
        rb.AddForce(-slippery * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
