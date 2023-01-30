using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(EventSystem))]
public class MainMenuInputAdapter : MonoBehaviour
{
    [SerializeField]
    private GameObject mainMenuPanel;
    [SerializeField]
    private GameObject settingsPanel;
    [SerializeField]
    private GameObject mainMenuFirstSelect;
    [SerializeField]
    private GameObject settingsFirstSelect;

    private EventSystem eventSystem;

    private void Start()
    {
        eventSystem = GetComponent<EventSystem>();
    }

    public void PlayButton()
    {
        SceneManager.LoadScene((int)ScenesEnum.Game);
    }

    public void SettingsButton()
    {
        mainMenuPanel.SetActive(false);
        settingsPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(settingsFirstSelect);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void SettingsBackButton()
    {
        settingsPanel.SetActive(false);
        mainMenuPanel.SetActive(true);
        eventSystem.SetSelectedGameObject(mainMenuFirstSelect);
    }
}
