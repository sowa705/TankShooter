using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameCanvas : MonoBehaviour
{
    GameManager manager;

    public TMPro.TextMeshProUGUI PointText;
    public TMPro.TextMeshProUGUI LivesText;

    public Image CooldownImage;
    public TMPro.TextMeshProUGUI LevelText;


    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();

    }

    // Update is called once per frame
    void Update()
    {
        PointText.text = manager.PlayerPoints.ToString();
        LivesText.text = $"{manager.PlayerLives} lives remaining";

        float imageFill = (manager.CurrentLevelConfig.SpecialCooldown - manager.Player.SpecialCooldown) / manager.CurrentLevelConfig.SpecialCooldown;
        imageFill = Mathf.Clamp01(imageFill);
        CooldownImage.fillAmount = imageFill;
        CooldownImage.color = imageFill >= 1f? Color.blue: Color.gray;

        LevelText.text = (manager.PlayerCurrentLevel + 1).ToString();
    }
}
