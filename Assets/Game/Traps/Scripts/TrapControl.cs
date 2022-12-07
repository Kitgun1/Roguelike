using KiUtilities.Random;
using NaughtyAttributes;
using UnityEngine;

public class TrapControl : MonoBehaviour
{
    [SerializeField] private TrapPropertyData _trapProperty;

    [SerializeField] private TrapType _trapType;
    [ShowIf(nameof(_openMove)), SerializeField] private TrapMovePropertyData _trapMoveProperty;
    [ShowIf(nameof(_openTurn)), SerializeField] private TrapTurnPropertyData _trapTurnProperty;
    [ShowIf(nameof(_openPhysics)), SerializeField] private TrapPhysicsPropertyData _trapPhysicsProperty;

    private Trap _trap;

    #region Feature

    private bool _openMove => _trapType == TrapType.MoveAndTurn || _trapType == TrapType.Move;
    private bool _openTurn => _trapType == TrapType.MoveAndTurn || _trapType == TrapType.Turn || _trapType == TrapType.PhysicsAndTurn;
    private bool _openPhysics => _trapType == TrapType.Physics || _trapType == TrapType.PhysicsAndTurn;

    #endregion

    private void Awake()
    {
        _trap = new Trap();
        _trap.SetSettings(_trapProperty.Trap.gameObject, _trapPhysicsProperty);
    }

    private void OnEnable()
    {
        if (_trapType == TrapType.PhysicsAndTurn || _trapType == TrapType.Physics)
            Physics();

        if (_trapType == TrapType.Move || _trapType == TrapType.MoveAndTurn)
            _trapProperty.Trap.position = _trapMoveProperty.WayPoints.StartPoint.position;
    }

    private void Update()
    {
        switch (_trapType)
        {
            case TrapType.Move:
                Move();
                break;
            case TrapType.MoveAndTurn:
                TurnAndMove();
                break;
            case TrapType.Turn:
            case TrapType.PhysicsAndTurn:
                Turn();
                break;
            default:
                break;
        }
    }

    #region Simplification

    private void Move()
    {
        _trapProperty.Trap.position = _trap.MoveTransform(_trapProperty.Trap, _trapMoveProperty.WayPoints, _trapMoveProperty.MoveSpeed * Time.deltaTime);
    }

    private void Turn()
    {
        _trapProperty.Trap.rotation = _trap.Turn(_trapProperty.Trap, _trapTurnProperty.TurnType, _trapTurnProperty.EularSpeed * Time.deltaTime * 360);
    }

    private void Physics()
    {

        if (_trapPhysicsProperty.RangePowerImpuls == 0)
            _trapPhysicsProperty.RangePowerImpuls = KiRandomExtension.RandomValueByFilter(-1, 1, 0);

        _trap.StartDirectionImpuls(_trapProperty.Trap.GetComponent<Rigidbody2D>(), new Vector2((-1 * _trapPhysicsProperty.RangePowerImpuls).RandomValueByFilter(_trapPhysicsProperty.RangePowerImpuls, 0, KiRandomExtension.RandomValue(0, 100)), (-1 * _trapPhysicsProperty.RangePowerImpuls).RandomValueByFilter(_trapPhysicsProperty.RangePowerImpuls, 0, KiRandomExtension.RandomValue(0, 100))));
    }

    private void TurnAndMove()
    {
        Turn();
        Move();
    }

    #endregion
}
