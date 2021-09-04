using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class levelWindow : MonoBehaviour
{
    private Text levelText;
    private Image experienceBarImage;
    private levelSystem levelSystem;

    private void Awake()
    {
        levelText = transform.Find("levelText").GetComponent<Text>();
        experienceBarImage = transform.Find("experienceBar").Find("bar").GetComponent<Image>();
    }

    private void setExperienceBarSize(float experienceNormalized)
    {
        experienceBarImage.fillAmount = experienceNormalized;
    }

    private void setLevelNumber(int levelNumber)
    {
        levelText.text = "LVL  : " + (levelNumber + 1);
    }

    public void setLevelSystem(levelSystem levelSystem)
    {
        // set levelSystem values
        this.levelSystem = levelSystem;

        // update starting value
        setLevelNumber(levelSystem.getLevelNumber());
        setExperienceBarSize(levelSystem.getExperienceNormalized());

        // surbscribe to the changed events
        levelSystem.OnExperienceChanged += levelSystem_OnExperienceChanged;
        levelSystem.OnLevelChanged += levelSystem_OnLevelChanged;
    }

    private void levelSystem_OnLevelChanged(object sender, System.EventArgs e)
    {
        //level changed , update text
        setLevelNumber(levelSystem.getLevelNumber());
    }

    private void levelSystem_OnExperienceChanged(object sender, System.EventArgs e)
    {
        //exp changed , update bar size
        setExperienceBarSize(levelSystem.getExperienceNormalized());
    }
}
