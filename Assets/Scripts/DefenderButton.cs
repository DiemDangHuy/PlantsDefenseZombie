using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderButton : MonoBehaviour
{
    [SerializeField] Defender defenderPrefab;
    DefenderSpawner defen;
    private void Start()
    {
        defen = (DefenderSpawner)FindObjectOfType(typeof(DefenderSpawner));
    }
    private void OnMouseDown()
    {
        var buttons = FindObjectsOfType<DefenderButton>();
        foreach (DefenderButton button in buttons)
        {
            button.GetComponent<SpriteRenderer>().color = new Color32(0, 0, 0, 255);
        }
        GetComponent<SpriteRenderer>().color = Color.white;
        defen.SetSelectedDefender(defenderPrefab);
        //GetComponent<DefenderSpawner>().SetSelectedDefender(defenderPrefab);
    }
}
