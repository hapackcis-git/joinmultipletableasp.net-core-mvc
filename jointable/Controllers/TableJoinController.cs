using Microsoft.AspNetCore.Mvc;
using System;

using Microsoft.Data;
using Microsoft.Data.SqlClient;
using jointable.Models;
using System.Collections.Generic;

namespace jointable.Controllers
{
    public class TableJoinController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Result"] = TableColumnsDisplay();
            return View();
         
          
            
        }

        public static List<JoinTable> TableColumnsDisplay()
        {
            List<JoinTable> jt=new List<JoinTable>();
            string connection = @"Data Source=(LocalDb)\amit;Initial Catalog=countrydata;Integrated Security=True";

            using(SqlConnection conn = new SqlConnection(connection))
            {
                using(SqlCommand sqlcommand=new SqlCommand("select countries.countryName,states.stateName ,cities.cityName from countries full join states on countries.countryID=states.countryID full join cities on states.stateID=cities.stateID"))
                {
                    using(SqlDataAdapter sda=new SqlDataAdapter())
                    {
                        sqlcommand.Connection = conn;
                        conn.Open();
                        sda.SelectCommand = sqlcommand;
                        SqlDataReader sdr=sqlcommand.ExecuteReader();
                        while (sdr.Read())
                        {
                            JoinTable jtobj=new JoinTable();
                            jtobj.countryName = sdr["countryName"].ToString();
                            jtobj.stateName = sdr["stateName"].ToString();
                            jtobj.cityName = sdr["cityName"].ToString();  
                            jt.Add(jtobj);  
                        }
                       
                    
                    }
                    return jt;  

                }
            }
          
        }
    }
}
