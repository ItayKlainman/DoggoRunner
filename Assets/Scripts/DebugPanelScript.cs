using Lean.Touch;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class DebugPanelScript : MonoBehaviour
{
    public NavMeshAgent truckagent;
    public Slider truckSpeed, playerSpeed, ObstacleHeight, DragSensetivity;
    public TMP_Dropdown drop;
    public LeanDragTranslate leandrag;
    public GameObject tutorial;
   


    private List<GameObject> obstacles = new List<GameObject>();
    private int multiplyer = 2;

    private Vector3 startCameraPos;
    private Vector3 startCameraRot;
    
 
    private void Awake()
    {
        var obstaclesingame = GameObject.FindGameObjectsWithTag("Obstacle");
        foreach(GameObject obstacle in obstaclesingame)
        {
            obstacles.Add(obstacle);
        }
    }

    void Start()
    {
        //truck Debugger
        truckSpeed.maxValue = truckagent.speed * multiplyer;
        truckSpeed.minValue = 1;
        truckSpeed.value = truckSpeed.maxValue / multiplyer;
        
        //player Debugger
        playerSpeed.maxValue = PlayerMovement.shared.movementSpeed * multiplyer;
        playerSpeed.minValue = 1;
        playerSpeed.value = playerSpeed.maxValue/multiplyer;

        //Drag Sensetivity Debugger
        DragSensetivity.maxValue = leandrag.Sensitivity * multiplyer;
        DragSensetivity.minValue = 0.1f;
        DragSensetivity.value = DragSensetivity.maxValue / multiplyer;


        //Obstacle Debugger
        ObstacleHeight.maxValue = obstacles[0].transform.localScale.y * multiplyer;
        ObstacleHeight.minValue = 1;
        ObstacleHeight.value = ObstacleHeight.maxValue / multiplyer;

        startCameraPos = Camera.main.transform.localPosition;
        startCameraRot = Camera.main.transform.localRotation.eulerAngles;
        

        tutorial.SetActive(false);
    }

  public void ChangeTruckSpeed()
    {
        truckagent.speed = truckSpeed.value;
    }

    public void ChangePlayerSpeed()
    {
        PlayerMovement.shared.movementSpeed = playerSpeed.value;
    }
    public void ChangeDragSensetivity()
    {
        leandrag.Sensitivity = DragSensetivity.value;
    }

    public void ChangeObstacleHeight()
    {
        foreach(GameObject obstacle in obstacles)
        {
            obstacle.transform.localScale = new Vector3(obstacle.transform.localScale.x, ObstacleHeight.value, obstacle.transform.localScale.z);
        }
    }
    public void CameraPreset1()
    {
        Camera.main.transform.localPosition = startCameraPos;  
        Camera.main.transform.eulerAngles = startCameraRot;
    }

    public void CameraPreset2()
    {
        Camera.main.transform.localPosition = new Vector3(-6.46f, 8.29f,-18.76001f);
        Camera.main.transform.eulerAngles = new Vector3(15.055f, 11.202f, 0);
    }

    public void CameraPreset3()
    {
        Camera.main.transform.localPosition = new Vector3(10.9f, 14.7f, -20.62001f);
        Camera.main.transform.eulerAngles = new Vector3(8.940001f, -13.861f, 0f);
    }

    public void ResetValues()
    {
        playerSpeed.value = playerSpeed.maxValue / multiplyer;
        truckSpeed.value = truckSpeed.maxValue / multiplyer;
        ObstacleHeight.value = ObstacleHeight.maxValue / multiplyer;
        DragSensetivity.value = DragSensetivity.maxValue / multiplyer;
        CameraPreset1();
        
    }
    public void ResetMultiplyer()
    {
        drop.value = 0;
    }

    public void ChangeMultiplyer()
    {
        ResetValues();
        int val = drop.value;
        if(val == 0)
        {      
            multiplyer = 2;
        }
        if(val == 1)
        {      
            multiplyer = 3;
        }
        if (val == 2)
        {
            multiplyer = 4;
        }
        if (val == 3)
        {
            multiplyer = 5;
        }   
        UpdateValues();
    }
    private void UpdateValues()
    {
        ChangeObstacleHeight();
        ChangePlayerSpeed();
        ChangeTruckSpeed();
        ChangeDragSensetivity(); 
        ObstacleHeight.maxValue = obstacles[0].transform.localScale.y * multiplyer;
        playerSpeed.maxValue = PlayerMovement.shared.movementSpeed * multiplyer;
        truckSpeed.maxValue = truckagent.speed * multiplyer;
        DragSensetivity.maxValue = leandrag.Sensitivity * multiplyer;

    }

}
