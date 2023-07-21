using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnScene : MonoBehaviour
{
    public GameObject sceneToSpawn;
    GameObject currentScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpawnThisScene()
    {
        if (currentScene != null)
        {
            Object.Destroy(currentScene);
        }

        Debug.Log("scene is null. spawning new scene");

        Vector3 currentLocation =
            new(this.transform.position.x, this.transform.position.y, this.transform.position.z);
        Vector3 currentRotation =
            new(this.transform.rotation.x, this.transform.rotation.y, this.transform.rotation.z);
        currentScene = Instantiate(sceneToSpawn, currentLocation, Quaternion.Euler(currentRotation));
        //currentScene.transform.localScale = new(1f, 1f, 1f);

        currentScene.transform.parent = this.transform;
    }

    public void DestroyScene()
    {
        if (currentScene != null)
        {
            Object.Destroy(currentScene);
        }
    }
}
