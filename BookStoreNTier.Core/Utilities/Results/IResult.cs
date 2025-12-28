namespace BookStoreNTier.Core.Utilities.Results;

public interface IResult
{
    bool Success { get; } // İşlem başarılı mı?
    string Message { get; } // Kullanıcıya ne diyeceğiz?
    //Neden sadece get kullandık? Neden sonradan result.Message = "Hata oldu" diyemiyoruz?
    //Çünkü bir işlem bittiyse, bitmiştir. Tarihi değiştiremezsin.
}