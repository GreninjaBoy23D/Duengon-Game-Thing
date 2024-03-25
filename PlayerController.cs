using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject North;
    public GameObject South;
    public GameObject East;
    public GameObject West;
    private float speed = 5.0f;
    private bool amMoving = false;
    void Start()
    {
        //disable all exits when the scene first loads
        this.turnOffExits();
        this.gameObject.transform.position = new Vector3(0f, 0.5f, 0f);

        //not our first scene
        Scenes.currentScene = EditorSceneManager.GetSceneByName("?");
        if(Scenes.currentScene == EditorSceneManager.GetSceneByName("?"))
        {
            if(Scenes.currentScene == EditorSceneManager.GetSceneByName("Entrance"))
            {
                Scenes.currentScene = EditorSceneManager.GetSceneByName("FirstRoom");
            }
            else if (Scenes.currentScene == EditorSceneManager.GetSceneByName("FirstRoom"))
            {
                Scenes.currentScene = EditorSceneManager.GetSceneByName("SecondRoom");
            }
            else
            {
                Scenes.currentScene = EditorSceneManager.GetSceneByName("SecondRoom");
            }
        }


        if (!MySingleton.currentDirection.Equals("?"))
        {
            if (MySingleton.currentDirection.Equals("north"))
            {
                this.gameObject.transform.position = this.North.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("south"))
            {
                this.gameObject.transform.position = this.South.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("west"))
            {
                this.gameObject.transform.position = this.West.transform.position;
            }
            else if (MySingleton.currentDirection.Equals("east"))
            {
                this.gameObject.transform.position = this.East.transform.position;
            }
        }
    }

    private void turnOffExits()
    {
        this.North.gameObject.SetActive(false);
        this.South.gameObject.SetActive(false);
        this.East.gameObject.SetActive(false);
        this.West.gameObject.SetActive(false);

    }

    private void turnOnExits()
    {
        this.North.gameObject.SetActive(true);
        this.South.gameObject.SetActive(true);
        this.East.gameObject.SetActive(true);
        this.West.gameObject.SetActive(true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        print("onCollision");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pellet"))
        {
            other.gameObject.SetActive(false);
            EditorSceneManager.LoadScene("Battle");
        }
        if (Scenes.currentScene == EditorSceneManager.GetSceneByName("Entrance"))
        {
            EditorSceneManager.LoadScene("FirstRoom");
            Scenes.currentScene = EditorSceneManager.GetSceneByName("First");
        }
        if(Scenes.currentScene == EditorSceneManager.GetSceneByName("First"))
        {
            EditorSceneManager.LoadScene("SecondRoom");
            Scenes.currentScene = EditorSceneManager.GetSceneByName("Second");
        }
        MySingleton.currentDirection = "?";
        if (!MySingleton.currentDirection.Equals("?"))
        {
            this.turnOffExits();
            this.amMoving = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        print("onTriggerExit");

    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "north";
            this.gameObject.transform.LookAt(this.North.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "south";
            this.gameObject.transform.LookAt(this.South.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "west";
            this.gameObject.transform.LookAt(this.West.transform.position);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            this.amMoving = true;
            this.turnOnExits();
            MySingleton.currentDirection = "east";
            this.gameObject.transform.LookAt(this.East.transform.position);

        }

        //make the player move in the current direction
        if (MySingleton.currentDirection.Equals("north"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.North.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("south"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.South.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("west"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.West.transform.position, this.speed * Time.deltaTime);
        }

        if (MySingleton.currentDirection.Equals("east"))
        {
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, this.East.transform.position, this.speed * Time.deltaTime);
        }
    }
}
