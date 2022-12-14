using System;
using System.Collections.Generic;

#nullable disable

namespace PaymentGateways.Domain.DataTransferObjects
{
    public partial class TblUserDepositRequest
    {
        public TblUserDepositRequest()
        {
            TblUserBusinessPackages = new HashSet<TblUserBusinessPackage>();
        }

        public long Id { get; set; }
        public bool? IsEnabled { get; set; }
        public DateTime? CreatedAt { get; set; }
        public long? CreatedBy { get; set; }
        public DateTime? ModifiedAt { get; set; }
        public long? ModifiedBy { get; set; }
        public DateTime? LastChanged { get; set; }
        public long? UserAuthId { get; set; }
        public long? CurrencyId { get; set; }
        public long? TargetWalletTypeId { get; set; }
        public string Address { get; set; }
        public decimal? Amount { get; set; }
        public string Remarks { get; set; }
        public short? DepositStatus { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public string RawRequestData { get; set; }
        public string ReferenceNo { get; set; }
        public string RawResponseData { get; set; }
        public long? GatewayId { get; set; }

        public virtual TblCurrencyEntity Currency { get; set; }
        public virtual TblGateway Gateway { get; set; }
        public virtual TblWalletEntity TargetWalletType { get; set; }
        public virtual TblIdentityCredential UserAuth { get; set; }
        public virtual ICollection<TblUserBusinessPackage> TblUserBusinessPackages { get; set; }
    }
}
