using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleMove : MonoBehaviour
{

    public GameObject motorcycle;
    public Vector3 forwardAndDown = new Vector3(0, 0.5f, 1);
    public float playerSpeed = 0.012f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void driveAway()
    {
        Invoke("disappear", 4);
    }

    public void disappear()
    {
        float howFarToMove = 5 * playerSpeed * Time.deltaTime;
        motorcycle.transform.Translate(forwardAndDown * -howFarToMove);
        Object.Destroy(motorcycle);

    }
}
