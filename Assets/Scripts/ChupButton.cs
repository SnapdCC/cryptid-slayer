﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChupButton : MonoBehaviour
{
    GameManager GameManager;
    public GameObject Continue_Button;
    private float _sec;

    void Start()
    {
        GameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        Continue_Button.SetActive(false);
        StartCoroutine(ActivationRoutine());
    }

    private IEnumerator ActivationRoutine()
    {

        yield return new WaitForSeconds(_sec * Time.deltaTime);

        Continue_Button.SetActive(true);
    }

    public void ChupacabraLevel()
    {
        SceneManager.LoadScene("ChupacabraLevel");
    }
    public void JackalopeLevel()
    {
        SceneManager.LoadScene("JackalopeLevel");
    }
    public void BigfootLevel()
    {
        SceneManager.LoadScene("BigfootLevel");
    }
    public void JackToMapScreen()
    {
        GameManager.JackLevelBeaten = true;
        SceneManager.LoadScene("MapScreen");
    }
    public void ChupToMapScreen()
    {
        GameManager.ChupaLevelBeaten = true;
        SceneManager.LoadScene("MapScreen");
    }
    public void SquatchToMapScreen()
    {
        GameManager.SquatchLevelBeaten = true;
        SceneManager.LoadScene("MapScreen");
    }
    public void ChupacabraLSillouette()
    {
        SceneManager.LoadScene("Silhouette");
    }
    public void JackalopeLSillouette()
    {
        SceneManager.LoadScene("JackalopeLSilhouette");
    }
    public void BigfootLSillouette()
    {
        SceneManager.LoadScene("BigfootLSilhouette");
    }
    public void QuitGame(){
        Application.Quit();
    }
}
