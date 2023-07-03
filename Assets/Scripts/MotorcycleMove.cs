using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleMove : MonoBehaviour
{

    GameObject vespa;

    //movement variables
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
        instantiatedVespa.transform.Translate(Vector3.forward * howFarToMove);
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
        if (vespa != null)
        {
            Object.Destroy(vespa);
        }

            Debug.Log("vespa is null. spawning new vespa");
            parentForVespa = GameObject.FindGameObjectWithTag("ParentForVespa");

            Vector3 currentLocation =
                new(parentForVespa.transform.position.x + 0.04f, parentForVespa.transform.position.y + 0.004f, parentForVespa.transform.position.z + 0.02f);
            Vector3 currentRotation =
                new(parentForVespa.transform.rotation.x, parentForVespa.transform.rotation.y -90, parentForVespa.transform.rotation.z);
            vespa = Instantiate(whatToSpawn, currentLocation, Quaternion.Euler(currentRotation));
            vespa.transform.localScale = new(0.015f, 0.015f, 0.015f);

            vespa.transform.parent = parentForVespa.transform;
    }

}
