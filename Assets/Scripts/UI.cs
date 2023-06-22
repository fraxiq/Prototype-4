using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public void OnRestartClicked()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Prototype 4");
    }
}
