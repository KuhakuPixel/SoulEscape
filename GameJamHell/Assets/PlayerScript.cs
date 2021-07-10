using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float playerSpeed = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
        Vector2 inputVector = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        if (inputVector.magnitude > 1)
        {
            inputVector.Normalize();
        }
        transform.Translate(new Vector3(inputVector.x, inputVector.y, 0f) * playerSpeed * Time.deltaTime, Space.World);

    }
}
