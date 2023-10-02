public abstract class State
{
    public abstract void Enter();
    public abstract void Tick(float deltaTIme);
    public abstract void Exit();
}
