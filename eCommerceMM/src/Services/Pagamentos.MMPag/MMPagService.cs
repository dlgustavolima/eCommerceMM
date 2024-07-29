namespace Pagamentos.MMPag;

public class MMPagService
{
    public readonly string ApiKey;
    public readonly string EncryptionKey;

    public MMPagService(string apiKey, string encryptionKey)
    {
        ApiKey = apiKey;
        EncryptionKey = encryptionKey;
    }
}
