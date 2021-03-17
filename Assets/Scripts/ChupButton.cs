using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class ChupButton : MonoBehaviour
{
    public GameObject Continue_Button;
    private float _sec;

    void Start()
    {
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
        SceneManager.LoadScene("BaseLevel");
    }
    public void ChupacabraLSillouette()
    {
        SceneManager.LoadScene("Silhouette");
    }
    public void JackalopeLSillouette()
    {
        SceneManager.LoadScene("JackalopeLSilhouette");
    }
}
