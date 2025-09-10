using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehav : MonoBehaviour
{
    private float horizontal;
    private float vertical;

    [SerializeField]
    private float speed = 8f;
   

    
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontal * speed * Time.deltaTime);
        transform.Translate(Vector3.up * vertical * speed * Time.deltaTime); 
    }
}
