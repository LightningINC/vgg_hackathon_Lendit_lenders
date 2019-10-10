using System.ComponentModel.DataAnnotations.Schema;

namespace lendit.Model
{
    public class Wallet
    {

        public Wallet()
        {
            
        }
        public Wallet(int walletId, string walletHash, string privateKey, string publicKey, string balance, string userHash, User user)
        {
            this.WalletId = walletId;
            this.WalletHash = walletHash;
            this.PrivateKey = privateKey;
            this.PublicKey = publicKey;
            this.Balance = balance;
            this.UserHash = userHash;
            this.User = user;

        }
        public int WalletId { get; set; }
        public string WalletHash { get; set; }
        public string PrivateKey { get; set; }
        public string PublicKey { get; set; }
        public string Balance { get; set; }

        public string UserHash { get; set; }
        [ForeignKey(nameof(UserHash))]
        public User User { get; set; }
    }
}