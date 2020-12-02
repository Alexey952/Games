using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LoadingScene : MonoBehaviour
{
    public TextMeshProUGUI Procent;
    public int             Scene;

    void Start()
    {
        Scene = PlayerPrefs.GetInt("SceneLoading");
        StartCoroutine(AsyncLoad());
    }

    IEnumerator AsyncLoad()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(Scene);
        while (!operation.isDone)
        {
            float progress = operation.progress / 0.9f;
            Procent.text = string.Format("{0:0}", progress * 100);
            yield return null;
        }
    }
}
