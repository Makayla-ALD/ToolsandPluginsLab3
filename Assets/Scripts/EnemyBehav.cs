using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehav : MonoBehaviour
{

    [SerializeField] private Transform player;
    [SerializeField] float rotationSpeed;
    [SerializeField] private float orbitOffset;
    float speedMult = 0.3f;
    float baseSpeed = 3f;
    float minDistance;

    private void Start()
    {
        //Randomize the distance from the player each enemy is based on the scale of the enemy
        //Uses scale of enemy to prevent the enemy from overlapping with the player
        minDistance = transform.localScale.x;
        Debug.Log(minDistance);
        orbitOffset = Random.Range(minDistance, (minDistance + 7));
    }

    void Update()
    {
        
        RotateAroundPlayer();
        LookAtPlayer();
        ChangeSpeed();
    }

    /// <summary>
    /// Control enemies' rotation around the player
    /// </summary>
    void RotateAroundPlayer()
    {
        //Get the angle the enemy is at and the position of the player
        float _angle = Time.time * rotationSpeed;
        Vector3 _positionCenterObject = player.position;

        //Calculate the next position of the enemy in a curve around the player
        float _x = _positionCenterObject.x + Mathf.Cos(_angle) * orbitOffset;
        float _y = _positionCenterObject.y + Mathf.Sin(_angle) * orbitOffset;

        //Assign new position based off calculations
        transform.position = new Vector3(_x, _y);

    }

    /// <summary>
    /// Make enemy always face the player
    /// </summary>
    void LookAtPlayer()
    {
        //get the vector between the enemy and the player
        Vector3 _lookDirection = transform.position - player.transform.position;
        _lookDirection.Normalize();
        //Create a quaternion using the vector and use Slerp to rotate the enemy based on the calculated quaternion
        Quaternion _targetRotation = new Quaternion(_lookDirection.x, _lookDirection.y, _lookDirection.z, 0);
        transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, 0.1f);
    }

    /// <summary>
    /// Change the speed of the enemy based on the distance from the player
    /// The further away from the player, the slower the enemy
    /// </summary>
    void ChangeSpeed()
    {
        //Calculate the distance between the enemy and the player
        float _distance = Vector3.Distance(transform.position, player.position);
        //Calculate the rotation speed using a multiplier and the distance, subtract from the base speed
        rotationSpeed = Mathf.Abs(baseSpeed + (_distance * speedMult));

        //Check to make sure the distance from the player never goes under the minimum for preventing overlap
        if(_distance < minDistance)
        {
            orbitOffset = minDistance;
        }
    }

}
