using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ReloadPosition : MonoBehaviour, IDragHandler
{
    public void OnDrag(PointerEventData eventData)         
    {
        if (PlayerPrefs.GetInt("PositionJoystick") == 1 && SceneManager.GetActiveScene().name == "JoystickSettings")
        {
            transform.position = eventData.position;
            PlayerPrefs.SetFloat("ReloadX", eventData.position.x);
            PlayerPrefs.SetFloat("ReloadY", eventData.position.y);
        }
    }
    public void Reloading()
    {
        PlayerPrefs.SetInt("Reload", 1);
    }
}
