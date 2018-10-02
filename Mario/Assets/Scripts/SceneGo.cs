using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneGo : MonoBehaviour {
    public void StartGame()
    {
        SceneManager.LoadScene(3);
    }
    public void BackTitle()
    {
        SceneManager.LoadScene(1);
    }
}
