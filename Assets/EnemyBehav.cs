using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehav : MonoBehaviour
{
    private Vector2 direction;
    private Vector2 side;
    private Vector2 up;
    private Vector3 cross;

    private float currentAngle = 0f;
    private float angularSpeed = 10f;

    Vector2 radius = new Vector2(0, 3f);
    
    [SerializeField]
    Transform player;
    [SerializeField]
    private Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //up = transform.up;
        //side = Vector3.Cross(direction, up);
    }

    // Update is called once per frame
    void Update()
    {

        //direction = player.transform.position - transform.position;
        //transform.LookAt(player.position);
        //cross = Vector3.Cross(direction, side);
        currentAngle += angularSpeed * Time.deltaTime;
         Vector2 positionOnOrbit = player.position + Quaternion.AngleAxis(currentAngle, player.position) * radius;
         transform.position = positionOnOrbit;
        //transform.rotation = Quaternion.AngleAxis(30, player.position);

    }

    private void FixedUpdate()
    {
        //rb.AddForce(cross.normalized * 50);
        //rb.AddForce(direction.normalized * 50);
    }
}
