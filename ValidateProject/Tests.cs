using NUnit.Framework;
using ServiceLayer.Interfaces;
using ServiceLayer.Models.Address;
using ServiceLayer.Service;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        private readonly CommonFactorService _commonFactorService;
        private readonly AddressService _addressService;
        
        public Tests()
        {
            _commonFactorService = new CommonFactorService();
            _addressService = new AddressService();
        }
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        [TestCase(new int[] { 8, 12, 24, 32 })]
        public void highestCommonFactor(int [] testNumbers)
        {
            var result = _commonFactorService.highestCommonFactor(testNumbers);
            var expectedResult = 4;
            Assert.AreEqual(result, expectedResult);
        }

        [Test]
        public async Task TestGetAddresses()
        {
            List<Address> address = await _addressService.getAddressData();
            Assert.IsTrue(address != null && address.Count > 0);
        }

        [Test]
        
        public void TestValid()
        {
            Address address = new Address
            {
                postalCode = " ",
                country = new Country { code = "ZA" }
            };
            string reason = "";
            Assert.IsTrue(address.IsValid(out reason));
        }

        [Test]
        [TestCase("postal")]
        public async Task TestPrintSpecific(string addressType)
        {
            List<Address> address = await _addressService.getAddressData();
            var singleType = ServiceLayer.Program.PrintByType(address, addressType);
            var existType = singleType.Where(v => v.type.name.ToLower().Contains(addressType)).ToList();
            Assert.IsTrue(singleType != null && existType != null & existType.Count > 0);
        }
    }
}