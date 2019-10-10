namespace lendit.Services
{
    public class WalletDecriptorModel
    {
        public int WalletId { get; set; }
        public string WalletHash { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        public string Balance { get; set; }
    }
}