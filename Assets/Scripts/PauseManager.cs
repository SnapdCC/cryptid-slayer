using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel, controlPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            if(pausePanel.gameObject.activeSelf){
                Unpause();
            }
            else{
                Pause();
            }
        }
    }
    public void Unpause(){
        pausePanel.gameObject.SetActive(false);
        Time.timeScale=1f;
    }
    void Pause(){
        pausePanel.gameObject.SetActive(true);
        Time.timeScale=0f;
    }
    public void QuitButton(){
        Application.Quit();
    }
    public void MainMenuButton(){
        SceneManager.LoadScene(0);
    }
    public void ControlsButton()
    {
        controlPanel.SetActive(true);
    }
    public void BackButton()
    {
        controlPanel.SetActive(false);
    }
}
