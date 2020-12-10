using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECommerce_Application
{

    class Vendors
    {
        private string _vendorName;
        private string _vendorEmail;
        private string _vendorPassword;
        private string _vendorPhone;
        private string _vendorAddress;
        private string _vendorBankAccount;

        public string VendorName { get => _vendorName; set => _vendorName = value; }
        public string VendorEmail { get => _vendorEmail; set => _vendorEmail = value; }
        public string VendorPassword { get => _vendorPassword; set => _vendorPassword = value; }
        public string VendorPhone { get => _vendorPhone; set => _vendorPhone = value; }
        public string VendorAddress { get => _vendorAddress; set => _vendorAddress = value; }
        public string VendorBankAccount { get => _vendorBankAccount; set => _vendorBankAccount = value; }

        public  Vendors(string argvendorName,string argvendorEmail, string argvendorPassword, string argvendorPhone, string argvendorAddress, string argvendorBankAccount )
        {
            this.VendorName = argvendorName;
            this.VendorEmail = argvendorEmail;
            this.VendorPassword = argvendorPassword;
            this.VendorPhone = argvendorPhone;
            this.VendorAddress = argvendorAddress;
            this.VendorBankAccount = argvendorBankAccount;
        }

        public Vendors()
        {

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
