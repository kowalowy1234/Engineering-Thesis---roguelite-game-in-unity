using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
  public Slider slider;
  public Text energyText;

  public void SetMaxEnergy(float energy)
  {
    slider.maxValue = energy;
    slider.value = energy;
  }

  public void SetEnergy(float energy)
  {
    slider.value = energy;
    energyText.text = "" + Mathf.Ceil(energy);
  }
}
