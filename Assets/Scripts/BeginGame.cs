using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class BeginGame : MonoBehaviour
{
    public void LoadScene(int sceneindex)
    {
        SceneManager.LoadScene(sceneindex);
    }
}
