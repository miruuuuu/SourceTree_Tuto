using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class UnityController : MonoBehaviour
{
    private Unit unit;
    private ICommand attackCommand, moveCommand, skillCommand;

    private Queue<ICommand> commandQueues = new Queue<ICommand>();
    private Stack<ICommand> excuteCommands = new Stack<ICommand>();

    void Awake()
    {
        unit = GetComponent<Unit>();

        attackCommand = new AttackCommand(unit);
        moveCommand = new MoveCommand(unit);
        skillCommand = new SkillCommand(unit, "Fireball");
    }

    void Update()
    {
        #region 즉시 실행
        if (Input.GetKeyDown(KeyCode.Q))
        {
            attackCommand.Execute();
            excuteCommands.Push(attackCommand);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            moveCommand.Execute();
            excuteCommands.Push(moveCommand);
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            skillCommand.Execute();
            excuteCommands.Push(skillCommand);
        }
        #endregion

        #region 누적 실행
        //턴 종료 시 실행된다거나.
        if (Input.GetKeyDown(KeyCode.Z))
        {
            commandQueues.Enqueue(attackCommand);
        }
        else if (Input.GetKeyDown(KeyCode.X))
        {
            commandQueues.Enqueue(moveCommand);
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            commandQueues.Enqueue(skillCommand);
        }

        #endregion

        if (Input.GetKeyDown(KeyCode.Return)) //큐에 쌓아둔 명령을 실행한다. (턴제)
        {
            while (commandQueues.Count > 0) //입력한 명령이 큐에 남아있는 동안
            {
                ICommand command = commandQueues.Dequeue(); //큐에서 명령을 하나 꺼내서
                command.Execute(); //실행하고
                excuteCommands.Push(command); //스택에 쌓아둔다.
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) //가장 최근에 실행한 명령을 취소한다.
        {
            if (excuteCommands.Count > 0) //실행한 명령이 스택에 남아있는 동안
            {
                ICommand lastCommand = excuteCommands.Pop();
                lastCommand.Cancel();
            }
            else
            {
                Debug.Log("되돌릴 명령이 없습니다.");
            }
        }


    }
}
