using System.ComponentModel.DataAnnotations.Schema;

namespace lendit.Model
{
    public class Wallet
    {

        public Wallet()
        {
            
        }
        public Wallet(int walletId, string walletHash, int privateKey, int publicKey, string balance, string userHash, User user)
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
        public int PrivateKey { get; set; }
        public int PublicKey { get; set; }
        public string Balance { get; set; }

        public string UserHash { get; set; }
        [ForeignKey(nameof(UserHash))]
        public User User { get; set; }
    }
}