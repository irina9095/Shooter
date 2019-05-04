using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, zMin, xMax, zMax;
    
}

public class PlayerShipScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public float tilt;
    public float touchSpeedMove;
    public Boundary boundary;// границы движения корабля

    public GameObject lazerShot;
    public GameObject lazerGun;

    public float shotDelay;

    private float nextShoot;//время следующего выстрела

    void Start()
    {
        Screen.orientation = ScreenOrientation.Portrait;
    }

    // Update is called once per frame
    void Update()
    {
        bool CanShoot = Time.time > nextShoot;
        if (Input.GetButton("Fire1") && CanShoot)
        {
            nextShoot = Time.time + shotDelay;
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
        }
    }
    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Resolution[] resolutions = Screen.resolutions;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (moveHorizontal ==0 && touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.x > 0)
                    moveHorizontal = touchSpeedMove;
                else if (touch.deltaPosition.x < 0)
                    moveHorizontal = -touchSpeedMove ;
            }

            if(moveVertical == 0 && touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.y > 0) 
                    moveVertical = touchSpeedMove;
                else if (touch.deltaPosition.y < 0)
                    moveVertical = -touchSpeedMove;
            }
        }

        Rigidbody ship = GetComponent<Rigidbody>();

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);

        float xPosition = Mathf.Clamp(ship.position.x, boundary.xMin, boundary.xMax);
        float zPosition = Mathf.Clamp(ship.position.z, boundary.zMin, boundary.zMax);

        ship.position = new Vector3(xPosition, 0, zPosition);
    }
}
