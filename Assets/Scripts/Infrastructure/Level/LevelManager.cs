using UnityEngine;
using GameCore.Grids;
using GameCore.Guns;

public class LevelManager : MonoBehaviour
{
    private const int _badShotsBeforeAddingBubbles = 5;
    private int _currentBadShotNumber = 0;

    private BubbleGrid _grid;
    private GunBubblePool _fieldPool;
    private PlayerGun _playerGun;

    public void Init(BubbleGrid grid, GunBubblePool fieldPool, PlayerGun playerGun)
    {
        _grid = grid;
        _fieldPool = fieldPool;
        _playerGun = playerGun;

        
        _grid.OnLastLineHaveBubble += Lose;
        _playerGun.OnGoodShot += CheckGrid;
        _playerGun.OnBadShot += BadShotCounter;
    }

    private void CheckGrid()
    {
        if(_grid.CheckGrid())
        {
            Win();
        }
    }

    private void BadShotCounter()
    {
        _currentBadShotNumber++;
        if(_currentBadShotNumber >= _badShotsBeforeAddingBubbles)
        {
            _grid.BubbleShift(_fieldPool);
            _currentBadShotNumber = 0;
        }
    }

    private void Lose()
    {
        Debug.Log("System.NotImplementedException() Lose :)");
    }

    private void Win()
    {
        Debug.Log("System.NotImplementedException() Win :)");
    }

    private void OnDestroy()
    {
        
        _grid.OnLastLineHaveBubble -= Lose;
        _playerGun.OnGoodShot -= CheckGrid;
        _playerGun.OnBadShot -= BadShotCounter;
    }

}
