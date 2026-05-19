using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NavigationUI : MonoBehaviour
{
    public GameObject startPanel;
    public GameObject routinesPanel;
    // Start is called before the first frame update
    void Start()
    {
        ShowInitialPanel();
    }

    public void ShowRoutinesPanel()
    {
        // Apagamos el de inicio y encendemos el de rutinas
        startPanel.SetActive(false);
        routinesPanel.SetActive(true);
    }
    
    public void ShowInitialPanel()
    {
        // Apagamos el de rutinas y encendemos el de inicio
        routinesPanel.SetActive(false);
        startPanel.SetActive(true);
    }
}
