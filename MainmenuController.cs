using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainmenuController : MonoBehaviour
{

    public void PlayerGameButton()
    {
        Application.LoadLevel("1");

    }
    public void ExitGameButton()
    {
        Application.Quit();
    }
    
}
