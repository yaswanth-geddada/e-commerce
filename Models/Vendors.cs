using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace models
{

    class Vendors
    {
        private string _vendorName;
        private string _vendorEmail;
        private string _vendorPassword;
        private string _vendorPhone;
        private string _vendorAddress;
        private string _vendorBankAccount;

        public void Vendors()
        {

        }

        public string VendorBankAccount { get => _vendorBankAccount; set => _vendorBankAccount = value; }
        public string VendorAddress { get => _vendorAddress; set => _vendorAddress = value; }
        public string VendorPhone { get => _vendorPhone; set => _vendorPhone = value; }
        public string VendorPassword { get => _vendorPassword; set => _vendorPassword = value; }
        public string VendorEmail { get => _vendorEmail; set => _vendorEmail = value; }
        public string VendorName { get => _vendorName; set => _vendorName = value; }

        public void Vendors(_vendorName, _vendorEmail, _vendorPassword, _vendorPhone, _vendorAddress, _vendorBankAccount )
        {
            this._vendorName = _vendorName;
            this._vendorEmail = _vendorEmail;
            this._vendorPassword = _vendorPassword;
            this._vendorPhone = _vendorPhone;
            this._vendorAddress = _vendorAddress;
            this._vendorBankAccount = _vendorBankAccount;
        }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }

}
