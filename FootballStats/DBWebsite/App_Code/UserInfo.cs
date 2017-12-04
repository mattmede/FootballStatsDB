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

    public static void deleteUser(string username)
    {
        //Couldn't figure out your insert b/c the IDatabase entry it takes in
        //So this is hard coded and should be changed when we get time to fiddle with it

        int? id = null;

        string command_string = "SELECT User_Id FROM Users WHERE Username = \'" + username + "\'";
            
            
        //"DELETE TOP (1) FROM Users";

        SqlCommand command = new SqlCommand(command_string, connection);

        connection.Open();
        var reader = command.ExecuteReader();
        var user = new User();
        while (reader.Read())
        {
            id = reader.GetInt32(0);

        }
        connection.Close();

        if (id != null)
        {
            command_string = "DELETE FROM Fav_Player WHERE User_Id = " + id;
        }

        command = new SqlCommand(command_string, connection);

        connection.Open();
        reader = command.ExecuteReader();
        connection.Close();

        if (id != null)
        {
            command_string = "DELETE FROM Fav_Team WHERE User_Id = " + id;
        }

        command = new SqlCommand(command_string, connection);

        connection.Open();
        reader = command.ExecuteReader();
        connection.Close();

        if (id != null)
        {
            command_string = "DELETE FROM Users WHERE User_Id = " + id + " AND Username = \'" + username +"\'";
        }

        command = new SqlCommand(command_string, connection);

        connection.Open();
        reader = command.ExecuteReader();
        connection.Close();
        //close connection

    }

    public static void updateUser(string username, string password, User user)
    {
        //Couldn't figure out your insert b/c the IDatabase entry it takes in
        //So this is hard coded and should be changed when we get time to fiddle with it

        int? id = null;

        string command_string = "SELECT User_Id FROM Users WHERE Username = \'" + user.Username + "\'";

        SqlCommand command = new SqlCommand(command_string, connection);

        connection.Open();
        var reader = command.ExecuteReader();
        while (reader.Read())
        {
            id = reader.GetInt32(0);

        }
        connection.Close();

        if (id != null)
        {
            command_string = "UPDATE Users SET Username = \'" + username + "\', Password = \'" + password +
                "\' WHERE User_Id = " + user.Id;
        }

        command = new SqlCommand(command_string, connection);

        connection.Open();
        reader = command.ExecuteReader();
        connection.Close();
        //close connection

    }

}