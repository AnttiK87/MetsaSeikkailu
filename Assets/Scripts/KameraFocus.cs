using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//T�m�n teki melkolailla kokonaan ChatGPT. Yritetty kuitenkin ymm�rt�� mit� se teki.
public class KameraFocus : MonoBehaviour
{
    //Scripti jolla kamera saadaan k��ntym��n halutun peliobjektin suuntaan ja seuraamaan sit�

    //muuttujat
    public GameObject targetObject; //seurattava objekti
    public float rotationSpeed = 1f; //kameran k��ntymisen nopeus
    public float inactivityDuration = 5f; //viive, ett� kameraa saa k��nelty� my�s pois p�in seurattavasta objektista
    //t�t� yrit�tty my�s sen perusteella kun liike pys�htyy, mutta ei saatu toimimaan

    private float inactivityTimer = 0f; //laskuri viivett� varten

    //virheen hallintaa jos objektia ei ole m��ritetty
    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned!");
            enabled = false;
            return;
        }

    }

    //Seurataan objektia ja trigger�inti sill� kun objekti tulee aktiiviseksi
    void Update()
    {
        // Tarkastus onko objekti aktiivinen
        if (targetObject != null && targetObject.activeSelf)
        {
            // Lasketaan kameran ja objektin v�linen et�isyys
            Vector3 directionToTarget = targetObject.transform.position - transform.position;

            // Lasketaan mihin pit�� kameraa k��nt�� ett� n�hd��n objekti
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Interpolointi, ett� kamera seuraa objektia sulavasti
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // K�ynnistet��n laskuri kameran vapautusta varten
            inactivityTimer += Time.deltaTime;

            // Onko viive saavutettu
            if (inactivityTimer >= inactivityDuration)
            {
                // otetaan kameran seuranta pois kytkem�ll� scripti pois k�yt�st�
                enabled = false;
            }
        }

    }
}
