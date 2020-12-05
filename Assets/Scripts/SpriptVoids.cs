using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpriptVoids : MonoBehaviour
{
    private int h;
    void Start()
    {
        PlayerPrefs.SetInt("PositionJoystick", 0);
    }
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
    public void ChangedJoystick()
    {
        SceneManager.LoadScene("JoystickSettings");
    }
    public void JoystickExit()
    {
        SceneManager.LoadScene(2);
    }
    public void JoystickTransformPosition()
    {
        if (PlayerPrefs.GetInt("PositionJoystick") == 0)
        {
            PlayerPrefs.SetInt("PositionJoystick", 1);
        }
        else
        {
            PlayerPrefs.SetInt("PositionJoystick", 0);
        }
    }
}
