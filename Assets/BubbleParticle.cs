using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class BubbleParticle : MonoBehaviour
{
   public float minScale = .5f;
   public float maxScale = .5f;

   public float minSpeed = 1f;
   public float maxSpeed = 2f;
   private float speed = 0;
   
   private void Start()
   {
      float scale = Random.Range(minScale, maxScale);
      transform.localScale = Vector3.one * scale;

      speed = Random.Range(minSpeed, maxSpeed);
   }

   private void Update()
   {
      transform.position += Vector3.up * speed * Time.deltaTime;
      
      if(transform.position.y > Camera.main.transform.position.y + 15)
         Destroy(gameObject);
   }
}
