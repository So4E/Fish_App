using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayANim : MonoBehaviour
{

    public Animator pla1;
    public Animator pla2;
    public GameObject whale1;
    public GameObject whale2;
    public string anim1;
    public string anim2;
    public string anim3;
    public string anim4;

    GameObject player1;
    GameObject player2;

    public Vector3 forwardAndDown = new Vector3(0,0.5f,1);

    public float playerSpeed = 0.012f;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void moveHorizontal(GameObject player)
    {
        float howFarToMove = 1 * playerSpeed * Time.deltaTime;
        player.transform.Translate(forwardAndDown * -howFarToMove);

    }

    // Update is called once per frame
    public void swimAway()
    {
        pla1.Play(anim1);
        pla2.Play(anim1);

        moveHorizontal(whale1);
        moveHorizontal(whale2);

        Object.Destroy(whale2);
        Object.Destroy(whale1);
    }

}
