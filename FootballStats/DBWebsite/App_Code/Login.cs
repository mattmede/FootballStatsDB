using DatabaseManipulation;
using DatabaseModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Linq;

/// <summary>
/// Summary description for Login
/// </summary>
public class Login
{
    public Login() {}

    private SqlConnection connection = new SqlConnection(@"Data Source=(local);Initial Catalog=FootBallStatsDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    public bool submitNewAccount(string username, string password, string password2)
    {
        //Couldn't figure out your insert b/c the IDatabase entry it takes in
        //So this is hard coded and should be changed when we get time to fiddle with it

        if (password != password2) { return false; }

        string user_string = "SELECT Username FROM Users WHERE Username = \'" + username + "\'";

        SqlCommand command = new SqlCommand(user_string, connection);

        connection.Open();
        var reader = command.ExecuteReader();

        if (reader.HasRows)
        {
            connection.Close();
            return false;
        }
        connection.Close();
        string command_string = "INSERT INTO Users (Username, Password) VALUES (\'" + username + "\',\'" + password + "\');";

        command = new SqlCommand(command_string, connection);

        connection.Open();
        command.ExecuteNonQuery();
        connection.Close();

        return true;

    }

    public bool submitLogin(string username, string password)
    {
        //Couldn't figure out your insert b/c the IDatabase entry it takes in
        //So this is hard coded and should be changed when we get time to fiddle with it

        string command_string = "SELECT Username, Password FROM Users WHERE Username = \'" + username + "\' AND Password = \'" + password +"\';";

        SqlCommand command = new SqlCommand(command_string, connection);

        connection.Open();
        var reader = command.ExecuteReader();

        if (reader.HasRows) {
            connection.Close();
            return true;
        }

        connection.Close();
        return false;

    }
}