namespace BookStoreNTier.Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        // Sen sadece mesaj ver, gerisini ben hallederim (Data yok, Success false)
        public ErrorDataResult(string message) : base(default, false, message)
        {
        }

        // Sen hiçbir şey verme, ben başarısız der geçerim.
        public ErrorDataResult() : base(default, false)
        {
        }
    }
}