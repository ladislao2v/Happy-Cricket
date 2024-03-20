namespace Code.Services.OverlapService
{
    public interface IOverlapService
    {
        bool IsOverlaped<T>(out T obj);
    }
}