using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PositonJostick : MonoBehaviour, IDragHandler
{
    public  GameObject Image;
    public void OnDrag(PointerEventData eventData)
    {
        if (PlayerPrefs.GetInt("PositionJoystick") == 1 && SceneManager.GetActiveScene().name == "JoystickSettings")           
        {
            transform.position = eventData.position;
            if (gameObject.tag == "MoveJoystick")
            {
                if (PlayerPrefs.GetInt("Joystick") == 1)
                {
                    PlayerPrefs.SetFloat("FixJoystickXM", eventData.position.x);
                    PlayerPrefs.SetFloat("FixJoystickYM", eventData.position.y);
                }
                else
                {
                    PlayerPrefs.SetFloat("OthJoystickXM", eventData.position.x);
                    PlayerPrefs.SetFloat("OthJoystickYM", eventData.position.y);
                }
            }
            else
            {
                if (PlayerPrefs.GetInt("Joystick") == 1)
                {
                    PlayerPrefs.SetFloat("FixJoystickXF", eventData.position.x);
                    PlayerPrefs.SetFloat("FixJoystickYF", eventData.position.y);
                }
                else
                {
                    PlayerPrefs.SetFloat("OthJoystickXF", eventData.position.x);
                    PlayerPrefs.SetFloat("OthJoystickYF", eventData.position.y);
                }
            }
        }
    }
    void Update()
    {
        if (PlayerPrefs.GetInt("PositionJoystick") == 1 && SceneManager.GetActiveScene().name == "JoystickSettings" && PlayerPrefs.GetInt("Joystick") != 1)
        {
            Image.SetActive(true);
        }
        else if (PlayerPrefs.GetInt("PositionJoystick") == 0 && SceneManager.GetActiveScene().name == "JoystickSettings" && PlayerPrefs.GetInt("Joystick") != 1)
        {
            Image.SetActive(false);
        }
        if (PlayerPrefs.GetInt("PositionJoystick") == 1 && SceneManager.GetActiveScene().name == "JoystickSettings")
        {
            if (PlayerPrefs.GetInt("Joystick") == 0)
            {
                GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<DynamicJoystick>().enabled = false;
                GameObject.FindGameObjectWithTag("FireJoystick").GetComponent<DynamicJoystick>().enabled = false;
            }
            else if (PlayerPrefs.GetInt("Joystick") == 1)
            {
                GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<FixedJoystick>().enabled = false;
                GameObject.FindGameObjectWithTag("FireJoystick").GetComponent<FixedJoystick>().enabled = false;
            }
            else
            {
                GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<FloatingJoystick>().enabled = false;
                GameObject.FindGameObjectWithTag("FireJoystick").GetComponent<FloatingJoystick>().enabled = false;
            }
        }
        else if (PlayerPrefs.GetInt("PositionJoystick") != 1 && SceneManager.GetActiveScene().name == "JoystickSettings")
        {
            if (PlayerPrefs.GetInt("Joystick") == 0)
            {
                GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<DynamicJoystick>().enabled = true;
                GameObject.FindGameObjectWithTag("FireJoystick").GetComponent<DynamicJoystick>().enabled = true;
            }
            else if (PlayerPrefs.GetInt("Joystick") == 1)
            {
                GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<FixedJoystick>().enabled = true;
                GameObject.FindGameObjectWithTag("FireJoystick").GetComponent<FixedJoystick>().enabled = true;
            }
            else
            {
                GameObject.FindGameObjectWithTag("MoveJoystick").GetComponent<FloatingJoystick>().enabled = true;
                GameObject.FindGameObjectWithTag("FireJoystick").GetComponent<FloatingJoystick>().enabled = true;
            }
        }
    }
}