using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WhaleController : MonoBehaviour
{

    public Animator pla1;
    GameObject whale1; //big
    GameObject whale2; //small
    public string anim1;

    //variables to swim away
    public Vector3 forwardAndDown = new Vector3(0,0.5f,1);
    public float playerSpeed = 0.12f;
    private bool swimmingAway = false;

    //variables to spawn whales
    public GameObject whatToSpawn;
    Quaternion bothWhalesRotation = Quaternion.Euler(0, 90, 0);
    GameObject parentForWhales;

    void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        if (swimmingAway)
        {
            moveHorizontal(whale1);
            moveHorizontal(whale2);
        }
    }

    public void moveHorizontal(GameObject player)
    {
        float howFarToMove = 10 * playerSpeed * Time.deltaTime; 
        player.transform.Translate(forwardAndDown * -howFarToMove);
    }

    public void swimAway()
    {
        swimmingAway = true;
    }


    private void OnTriggerExit(Collider other)
    {
        Debug.Log("collision triggered");
        if (other.gameObject.name.Equals("Whale_LowPoly(Clone)"))
        { 
            swimmingAway = false;
            Object.Destroy(whale1);
            Object.Destroy(whale2);
        }
    }

    public void SpawnWhales()
    {
        if(whale1 == null)
        {
            Debug.Log("whale1 is null. spawning new whale1");
            parentForWhales = GameObject.FindGameObjectWithTag("ParentForWhale");

            Vector3 currentLocation =
                new(parentForWhales.transform.position.x, parentForWhales.transform.position.y + 0.008f, parentForWhales.transform.position.z - 0.012f);
            whale1 = Instantiate(whatToSpawn, currentLocation, bothWhalesRotation);
            whale1.transform.localScale = new(0.003f, 0.003f, 0.003f);

            whale1.transform.parent = parentForWhales.transform;

        }
        if (whale2 == null)
        {
            Debug.Log("whale1 is null. spawning new whale1");
            parentForWhales = GameObject.FindGameObjectWithTag("ParentForWhale");

            Vector3 currentLocation =
                new(parentForWhales.transform.position.x + 0.02f, parentForWhales.transform.position.y + 0.01f, parentForWhales.transform.position.z + 0.02f);
            whale2 = Instantiate(whatToSpawn, currentLocation, bothWhalesRotation);
            whale2.transform.localScale = new(0.002f, 0.002f, 0.002f); // hier anpassen, wenns sein muss

            whale2.transform.parent = parentForWhales.transform;
        }
    }

}
