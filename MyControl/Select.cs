using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace MyControl
{
    public class Select
    {
        Konke.Controler control;
        public Select()
        {
            control = new Konke.Controler(ConfigurationManager.AppSettings["clientId"], ConfigurationManager.AppSettings["clientsecret"], ConfigurationManager.AppSettings["username"], ConfigurationManager.AppSettings["password"]);
        }

        public IEnumerable<Konke.MiniK> GetKList()
        {
            if (control != null)
            {
                return control.GetKList(control.Accesstoken, control.UserId()).ToArray();
            }
            return new List<Konke.MiniK>().ToArray();
        }
    }
}