using System;
using System.Collections.Generic;

#nullable disable

namespace RBS.Domain.DataTransferObjects
{
    public partial class TblUserWallet
    {
        public TblUserWallet()
        {
            TblUserWalletTransactions = new HashSet<TblUserWalletTransaction>();
        }

        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long UserAuthId { get; set; }
        public long? WalletTypeId { get; set; }
        public decimal Balance { get; set; }

        public virtual TblIdentityCredential UserAuth { get; set; }
        public virtual TblWalletEntity WalletType { get; set; }
        public virtual ICollection<TblUserWalletTransaction> TblUserWalletTransactions { get; set; }
    }
}
