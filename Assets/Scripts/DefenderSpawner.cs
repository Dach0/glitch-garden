using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;

    private void OnMouseDown()
    {
        if (!defender) { return; };
        AttemptToPlaceDefenderAt(GetSquareClicked());
    }

    public void SetSelectedDefender(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefenderAt( Vector2 gridPos)
    {
        var starDisplay = FindObjectOfType<StarDisplay>();
        int defenderCost = defender.GetStarCost();

        //if we have enough stars, spawn defender, spend money
        if (starDisplay.HaveEnoughStars(defenderCost))
        {
            spawnDefender(gridPos);
            starDisplay.SpendStars(defenderCost);
        }
    }



    //gdje sam kliknuo 
    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);

        Vector2 gridPos = SnapToGrid(worldPos);
        
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        return new Vector2(newX, newY);
    }

    private void spawnDefender(Vector2 position)
    {
        Defender newDefender = Instantiate(defender, position, Quaternion.identity) as Defender;
    }
}
