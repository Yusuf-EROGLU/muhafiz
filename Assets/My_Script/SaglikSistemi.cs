

public class SaglikSistemi 
{
    private float can;
    private float maxcan;
    public SaglikSistemi(float maxcan)
    {
        this.maxcan = maxcan;
        can = maxcan;
    }
    public float GetCan()
    {
        return can;
    }
    public void Hasar(float hasarMiktarı)
    {
        can = can-hasarMiktarı;
        if (can < 0) can = 0;
    }
    public void Iyilestir(float iyilesMiktarı)
    {
        can = can + iyilesMiktarı;
        if (can > maxcan) can = maxcan;
    }
    public float GetCanOranı()
    {
        return (float)can / maxcan;
    }

}
