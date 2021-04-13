using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Data;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RibController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public RibController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        // requete get de la table rib
        [HttpGet]
        public JsonResult Get()
        {
            //requête sql : lecture de la table rib
            string query = @"select Id, Owner,Iban, Bic  from dbo.rib";


            DataTable table = new DataTable();

            //récuperer la connexion a la DB 
            string sqlDataSource = _configuration.GetConnectionString("RibAppCon");
            SqlDataReader myReader;

            using(SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;
                    
                    myReader.Close();
                    myCon.Close();
                }
            }
            // resultat en format json
            return new JsonResult(table);
        }

        [HttpPost]
        public JsonResult Post(Rib rib)
        {
            // check the given Iban 
            // string apiKey = "b4fe87409f2db8261665ed2cb6ee7fc0";
            // string  url   = "https://www.iban-test.de/api/check/{{rib.Iban}}?authcode={{apiKey}}";
            // use httpClient and uri 
            // test the response statut ? 200 executeQuery : altert(Iban incorrect !)

            string query = @"
                    insert into dbo.rib values 
                    ('" + rib.Owner + @"'
                    ,'" + rib.Iban + @"'
                    ,'" + rib.Bic + @"'
                    )
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("RibAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Added Successfully");
        }

        // Mise a jour du rib
        [HttpPut]
        public JsonResult Put(Rib rib)
        {
            string query = @" update dbo.rib set 
                    Owner = '"+rib.Owner+ @"'
                    ,Iban = '" + rib.Iban+ @"'
                    ,Bic = '" + rib.Bic+ @"'
                    where Id = " + rib.Id+ @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("RibAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Updated Successfully");
        }

        // suppression du rib
        [HttpDelete("{id}")]
        public JsonResult Delete(int id)
        {
            string query = @"
                    delete from dbo.rib
                    where Id = " + id + @" 
                    ";
            DataTable table = new DataTable();
            string sqlDataSource = _configuration.GetConnectionString("RibAppCon");
            SqlDataReader myReader;
            using (SqlConnection myCon = new SqlConnection(sqlDataSource))
            {
                myCon.Open();
                using (SqlCommand myCommand = new SqlCommand(query, myCon))
                {
                    myReader = myCommand.ExecuteReader();
                    table.Load(myReader); ;

                    myReader.Close();
                    myCon.Close();
                }
            }

            return new JsonResult("Deleted Successfully");
        }
    }
}
