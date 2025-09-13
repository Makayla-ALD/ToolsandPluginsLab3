using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehav : MonoBehaviour
{
    private Vector2 direction;
    //private Vector2 side;
    //private Vector2 up;
    //private Vector3 cross;

    public GameObject playerToOrbit;
    public Transform player;

    private float currentAngle;
    private float angularSpeed = 10f;
    private float radius = 3f;

    //Vector2 radius = new Vector2(0, 3f);
    
    //[SerializeField]
    //Transform player;
    //[SerializeField]
    //private Rigidbody2D rb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        //up = transform.up;
        //side = Vector3.Cross(direction, up);
        direction =  (transform.position - playerToOrbit.transform.position). normalized;
        radius = Vector3.Distance(playerToOrbit.transform.position, transform.position);
        
    }

    // Update is called once per frame
    void Update()
    {
        //direction = player.transform.position - transform.position;
        transform.LookAt(player);//enemy will look at player
        currentAngle += angularSpeed * Time.deltaTime;

        if (currentAngle > 360)
        {
            currentAngle -= 360;
        }

        Vector2 orbit = Vector2.right * radius;
        orbit = Quaternion.LookRotation(direction) * Quaternion.Euler(0, currentAngle, 0) * orbit;

        transform.position = playerToOrbit.transform.position * orbit;
        //cross = Vector3.Cross(direction, side);
        //Vector2 positionOnOrbit = player.position + Quaternion.AngleAxis(currentAngle, player.position) * radius;
        //transform.position = positionOnOrbit;
        //Transform.Rotate(player.transform.position, Vector2.up, 20 * Time.deltaTime);

    }

    private void FixedUpdate()
    {
        //rb.AddForce(cross.normalized * 50);
        //rb.AddForce(direction.normalized * 50);
    }
}
