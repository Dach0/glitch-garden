using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeDisplay : MonoBehaviour
{
    [SerializeField] int life = 100;
    [SerializeField] int damage = 2;
    Text lifeText;

    // Start is called before the first frame update
    void Start()
    {
        lifeText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        lifeText.text = life.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void decreaseLife()
    {
        if (life > 0)
        {
            life -= damage;
            UpdateDisplay();
        }
        else
        {
            FindObjectOfType<LevelController>().HandleLoseCondition();
            // FindObjectOfType<LevelLoader>().LoadYouLose();
        }
    }
}
