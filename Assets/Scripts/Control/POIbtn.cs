using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class POIbtn : MonoBehaviour
{
    public void OnButtonModeNavigator()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnButtonModeARScan()
    {
        SceneManager.LoadScene("Main");
    }
    public void OnButtonModePOI()
    {
        SceneManager.LoadScene("POI");
    }
}
