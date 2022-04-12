using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCanvas : MonoBehaviour
{
    GameManager manager;

    public TMPro.TextMeshProUGUI PointText;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        PointText.text = $"{manager.PlayerPoints} points";
    }
}
