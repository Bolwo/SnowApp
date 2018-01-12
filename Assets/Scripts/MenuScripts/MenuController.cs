using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.UIElements;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {


    GameObject settingsPanel;
    GameObject menuPanel;
    GameObject collapseButton;
	// Use this for initialization
	void Start () {
        settingsPanel = GameObject.Find("SettingsPanel");
        menuPanel = GameObject.Find("MenuPanel");
        collapseButton = GameObject.Find("CollapseButton");

        ToggleSettingsPanel();
    }
	
	// Update is called once per frame
	void Update () {
		
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
