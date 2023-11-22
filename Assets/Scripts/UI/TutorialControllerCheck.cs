using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TutorialControllerCheck : MonoBehaviour
{
    [SerializeField] private GameObject Tile1;
    [SerializeField] private GameObject Tile2;
    private void Start()
    {
        
    }
    void Update()
    {
        CheckForControllers();
    }

    void CheckForControllers()
    {
        string[] joystickNames = Input.GetJoystickNames();

        if (joystickNames.Length > 0 && !string.IsNullOrEmpty(joystickNames[0]))
        {
            // At least one controller is connected
            Debug.Log("Controller connected: " + joystickNames[0]);
            Tile1.SetActive(false);
            Tile2.SetActive(true);

        }
        else
        {
            // No controllers are connected
            Debug.Log("No controller connected");
            Tile1.SetActive(true);
            Tile2.SetActive(false);
        }
    }
}
