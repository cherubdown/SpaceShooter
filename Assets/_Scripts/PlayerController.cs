using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerController : MonoBehaviour {

    public float Speed, Tilt;
    public Boundary Boundary;


    public void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        var ship = GetComponent<Rigidbody>();

        Vector3 vector = new Vector3(moveHorizontal, 0.0f, moveVertical);
        ship.velocity = vector * Speed;

        ship.position = new Vector3
        (
            Mathf.Clamp(ship.position.x, Boundary.xMin, Boundary.xMax), 
            0.0f,
            Mathf.Clamp(ship.position.z, Boundary.zMin, Boundary.zMax)
        );

        ship.rotation = Quaternion.Euler(0.0f, 0.0f, ship.velocity.x * -Tilt);
    }
}
