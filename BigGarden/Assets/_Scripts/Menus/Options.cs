using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Options : MonoBehaviour {

    public Jae_VIDEPlayerScript movement;

    public Slider volumeS;
    public float volume;
    public Text volumeT;

    public Dropdown resolution;
    public Toggle fullScreen;

    public Button up; public Button down; public Button left; public Button right; public Button interact; public Button sprint;
    public string buttonPushed;
    public GameObject controlPanel;

    // Use this for initialization
    void Start () {
        movement = GameObject.FindGameObjectWithTag("Player").GetComponent<Jae_VIDEPlayerScript>();

        volumeS.value = 50;
        fullScreen.isOn = false;
	}
	
	// Update is called once per frame
	void Update () {
        volume = Mathf.RoundToInt(volumeS.value);
        volumeT.text = "" + volume;
        AudioListener.volume = volume;

        if(controlPanel.activeSelf == true)
        {
            #region up
            if (Input.inputString != "" && buttonPushed == "up")
            {
                GameObject.Find("UpButton").GetComponentInChildren<Text>().text = Input.inputString.ToUpper();
                movement.upKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), Input.inputString.ToUpper());
                controlPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftControl) && buttonPushed == "up")
            {
                GameObject.Find("UpButton").GetComponentInChildren<Text>().text = "Left Control";
                movement.upKey = KeyCode.LeftControl;
                controlPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Escape) && buttonPushed == "up")
            {
                controlPanel.SetActive(false);
            }
            #endregion
            #region down
            if (Input.inputString != "" && buttonPushed == "down")
            {
                GameObject.Find("DownButton").GetComponentInChildren<Text>().text = Input.inputString.ToUpper();
                movement.downKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), Input.inputString.ToUpper());
                controlPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftControl) && buttonPushed == "down")
            {
                GameObject.Find("DownButton").GetComponentInChildren<Text>().text = "Left Control";
                movement.downKey = KeyCode.LeftControl;
                controlPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Escape) && buttonPushed == "down")
            {
                controlPanel.SetActive(false);
            }
            #endregion
            #region left
            if (Input.inputString != "" && buttonPushed == "left")
            {
                GameObject.Find("LeftButton").GetComponentInChildren<Text>().text = Input.inputString.ToUpper();
                movement.leftKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), Input.inputString.ToUpper());
                controlPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftControl) && buttonPushed == "left")
            {
                GameObject.Find("LeftButton").GetComponentInChildren<Text>().text = "Left Control";
                movement.leftKey = KeyCode.LeftControl;
                controlPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Escape) && buttonPushed == "left")
            {
                controlPanel.SetActive(false);
            }
            #endregion
            #region right
            if (Input.inputString != "" && buttonPushed == "right")
            {
                GameObject.Find("RightButton").GetComponentInChildren<Text>().text = Input.inputString.ToUpper();
                movement.rightKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), Input.inputString.ToUpper());
                controlPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftControl) && buttonPushed == "right")
            {
                GameObject.Find("RightButton").GetComponentInChildren<Text>().text = "Left Control";
                movement.rightKey = KeyCode.LeftControl;
                controlPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Escape) && buttonPushed == "right")
            {
                controlPanel.SetActive(false);
            }
            #endregion
            #region interact
            if (Input.inputString != "" && buttonPushed == "interact")
            {
                GameObject.Find("InteractButton").GetComponentInChildren<Text>().text = Input.inputString.ToUpper();
                movement.actionKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), Input.inputString.ToUpper());
                controlPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftControl) && buttonPushed == "interact")
            {
                GameObject.Find("InteractButton").GetComponentInChildren<Text>().text = "Left Control";
                movement.actionKey = KeyCode.LeftControl;
                controlPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Escape) && buttonPushed == "interact")
            {
                controlPanel.SetActive(false);
            }
            #endregion
            #region sprint
            if (Input.inputString != "" && buttonPushed == "sprint")
            {
                GameObject.Find("SprintButton").GetComponentInChildren<Text>().text = Input.inputString.ToUpper();
                movement.runKey = (KeyCode)System.Enum.Parse(typeof(KeyCode), Input.inputString.ToUpper());
                controlPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.LeftControl) && buttonPushed == "sprint")
            {
                GameObject.Find("SprintButton").GetComponentInChildren<Text>().text = "Left Control";
                movement.runKey = KeyCode.LeftControl;
                controlPanel.SetActive(false);
            }
            if (Input.GetKeyDown(KeyCode.Escape) && buttonPushed == "sprint")
            {
                controlPanel.SetActive(false);
            }
            #endregion
        }
    }

    public void ScreenRes()
    {
        if (resolution.value == 0 && fullScreen.isOn == false)
        {
            Screen.SetResolution(1024, 768, false);
        }
        if (resolution.value == 0 && fullScreen.isOn == true)
        {
            Screen.SetResolution(1024,768, true);
        }
        if (resolution.value == 1 && fullScreen.isOn == true)
        {
            Screen.SetResolution(1366, 768, true);
        }
        if (resolution.value == 1 && fullScreen.isOn == false)
        {
            Screen.SetResolution(1366, 768, false);
        }
        if (resolution.value == 2 && fullScreen.isOn == true)
        {
            Screen.SetResolution(1920, 1200, true);
        }
        if (resolution.value == 2 && fullScreen.isOn == false)
        {
            Screen.SetResolution(1920, 1200, false);
        }
        if (resolution.value == 3 && fullScreen.isOn == true)
        {
            Screen.SetResolution(1920, 1080, true);
        }
        if (resolution.value == 3 && fullScreen.isOn == false)
        {
            Screen.SetResolution(1920, 1080, false);
        }
    }

    public void OnClickedButton()
    {
       if(EventSystem.current.currentSelectedGameObject.name == "UpButton")
       {
            controlPanel.SetActive(true);
            buttonPushed = "up";
       }
        if (EventSystem.current.currentSelectedGameObject.name == "DownButton")
        {
            controlPanel.SetActive(true);
            buttonPushed = "down";
        }
        if (EventSystem.current.currentSelectedGameObject.name == "LeftButton")
        {
            controlPanel.SetActive(true);
            buttonPushed = "left";
        }
        if (EventSystem.current.currentSelectedGameObject.name == "RightButton")
        {
            controlPanel.SetActive(true);
            buttonPushed = "right";
        }
        if (EventSystem.current.currentSelectedGameObject.name == "InteractButton")
        {
            controlPanel.SetActive(true);
            buttonPushed = "interact";
        }
        if (EventSystem.current.currentSelectedGameObject.name == "SprintButton")
        {
            controlPanel.SetActive(true);
            buttonPushed = "sprint";
        }
    }
}
