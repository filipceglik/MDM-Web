using System;
using System.Net.Http;
using NUnit.Framework;
using MDM_Web.API;
using MDM_Web.API.Controllers;
using MDM_Web.API.Infrastructure;
using Microsoft.AspNetCore.Http;
using Model;

namespace Tests
{
    public class Tests
    {
        private readonly DatabaseContext _databaseContext;
        

        [Test]
        public async void GetReturnsDeviceTest()
        {
            var repository = new DeviceRepository(_databaseContext);
            var device = await repository.GetDeviceByID("6F7A9069-B359-4C04-A2E9-677D42354CDA");
            var secondDevice = await repository.GetDeviceByID("FBCFC2A0-C8CA-45FA-8821-578EB755EBA5");
            Assert.IsInstanceOf<Guid>(device.Id);
            Assert.AreEqual("14.5.1",device.SystemVersion);
            Assert.AreNotEqual(device.deviceToken,secondDevice.deviceToken);
        }
    }
}