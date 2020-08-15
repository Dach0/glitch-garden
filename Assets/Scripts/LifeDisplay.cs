using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] float baseLife = 10;
    [SerializeField] int damage = 2;
    float lives;
    Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        lives = baseLife - PlayerPrefsController.GetDifficulty();
        lifeText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        lifeText.text = baseLife.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseLife()
    {
        if (baseLife > 0)
        {
            baseLife -= damage;
            UpdateDisplay();
        }
        else
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            // FindObjectOfType<LevelLoader>().LoadYouLose();
        }
    }
}
