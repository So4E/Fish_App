using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorcycleMove : MonoBehaviour
{

    GameObject vespa;

    //movement variables
    public float playerSpeed = 0.012f;
    private bool drive = false;

    // Update is called once per frame
    private void Update()
    {
        if (drive)
        {
            disappear();
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

    void disappear()
    {
        if (vespa == null)
        {
            vespa = GameObject.FindGameObjectWithTag("Vespa");
        }
        float howFarToMove = 10 * playerSpeed * Time.deltaTime;
        vespa.transform.Translate(Vector3.forward * howFarToMove);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("collision triggered");
        if (other.gameObject.name.Equals("Vehicle01_Vespa"))
        {
            drive = false;
            Object.Destroy(vespa);
        }
    }

    /* --- NOT NEEDED ANYMORE DUE TO SPAWNING OF WHOLE SCENE ON 10 EURO BACK
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
    }*/

}
