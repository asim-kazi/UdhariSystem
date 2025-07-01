using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace UdhariSystem.Models
{
    public class BorrowerDataAccess
    {
        string connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=UdhariDB;Integrated Security=True;TrustServerCertificate=True;";

        public List<Borrower> GetBorrowers(string search = null)
        {
            List<Borrower> list = new List<Borrower>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                string query = "SELECT * FROM Borrowers";
                if (!string.IsNullOrEmpty(search))
                {
                    query += " WHERE CustomerName LIKE @search OR Phone LIKE @search";
                }
                SqlCommand cmd = new SqlCommand(query, con);
                if (!string.IsNullOrEmpty(search))
                    cmd.Parameters.AddWithValue("@search", "%" + search + "%");

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Borrower
                    {
                        Id = Convert.ToInt32(reader["Id"]),
                        CustomerName = reader["CustomerName"].ToString(),
                        Phone = reader["Phone"].ToString(),
                        Address = reader["Address"].ToString(),
                        AmountOwed = Convert.ToDecimal(reader["AmountOwed"])
                    });
                }
            }
            return list;
        }

        public void AddBorrower(Borrower b)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Borrowers (CustomerName, Phone, AmountOwed, Address) VALUES (@name, @phone, @amount, @address)", con);
                cmd.Parameters.AddWithValue("@name", b.CustomerName);
                cmd.Parameters.AddWithValue("@phone", b.Phone);
                cmd.Parameters.AddWithValue("@amount", b.AmountOwed);
                cmd.Parameters.AddWithValue("@address", b.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public Borrower GetBorrowerById(int id)
        {
            Borrower b = null;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Borrowers WHERE Id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    b = new Borrower
                    {
                        Id = reader.GetInt32(0),
                        CustomerName = reader.GetString(1),
                        Phone = reader.GetString(2),
                        Address = reader.GetString(3),
                        AmountOwed = reader.GetDecimal(4),
                    };
                }
            }
            return b;
        }

        public void UpdateBorrower(Borrower b)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("UPDATE Borrowers SET CustomerName=@name, Phone=@phone, AmountOwed=@amount, Address=@address WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", b.Id);
                cmd.Parameters.AddWithValue("@name", b.CustomerName);
                cmd.Parameters.AddWithValue("@phone", b.Phone);
                cmd.Parameters.AddWithValue("@amount", b.AmountOwed);
                cmd.Parameters.AddWithValue("@address", b.Address);
                cmd.ExecuteNonQuery();
            }
        }

        public void DeleteBorrower(int id)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM Borrowers WHERE Id=@id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }
    }
}