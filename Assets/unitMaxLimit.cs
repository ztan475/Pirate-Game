using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class unitMaxLimit : MonoBehaviour
{

   public static int maxTroops = 0;
   int maximum =7;
   private bool deletedTroop=false;
    // Start is called before the first frame update
    void Start()
    {
           
      maxTroops+=1;
      if(maxTroops == maximum+4)  {
         
       
           if(gameObject.name.Contains("Melee")){
            CurrencySystem.totalGoldPublic+=10;
        }
          if(gameObject.name.Contains("Ranged")){
            CurrencySystem.totalGoldPublic+=15;
        }
          if(gameObject.name.Contains("Shield")){
            CurrencySystem.totalGoldPublic+=20;
        }
          
          Destroy(gameObject);
        
        
      
        
      }
     
         
     
       
      
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrencySystem.totalGoldPublic<0){
            CurrencySystem.totalGoldPublic=0;
        }
    }

    void OnDestroy(){
       
       maxTroops-=1;
      
    }
}
