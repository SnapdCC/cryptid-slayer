using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool ChupaLevelBeaten;
    public bool JackLevelBeaten;
    public bool SquatchLevelBeaten;
    // Start is called before the first frame update
    void Start()
    {
        ChupaLevelBeaten = false;
        JackLevelBeaten = false;
        SquatchLevelBeaten = false;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void BeatChup(){
        //Run this when you beat the level
        ChupaLevelBeaten = true;
    }
    public bool ChupIsBeat(){
        return ChupaLevelBeaten;
    }
    public void BeatJack(){
        //Run this when you beat the level
        JackLevelBeaten = true;
    }
    public bool JackIsBeat(){
        return JackLevelBeaten;
    }
    public void BeatSquatch(){
        //Run this when you beat the level
        SquatchLevelBeaten = true;
    }
    public bool SquatchIsBeat(){
        return SquatchLevelBeaten;
    }
    public void GameOver(){
        //Run this when you lose the game or start a new game
        JackLevelBeaten = false;
        ChupaLevelBeaten = false;
        SquatchLevelBeaten = false;
    }
}
