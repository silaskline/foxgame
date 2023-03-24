using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string sceneName;
    void OnTriggerEnter2D(Collider2D thingThatHit)
    {
        SceneManager.LoadScene(sceneName);
    }
}
