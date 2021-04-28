using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SoundScript : MonoBehaviour
{
    public AudioSource backgroundmusic;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);

    }

    void Update()
    {
        // Create a temporary reference to the current scene.
        Scene currentScene = SceneManager.GetActiveScene();

        // Retrieve the name of this scene.
        string sceneName = currentScene.name;

        if (sceneName == "JackalopeLevel")
        {
            backgroundmusic.Stop();
        }
        else if (sceneName == "ChupacabraLevel")
        {
            backgroundmusic.Stop();
        }
        else if (sceneName == "BigfootLevel")
        {
            backgroundmusic.Stop();
        }
    }
}
