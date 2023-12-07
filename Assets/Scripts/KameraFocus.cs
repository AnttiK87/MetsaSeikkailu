using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tämän teki melkolailla kokonaan ChatGPT. Yritetty kuitenkin ymmärtää mitä se teki.
public class KameraFocus : MonoBehaviour
{
    //Scripti jolla kamera saadaan kääntymään halutun peliobjektin suuntaan ja seuraamaan sitä

    //muuttujat
    public GameObject targetObject; //seurattava objekti
    public float rotationSpeed = 1f; //kameran kääntymisen nopeus
    public float inactivityDuration = 5f; //viive, että kameraa saa kääneltyä myös pois päin seurattavasta objektista
    //tätä yritétty myös sen perusteella kun liike pysähtyy, mutta ei saatu toimimaan

    private float inactivityTimer = 0f; //laskuri viivettä varten

    //virheen hallintaa jos objektia ei ole määritetty
    void Start()
    {
        if (targetObject == null)
        {
            Debug.LogError("Target object is not assigned!");
            enabled = false;
            return;
        }

    }

    //Seurataan objektia ja triggeröinti sillä kun objekti tulee aktiiviseksi
    void Update()
    {
        // Tarkastus onko objekti aktiivinen
        if (targetObject != null && targetObject.activeSelf)
        {
            // Lasketaan kameran ja objektin välinen etäisyys
            Vector3 directionToTarget = targetObject.transform.position - transform.position;

            // Lasketaan mihin pitää kameraa kääntää että nähdään objekti
            Quaternion targetRotation = Quaternion.LookRotation(directionToTarget);

            // Interpolointi, että kamera seuraa objektia sulavasti
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);

            // Käynnistetään laskuri kameran vapautusta varten
            inactivityTimer += Time.deltaTime;

            // Onko viive saavutettu
            if (inactivityTimer >= inactivityDuration)
            {
                // otetaan kameran seuranta pois kytkemällä scripti pois käytöstä
                enabled = false;
            }
        }

    }
}
