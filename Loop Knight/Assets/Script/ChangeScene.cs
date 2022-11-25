using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
    public string URL = "https://github.com/MonPanitan/Loop-Knight_Unity";
    public void GoToScene1()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void loadUrl()
    {
        Application.OpenURL(URL);
    }
}
