using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitCountUpdate : MonoBehaviour
{
  [SerializeField]
   private TMP_Text tmpText;

   private int hitCount = 0;

   void Start() {
        tmpText.text = "Hit Count: Nil";
   }

    void Update()
    {
        tmpText.text = "Hit Count: " + Projectile.Projectile.hitCount;
    }
}
