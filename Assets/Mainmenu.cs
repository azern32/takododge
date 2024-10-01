using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Mainmenu : MonoBehaviour
{
    public void Play()
    {
        SceneManager.LoadScene("Gameplay");
    }
    public void Quit()
    {
        Application.Quit();
    }

    public void Test()
    {
        Debug.Log("Nda masuk kah??");
    }
}
