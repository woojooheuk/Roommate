using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneChanger : MonoBehaviour
{
    public void ChangeScene()
    {
        string buttonTag = gameObject.tag;

        SceneManager.LoadScene(buttonTag);
    }
}
