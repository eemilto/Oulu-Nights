using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
   [SerializeField] private Health playerHealth;
   [SerializeField] Image totalHealthBar;
   [SerializeField] Image currenthealthBar;
   

   private void Start() 
   {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 3;
   }

   private void Update() 
   {
        currenthealthBar.fillAmount = playerHealth.currentHealth / 3;
   }
}
