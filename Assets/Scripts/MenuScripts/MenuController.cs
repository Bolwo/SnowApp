using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {


    GameObject settingsPanel;
    GameObject menuPanel;
    GameObject collapseButton;
    GameObject toggleTrackingButton;
	// Use this for initialization
	void Start () {
        settingsPanel = GameObject.Find("SettingsPanel");
        menuPanel = GameObject.Find("MenuPanel");
        collapseButton = GameObject.Find("CollapseButton");
        toggleTrackingButton = GameObject.Find("ToggleTrackingButton");
        settingsPanel.GetComponentInChildren<Text>().text = "Test";

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.location.status == LocationServiceStatus.Stopped || Input.location.status == LocationServiceStatus.Failed)
        {
            toggleTrackingButton.GetComponentInChildren<Text>().text = "Not Tracking";
        } else if(Input.location.status == LocationServiceStatus.Initializing || Input.location.status == LocationServiceStatus.Running)
        {
            toggleTrackingButton.GetComponentInChildren<Text>().text = "Tracking";
        }

    } 

    public void ToggleLoggingButton()
    {

    }
    public void ToggleSettingsPanel()
    {
        if (settingsPanel.activeSelf)
        {
            settingsPanel.gameObject.SetActive(false);
        } else
        {
            settingsPanel.gameObject.SetActive(true);
        }
    }

    public void ToggleMenuPanel()
    {
        Vector3 pos = collapseButton.transform.position;
        
        if (menuPanel.activeSelf)
        {
            menuPanel.gameObject.SetActive(false);
            pos.x += 100f;
            collapseButton.transform.position = pos;
        }
        else
        {
            menuPanel.gameObject.SetActive(true);
            pos.x -= 100f;
            collapseButton.transform.position = pos;
        }
    }
}
