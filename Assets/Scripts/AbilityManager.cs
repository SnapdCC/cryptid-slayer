using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityManager : MonoBehaviour
{
    public GameObject FootPanel;

    void Start()
    {
        FootPanel.SetActive(true);
    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            FootPanel.SetActive(false);
        }
    }
}
