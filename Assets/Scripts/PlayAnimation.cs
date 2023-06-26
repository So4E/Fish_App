using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayAnimation : MonoBehaviour
{

    public Animator pla1;
    public Animator pla2;
    public GameObject whale1;
    public GameObject whale2;
    public string anim1;
    public string anim2;

    public Vector3 forwardAndDown = new Vector3(0,0.5f,1);

    public float playerSpeed = 0.12f;
    private bool swimming = false;

    void Start()
    {
        //werte transform hier speichern
    }

    public void moveHorizontal(GameObject player)
    {
        float howFarToMove = 10 * playerSpeed * Time.deltaTime; 
        player.transform.Translate(forwardAndDown * -howFarToMove);

    }

    // Update is called once per frame
    public void swimAway()
    {
        pla1.Play(anim1);
        pla2.Play(anim1);
        swimming = true;
    }

    private void Update()
    {
        if (swimming)
        {
            moveHorizontal(whale1);
            moveHorizontal(whale2);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("collision triggered");
        if (other.gameObject.name.Equals("Whale_LowPoly"))
        { 
            Debug.Log("name: " + other.gameObject.name.Equals("Whale_LowPoly"));
            swimming = false;
            Object.Destroy(whale1);
            Object.Destroy(whale2);
        }

        if (other.gameObject.name.Equals("Whale_LowPoly_small"))
        {
            swimming = false;
            Object.Destroy(whale1);
            Object.Destroy(whale2);
        }
    }

    private void RespawnWhales()
    {
        if(whale1 = null)
        {
            // Instantiate methode die transform variablen mitgeben 
            // Instantiate(whale1);
            // Instantiate(whale2);
        }
    }

}
