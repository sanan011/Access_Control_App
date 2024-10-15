using System;
using System.Collections.Generic;

public class AdminAccessController : AccessController
{
    private List<string> accessLogs = new List<string>();

    public override void LogAccess(string user, bool success)
    {
        string status = success ? "Successful" : "Failed";
        string logEntry = $"{DateTime.Now}: {user} access attempt was {status}";
        accessLogs.Add(logEntry);
        Console.WriteLine(logEntry);
    }

    public void GrantPrivileges(string user, Role newRole)
    {
        if (!users.ContainsKey(user))
        {
            Console.WriteLine($"Error: User {user} not found.");
        }
        else
        {
            users[user] = newRole;
            Console.WriteLine($"{user} has been granted {newRole} privileges.");
        }
    }

    public void RevokePrivileges(string user)
    {
        if (!users.ContainsKey(user))
        {
            Console.WriteLine($"Error: User {user} not found.");
        }
        else
        {
            users[user] = Role.User;
            Console.WriteLine($"{user}'s privileges have been revoked.");
        }
    }

    public void ViewAccessLogs()
    {
        if (accessLogs.Count == 0)
        {
            Console.WriteLine("No access logs available.");
        }
        else
        {
            Console.WriteLine("Access Logs:");
            foreach (var log in accessLogs)
            {
                Console.WriteLine(log);
            }
        }
    }

    public void ListUsers()
    {
        if (users.Count == 0)
        {
            Console.WriteLine("No users found.");
        }
        else
        {
            Console.WriteLine("Users and their roles:");
            foreach (var user in users)
            {
                Console.WriteLine($"{user.Key}: {user.Value}");
            }
        }
    }
}
