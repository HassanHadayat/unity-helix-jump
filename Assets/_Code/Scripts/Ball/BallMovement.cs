using UnityEngine;
public interface IBallMovement
{
    public void HitStep(TrailRenderer trail, GameObject step);
}

public class NormalMovement : IBallMovement
{
    public void HitStep(TrailRenderer trail, GameObject step)
    {
    }
}


public class FireMovement : IBallMovement
{
    public void HitStep(TrailRenderer trail, GameObject step)
    {

    }
}
