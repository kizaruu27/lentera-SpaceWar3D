using UnityEngine;

public class TestScript : MonoBehaviour
{
    // [SerializeField] private GameStateMachine stateMachine;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            GameStateMachine.Instance.PlayGame();
        
        if (Input.GetKeyDown(KeyCode.A))
            GameStateMachine.Instance.EndGame();
    }
}
