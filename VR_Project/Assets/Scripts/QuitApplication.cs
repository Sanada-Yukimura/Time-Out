using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitApplication : MonoBehaviour
{

    public void quit() {
      Debug.Log("Has quit game");
      Application.Quit();
    }

}
