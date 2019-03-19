﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserController : MonoBehaviour
{
    public Transform activeIndicator;
    public Transform countDown;
    public Text userName;
    public Text userAmount;
    public RawImage userImage;
    public bool isActive = false;
    public bool eliminated = false;
    [SerializeField] private float percentage;
    [SerializeField] private float speed;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(isActive == true)
        {
            activeIndicator.gameObject.SetActive(true);
            countDown.gameObject.SetActive(true);
            if (percentage < 100)
            {
                percentage += speed * Time.deltaTime;
                countDown.GetComponent<Image>().fillAmount = percentage / 100;
            }
            else
            {
                isActive = false;
            }
        }
        else
        {
            activeIndicator.gameObject.SetActive(false);
            countDown.gameObject.SetActive(false);
            percentage = 0;
        }
    }

    public void SetInfo(PlayerInfo info)
    {
        userName.text = info.userName;
        userAmount.text = info.amount.ToString();
    }

    public void SetTexture(Texture2D texture)
    {
        userImage.texture = texture;
    }
}