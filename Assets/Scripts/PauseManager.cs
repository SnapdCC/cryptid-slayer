using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseManager : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.P)){
            if(gameObject.activeSelf){
                Unpause();
            }
            else{
                Pause();
            }
        }
    }
    public void Unpause(){
        gameObject.SetActive(false);
        Time.timeScale=1f;
    }
    void Pause(){
        gameObject.SetActive(true);
        Time.timeScale=0f;
    }
    void QuitButton(){

    }
    void MainMenuButton(){

    }
}
