using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
  [SerializeField] float destroyDelay = 0.5f;
  [SerializeField] Color32 hasPackageColor = new Color32(1, 1, 1, 1);
  [SerializeField] Color32 noPackageColor = new Color32(1, 1, 1, 1);
  bool hasPackage;
  SpriteRenderer spriteRenderer;

  void Start()
  {
    spriteRenderer = GetComponent<SpriteRenderer>();
    spriteRenderer.color = noPackageColor;
  }
   
 void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Package" && !hasPackage)
        {
          Debug.Log("Paketi aldın.");
          hasPackage = true;
          spriteRenderer.color = hasPackageColor;
          Destroy(other.gameObject, destroyDelay);
        } 
        if (other.tag == "Customer" && hasPackage)
        { 
          Debug.Log("Paketi teslim ettin!");
          hasPackage = false;
          spriteRenderer.color = noPackageColor;
        }
    }

}
