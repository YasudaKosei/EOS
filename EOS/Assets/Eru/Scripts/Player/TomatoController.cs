using UnityEngine;

public class TomatoController : MonoBehaviour
{
    public float speed = 1;
    public float jumpPower = 1;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        //ˆÚ“®
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        var movement = new Vector3(moveHorizontal, 0, moveVertical);

        rb.AddForce(movement * speed);

        //ƒWƒƒƒ“ƒv
        if (Input.GetKeyDown(KeyCode.Space))
        {
            var pos = new Vector3(0, 1, 0);
            rb.AddForce(pos * jumpPower);
        }
    }
}
