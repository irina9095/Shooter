using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, zMin, xMax,  zMax;
    
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

    void Update()
    {
        bool isGameStarted = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().isGameStarted;
        bool CanShoot = Time.time > nextShoot;

        if (!isGameStarted)
        {
            return;
        }
        else if (Input.GetButton("Fire1") && CanShoot)
        {
            nextShoot = Time.time + shotDelay;
            Instantiate(lazerShot, lazerGun.transform.position, Quaternion.identity);
        }
    }
    private void FixedUpdate()
    {


        float moveHorizontal = Input.GetAxis("Horizontal");
        //Debug.Log("X "+moveHorizontal);

        float moveVertical = Input.GetAxis("Vertical");
        //Debug.Log("Y " + moveHorizontal);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float touchSpeedMove = 0.06f;
            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.x > 0)
                    moveHorizontal = touchSpeedMove * speed;
                else if (touch.deltaPosition.x < 0)
                    moveHorizontal = -touchSpeedMove * speed;
            }
            if (touch.phase == TouchPhase.Moved)
            {
                if (touch.deltaPosition.y > 0)
                    moveVertical = Mathf.Clamp(touchSpeedMove * speed, -1, 1);
                else if (touch.deltaPosition.y < 0)
                    moveVertical = Mathf.Clamp(-touchSpeedMove * speed, -1, 1);
            }

        }

        Rigidbody ship = GetComponent<Rigidbody>();
        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        ship.rotation = Quaternion.Euler(ship.velocity.z * (tilt / 3), 0, -ship.velocity.x * tilt);

        float xPosition = Mathf.Clamp(ship.position.x, boundary.xMin, boundary.xMax);
        float zPosition = Mathf.Clamp(ship.position.z, boundary.zMin, boundary.zMax);

        ship.position = new Vector3(xPosition, 0, zPosition);

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;
        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);
        

        ship.position = new Vector3(xPosition, 0, zPosition);
    }
}
