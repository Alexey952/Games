using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriptVoids : MonoBehaviour
{
    private int h;

    public void CloseAny(GameObject obj)
    {
        obj.SetActive(false);
    }
    public void Starting()
    {
        h = UnityEngine.Random.Range(3, 5);
        PlayerPrefs.SetInt("SceneLoading", h);
        SceneManager.LoadScene(1);
    }
}
