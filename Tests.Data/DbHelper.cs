using Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests.Data
{
    public class DbHelper
    {
        public static void DeleteData(JUGContext db)
        {
            db.DeleteData();
        }
    }
}
