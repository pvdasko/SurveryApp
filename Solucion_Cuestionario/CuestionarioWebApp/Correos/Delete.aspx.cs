﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.Entity;
using Microsoft.AspNet.FriendlyUrls.ModelBinding;
using CuestionarioWebApp;

namespace CuestionarioWebApp.Correos
{
    public partial class Delete : System.Web.UI.Page
    {
        int pcorpo;
        string photel;
        string ptipo;
        string pemail;
        protected CuestionarioEntities _db = new CuestionarioEntities();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void DeleteItem(long Corporativo, string Hotel, string Tipo_Cuestionario , string Email)
        {
            using (_db)
            {
                var item = _db.S_Correos_Cuestionario.Where(m => m.Corporativo == Corporativo  && m.Hotel == Hotel && m.Tipo_Cuestionario == Tipo_Cuestionario && m.Email == Email ).FirstOrDefault();

                
                if (item != null)
                {
                    _db.S_Correos_Cuestionario.Remove(item);
                    _db.SaveChanges();
                }
            }
            Response.Redirect("../Correos/Default.aspx");
        }
       

        public CuestionarioWebApp.S_Correos_Cuestionario GetItem()
        {
            pcorpo = int.Parse(Request.QueryString["corpo"]);            
            photel = Request.QueryString["hotel"];
            ptipo  = Request.QueryString["tipo"];
            pemail = Request.QueryString["email"];
            if (pcorpo == null)
            {
                return null;
            }

            using (_db)
            {
                return _db.S_Correos_Cuestionario.Where(m => m.Corporativo == pcorpo && m.Hotel == photel && m.Tipo_Cuestionario ==ptipo && m.Email == pemail).FirstOrDefault();
            }
        }

        protected void ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName.Equals("Cancel", StringComparison.OrdinalIgnoreCase))
            {
                Response.Redirect("../Correos/Default.aspx");
            }
        }
    }
}