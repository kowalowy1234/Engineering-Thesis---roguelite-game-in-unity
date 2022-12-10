using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

  public Slider slider;
  public Text currentHpText;

  public void SetMaxHealth(float health)
  {
    slider.maxValue = health;
    slider.value = health;
  }

  public void SetHealth(float health)
  {
    slider.value = health;
    currentHpText.text = "" + Mathf.Ceil(health);
  }
}
