using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{



    public void PlayAgain()
    {

        Time.timeScale = 1;
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(sceneIndex);
        
        

    }

    public void QuitGame()
    {
        
        Application.Quit();
        
        
    }
    
    
}
