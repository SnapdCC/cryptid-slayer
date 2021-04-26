using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RereadClue : MonoBehaviour
{
    public GameObject text, text2, text3, text4;
    

    // Update is called once per frame
    void Update()
    {
        
    }

    public void first_hint()
    {
        text.SetActive(true);
    }
    void second_hint()
    {
        text2.SetActive(true);
    }
    void third_hint()
    {
        text3.SetActive(true);
    }
    void fourth_hint()
    {
        text4.SetActive(true);
    }
}
