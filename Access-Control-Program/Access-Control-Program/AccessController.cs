using System;
using System.Collections.Generic;

public abstract class AccessController
{
    protected Dictionary<string, Role> users = new Dictionary<string, Role>();
    protected Dictionary<string, int> accessAttempts = new Dictionary<string, int>();

    public static bool CheckAccess(Role role)
    {
        return role == Role.Admin || role == Role.Moderator;
    }

    public abstract void LogAccess(string user, bool success);

    public void AddUser(string username, Role role)
    {
        if (users.ContainsKey(username))
        {
            Console.WriteLine($"Error: User {username} already exists.");
        }
        else
        {
            users[username] = role;
            accessAttempts[username] = 0;
            Console.WriteLine($"{username} added as {role}");
        }
    }

    public void RemoveUser(string username)
    {
        if (!users.ContainsKey(username))
        {
            Console.WriteLine($"Error: User {username} does not exist.");
        }
        else
        {
            users.Remove(username);
            accessAttempts.Remove(username);
            Console.WriteLine($"{username} has been removed.");
        }
    }

    public Role? GetUserRole(string username)
    {
        if (!users.ContainsKey(username))
        {
            Console.WriteLine($"Error: User {username} not found.");
            return null;
        }
        else
        {
            return users[username];
        }
    }

    public void TrackAccessAttempt(string username, bool success)
    {
        if (!users.ContainsKey(username))
        {
            Console.WriteLine($"Error: User {username} not found.");
        }
        else
        {
            accessAttempts[username] += success ? 0 : 1;
        }
    }

    public int GetFailedAttempts(string username)
    {
        if (!accessAttempts.ContainsKey(username))
        {
            Console.WriteLine($"Error: Failed attempt data not found for user {username}.");
            return 0;
        }
        else
        {
            return accessAttempts[username];
        }
    }
}
