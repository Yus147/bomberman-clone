using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private string level;

    public void ButtonMoveScence(string level)
    {
        SceneManager.LoadScene(level);
    }
}
