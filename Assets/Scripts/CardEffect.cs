using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class CardEffect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject player;
    public GameObject AI;
    public GameObject[] prison;
    public GameObject[] prisonOutPoint;
    public GameObject orderNumPanel;

    private bool selected = false;
    private string currentCardName;

    void Awake()
    {
        prison = GameObject.FindGameObjectsWithTag("Prison");
        prisonOutPoint = GameObject.FindGameObjectsWithTag("PrisonOutPoint");
    }

	public void SelectCard()
    {
        if(!selected)
        {
            selected = !selected;
            GetComponent<Animator>().SetBool("Pressed", true);
        }
        else
        {
            selected = !selected;
            GetComponent<Animator>().SetBool("Pressed", false);
            UseCard();
        }
    }

    public void UseCard()
    {
        currentCardName = GetComponent<Image>().sprite.name;

        switch(currentCardName)
        {
            case "card_1_AI prison":
                int prisonNum = UnityEngine.Random.Range(0, prison.Length);
                AI.transform.position = prison[prisonNum].transform.position;
                break;
            case "card_1_one_three_five":
                player.GetComponent<PlayerController>().playerState = PlayerController.PlayerState.OddMove;
                break;
            case "card_1_PK":
                break;
            case "card_1_player prison":
                int prisonOutNum = UnityEngine.Random.Range(0, prisonOutPoint.Length);
                player.transform.position = prison[prisonOutNum].transform.position;
                break;
            case "card_1_stop_AI_turn":
                AI.GetComponent<AIController>().aiState = AIController.AIState.Stop;
                break;
            case "card_1_two_four_six":
                player.GetComponent<PlayerController>().playerState = PlayerController.PlayerState.EvenMove;
                break;
            case "card_2_$_double":
                GameManager.coins *= 2;
                break;
            case "card_2_digital_double":
                player.GetComponent<PlayerController>().playerState = PlayerController.PlayerState.DoubleMove;
                break;
            case "card_2_position":
                Vector3 playerTemp = player.transform.position;
                Vector3 AITemp = AI.transform.position;
                player.transform.position = AITemp;
                AI.transform.position = playerTemp;
                break;
            case "card_2_specify_digital":
                orderNumPanel.SetActive(true);
                break;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Animator animator = eventData.pointerEnter.GetComponent<Animator>();
        animator.SetBool("Normal", false);
        animator.SetBool("Highlighted", true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Animator animator = eventData.pointerEnter.GetComponent<Animator>();
        animator.SetBool("Normal", true);
        animator.SetBool("Highlighted", false);
    }

    public void OrderStep(int num)
    {
        player.GetComponent<PlayerController>().step = num;
        player.GetComponent<PlayerController>().playerState = PlayerController.PlayerState.OrderMove;
        orderNumPanel.SetActive(false);
        player.GetComponent<PlayerController>().SetStep();
    }

    /*
    public void OnPointerDown(PointerEventData eventData)
    {
        Animator animator = eventData.pointerPressRaycast.gameObject.GetComponent<Animator>();
        animator.SetBool("Pressed", true);
    }
    */
}
