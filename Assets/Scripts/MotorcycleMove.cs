using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleMove : MonoBehaviour
{

    GameObject vespa;

    //movement variables
    public Vector3 forward = new(1, 0, 0);
    public float playerSpeed = 0.012f;
    private bool drive = false;

    //variables to spawn vespa
    public GameObject whatToSpawn;
    Quaternion vespaRotation = Quaternion.Euler(0, -91, 0);
    GameObject parentForVespa;

    // Update is called once per frame
    private void Update()
    {
        if (drive)
        {
            disappear(vespa);
        }
    }

    public void driveAway()
    {
        Invoke("setDriveBoolTrue", 4); //offset to match sound
    }

    private void setDriveBoolTrue()
    {
        drive = true;
    }

    public void disappear(GameObject instantiatedVespa)
    {
        float howFarToMove = 10 * playerSpeed * Time.deltaTime;
        instantiatedVespa.transform.Translate(instantiatedVespa.transform.right * howFarToMove);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("collision triggered");
        if (other.gameObject.name.Equals("Vehicle01_Vespa(Clone)"))
        {
            drive = false;
            Object.Destroy(vespa);
        }
    }

    public void SpawnVespa()
    {
        if (vespa == null)
        {
            Debug.Log("vespa is null. spawning new vespa");
            parentForVespa = GameObject.FindGameObjectWithTag("ParentForVespa");

            Vector3 currentLocation =
                new(parentForVespa.transform.position.x + 0.04f, parentForVespa.transform.position.y + 0.004f, parentForVespa.transform.position.z + 0.02f);
            vespa = Instantiate(whatToSpawn, currentLocation, vespaRotation);
            vespa.transform.localScale = new(0.015f, 0.015f, 0.015f);

            vespa.transform.parent = parentForVespa.transform;
        }
    }

}
