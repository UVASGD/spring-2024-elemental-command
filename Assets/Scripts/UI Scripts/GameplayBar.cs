using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;

public class GameplayBar : MonoBehaviour
{

    [SerializeField] RectTransform IceImage;

    [SerializeField] RectTransform IceText;

    [SerializeField] RectTransform AirImage;
    [SerializeField] RectTransform AirText;
    [SerializeField] RectTransform EarthImage;

    [SerializeField] RectTransform EarthText;

    [SerializeField] RectTransform QText;

    [SerializeField] RectTransform ToCancelText;


    // Start is called before the first frame update
    void Start()
    {

        ElementAvailability elementAvailability = GetComponent<ElementAvailability>();

        if (ElementAvailability.count == 3){ //If three elements are available, draw them like this

            AirImage.anchoredPosition = new UnityEngine.Vector2(-350, 70);
            AirText.anchoredPosition = new UnityEngine.Vector2(-190, 90);

            EarthImage.anchoredPosition = new UnityEngine.Vector2(-150, 70);
            EarthText.anchoredPosition = new UnityEngine.Vector2(10, 90);

            IceImage.anchoredPosition = new UnityEngine.Vector2(50, 70);
            IceText.anchoredPosition = new UnityEngine.Vector2(210, 90);

            QText.anchoredPosition = new UnityEngine.Vector2(300, 90);
            ToCancelText.anchoredPosition = new UnityEngine.Vector2(340, 55);

        } else if (ElementAvailability.count == 2){

            if (elementAvailability.Air_Available && elementAvailability.Earth_Available){
                //if air and earth are availible
            AirImage.anchoredPosition = new UnityEngine.Vector2(-150, 70);
            AirText.anchoredPosition = new UnityEngine.Vector2(10, 90);

            EarthImage.anchoredPosition = new UnityEngine.Vector2(50, 70);
            EarthText.anchoredPosition = new UnityEngine.Vector2(210, 90);

            IceImage.anchoredPosition = new UnityEngine.Vector2(50, -300);
            IceText.anchoredPosition = new UnityEngine.Vector2(210, -300);

            QText.anchoredPosition = new UnityEngine.Vector2(300, 90);
            ToCancelText.anchoredPosition = new UnityEngine.Vector2(340, 55);


            } else if (elementAvailability.Air_Available && elementAvailability.Ice_Available){
            AirImage.anchoredPosition = new UnityEngine.Vector2(-150, 70);
            AirText.anchoredPosition = new UnityEngine.Vector2(10, 90);

            IceImage.anchoredPosition = new UnityEngine.Vector2(50, 70);
            IceText.anchoredPosition = new UnityEngine.Vector2(210, 90);

            QText.anchoredPosition = new UnityEngine.Vector2(300, 90);
            ToCancelText.anchoredPosition = new UnityEngine.Vector2(340, 55);

            EarthImage.anchoredPosition = new UnityEngine.Vector2(50, -300);
            EarthText.anchoredPosition = new UnityEngine.Vector2(210, -300);

            } else if (elementAvailability.Earth_Available && elementAvailability.Ice_Available){

            EarthImage.anchoredPosition = new UnityEngine.Vector2(-150, 70);
            EarthText.anchoredPosition = new UnityEngine.Vector2(10, 90);

            IceImage.anchoredPosition = new UnityEngine.Vector2(50, 70);
            IceText.anchoredPosition = new UnityEngine.Vector2(210, 90);

            QText.anchoredPosition = new UnityEngine.Vector2(300, 90);
            ToCancelText.anchoredPosition = new UnityEngine.Vector2(340, 55);

            AirImage.anchoredPosition = new UnityEngine.Vector2(50, -300);
            AirText.anchoredPosition = new UnityEngine.Vector2(210, -300);

            }

        


        } else if (ElementAvailability.count == 1){

            if (elementAvailability.Air_Available){
            
            AirImage.anchoredPosition = new UnityEngine.Vector2(0, 70);
            AirText.anchoredPosition = new UnityEngine.Vector2(160, 90);

            QText.anchoredPosition = new UnityEngine.Vector2(250, 90);
            ToCancelText.anchoredPosition = new UnityEngine.Vector2(290, 55);

            EarthImage.anchoredPosition = new UnityEngine.Vector2(50, -300);
            EarthText.anchoredPosition = new UnityEngine.Vector2(210, -300);

            IceImage.anchoredPosition = new UnityEngine.Vector2(50, -300);
            IceText.anchoredPosition = new UnityEngine.Vector2(210, -300);

            } else if (elementAvailability.Earth_Available){

            EarthImage.anchoredPosition = new UnityEngine.Vector2(0, 70);
            EarthText.anchoredPosition = new UnityEngine.Vector2(160, 90);

            QText.anchoredPosition = new UnityEngine.Vector2(250, 90);
            ToCancelText.anchoredPosition = new UnityEngine.Vector2(290, 55);

            AirImage.anchoredPosition = new UnityEngine.Vector2(50, -300);
            AirText.anchoredPosition = new UnityEngine.Vector2(210, -300);

            IceImage.anchoredPosition = new UnityEngine.Vector2(50, -300);
            IceText.anchoredPosition = new UnityEngine.Vector2(210, -300);

            } else if (elementAvailability.Ice_Available){

            IceImage.anchoredPosition = new UnityEngine.Vector2(0, 70);
            IceText.anchoredPosition = new UnityEngine.Vector2(160, 90);

            QText.anchoredPosition = new UnityEngine.Vector2(250, 90);
            ToCancelText.anchoredPosition = new UnityEngine.Vector2(290, 55);

            AirImage.anchoredPosition = new UnityEngine.Vector2(50, -300);
            AirText.anchoredPosition = new UnityEngine.Vector2(210, -300);

            EarthImage.anchoredPosition = new UnityEngine.Vector2(50, -300);
            EarthText.anchoredPosition = new UnityEngine.Vector2(210, -300);
            }


        } else {

        } 

        if (!elementAvailability.PlayerCanCancel){ //If player cannot cancel states, send cancel text off screen
            QText.anchoredPosition = new UnityEngine.Vector2(300, -1000);
            ToCancelText.anchoredPosition = new UnityEngine.Vector2(340, -1000);
        }
    }

    // Update is called once per frame
    void Update()
    {


        
    }
}
