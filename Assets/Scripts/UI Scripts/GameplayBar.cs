using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

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

    private ElementManager em;

    private ElementAvailability elementAvailability;

    private bool Earth_Highlighted;

    private bool Air_Highlighted;

    private bool Ice_Highlighted;


    // Start is called before the first frame update
    void Start()
    {
        Earth_Highlighted = false;

        Air_Highlighted = false;

        Ice_Highlighted = false;

        em = FindObjectOfType<ElementManager>();

        elementAvailability = GetComponent<ElementAvailability>();

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

        if (em.state == ElementManager.Element.Earth && !Earth_Highlighted){

            Earth_Highlighted = true;
            Ice_Highlighted = false;
            Air_Highlighted = false;
            EarthImage.transform.localScale = new UnityEngine.Vector3(1.5f, 1.5f, 1f);

            IceImage.transform.localScale = new UnityEngine.Vector3(1f, 1f, 1f);
            AirImage.transform.localScale = new UnityEngine.Vector3(1f, 1f, 1f);
        }

        if (em.state == ElementManager.Element.Ice && !Ice_Highlighted){
            Ice_Highlighted = true;
            Air_Highlighted = false;
            Earth_Highlighted = false;
            IceImage.transform.localScale = new UnityEngine.Vector3(1.5f, 1.5f, 1f);
            
            EarthImage.transform.localScale = new UnityEngine.Vector3(1f, 1f, 1f);
            AirImage.transform.localScale = new UnityEngine.Vector3(1f, 1f, 1f);
        }

        if (em.state == ElementManager.Element.Air && !Air_Highlighted){
            Air_Highlighted = true;
            Ice_Highlighted = false;
            Earth_Highlighted = false;
            AirImage.transform.localScale = new UnityEngine.Vector3(1.5f, 1.5f, 1f);
            
            IceImage.transform.localScale = new UnityEngine.Vector3(1f, 1f, 1f);
            EarthImage.transform.localScale = new UnityEngine.Vector3(1f, 1f, 1f);
        }




        
    }
}
