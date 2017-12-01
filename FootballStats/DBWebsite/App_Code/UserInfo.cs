using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using DatabaseModels;
using System.Web.Services;

/// <summary>
/// Summary description for User
/// </summary>
public class UserInfo
{
    public UserInfo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    private  static SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=FootBallStatsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    public User getFirstUser()
    {
        //Couldn't figure out your insert b/c the IDatabase entry it takes in
        //So this is hard coded and should be changed when we get time to fiddle with it

        string command_string = "SELECT TOP 1 * FROM Users";

        SqlCommand command = new SqlCommand(command_string, connection);

        connection.Open();
        var reader = command.ExecuteReader();
        var user = new User();
        while (reader.Read())
        {
            user = new User(reader.GetString(1), reader.GetString(2), reader.GetInt32(0));

        }
        //return object from reader
        //close connnection
        connection.Close();

        return user;

    }

    public User getUser(string username)
    {
        //Couldn't figure out your insert b/c the IDatabase entry it takes in
        //So this is hard coded and should be changed when we get time to fiddle with it

        string command_string = "SELECT * FROM Users Where Username = \'"+ username +"\'";

        SqlCommand command = new SqlCommand(command_string, connection);

        connection.Open();
        var reader = command.ExecuteReader();
        var user = new User();
        while (reader.Read())
        {
            user = new User(reader.GetString(1), reader.GetString(2), reader.GetInt32(0));

        }
        //return object from reader
        //close connnection
        connection.Close();

        return user;

    }

    public static void deleteUser()
    {
        //Couldn't figure out your insert b/c the IDatabase entry it takes in
        //So this is hard coded and should be changed when we get time to fiddle with it

        string command_string = "DELETE TOP (1) FROM Users";

        SqlCommand command = new SqlCommand(command_string, connection);

        connection.Open();
        var reader = command.ExecuteReader();
        connection.Close();
        //close connection

    }

}