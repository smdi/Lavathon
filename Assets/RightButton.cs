using UnityEngine;

public class RightButton : MonoBehaviour
{
    public Rigidbody rb;
    public float slippery = 130f;

    public void MoveRight()
    {
        rb.AddForce(slippery * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
    }
}
