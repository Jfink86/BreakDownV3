using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BreakDownV3;
using Microsoft.AspNet.Identity;

namespace BreakDownV3.Controllers
{
    public class VehicleYearMakeModelController : ApiController
    {
        private BreakDownV3Entities db = new BreakDownV3Entities();

        public IEnumerable<VehicleModel> GetAll()
        {
            return db.VehicleModels.ToList();
        }
    }
}
